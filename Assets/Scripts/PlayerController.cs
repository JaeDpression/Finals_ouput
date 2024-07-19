using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 10f;
    public Rigidbody2D rb;
    private bool canMove = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0; // Disable gravity at the start
    }

    private void Update()
    {
        if (GameManager.Instance.IsGameActive && canMove && Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }

    private void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            GameManager.Instance.GameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Gem"))
        {
            UIManager.Instance.IncreaseScore();
            Destroy(other.gameObject);
        }
    }

    public void SetCanMove(bool move)
    {
        canMove = move;
        rb.gravityScale = move ? 1 : 0; // Enable or disable gravity based on movement
    }
}
