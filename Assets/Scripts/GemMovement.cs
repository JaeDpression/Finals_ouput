using UnityEngine;

public class GemMovement : MonoBehaviour
{
    public float moveSpeed = 2f;

    private void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        if (transform.position.x < -10f) // Adjust as per your scene width
        {
            Destroy(gameObject);
        }
    }
}
