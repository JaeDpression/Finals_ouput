using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(OnStartButtonClick);
    }

    private void OnStartButtonClick()
    {
        UIManager.Instance.StartGame();
    }
}
