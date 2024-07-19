using UnityEngine;
using UnityEngine.UI;

public class RetryButton : MonoBehaviour
{
    public Button retryButton;

    private void Start()
    {
        retryButton.onClick.AddListener(RestartGame);
    }

    private void RestartGame()
    {
        UIManager.Instance.RestartGame();
    }
}
