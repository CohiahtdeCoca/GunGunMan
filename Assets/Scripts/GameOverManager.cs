using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverPopup;
    public Button replayButton;
    public Button levelSelectButton;

    void Start()
    {
        gameOverPopup.SetActive(false);
        replayButton.onClick.AddListener(ReplayLevel);
        levelSelectButton.onClick.AddListener(GoToLevelSelect);
    }

    public void ShowGameOverPopup()
    {
        gameOverPopup.SetActive(true);
        Time.timeScale = 0; // Dừng game
    }

    private void ReplayLevel()
    {
        Time.timeScale = 1; // Tiếp tục game
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void GoToLevelSelect()
    {
        Time.timeScale = 1; // Tiếp tục game
        SceneManager.LoadScene("LevelSelectScene"); // Thay "LevelSelectScene" bằng tên scene chọn level của bạn
    }
}
