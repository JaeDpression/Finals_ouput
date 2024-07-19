using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    public Button startButton;
    public Button retryButton;
    public GameObject gameOverPanel;
    public Text scoreText;
    public PlayerController playerController;

    private int score = 0;

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

    private void Start()
    {
        startButton.onClick.AddListener(StartGame);
        retryButton.onClick.AddListener(RestartGame);
        ShowStartMenu();
    }

    public void StartGame()
    {
        GameManager.Instance.StartGame();
        score = 0;
        UpdateScoreText();
        startButton.gameObject.SetActive(false);
        gameOverPanel.SetActive(false);
        playerController.SetCanMove(true); // Enable player movement and gravity
    }

    public void RestartGame()
    {
        GameManager.Instance.StartGame();
        score = 0;
        UpdateScoreText();
        retryButton.gameObject.SetActive(false);
        gameOverPanel.SetActive(false);
        playerController.SetCanMove(true); // Enable player movement and gravity
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
        retryButton.gameObject.SetActive(true);
        playerController.SetCanMove(false); // Disable player movement and gravity
    }

    private void ShowStartMenu()
    {
        startButton.gameObject.SetActive(true);
        gameOverPanel.SetActive(false);
        playerController.SetCanMove(false); // Disable player movement and gravity
    }

    public void IncreaseScore()
    {
        score++;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
