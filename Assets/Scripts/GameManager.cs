using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public bool IsGameActive { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void StartGame()
    {
        IsGameActive = true;
    }

    public void EndGame()
    {
        IsGameActive = false;
    }

    public void GameOver()
    {
        EndGame();
        UIManager.Instance.ShowGameOver();
    }
}
