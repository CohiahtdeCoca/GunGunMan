using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelCompleteManager : MonoBehaviour
{
    public GameObject levelCompletePopup;
    public Button nextLevelButton;
    public Button mainMenuButton;

    void Start()
    {
        levelCompletePopup.SetActive(false);
        nextLevelButton.onClick.AddListener(NextLevel);
        mainMenuButton.onClick.AddListener(GoToMainMenu);
    }

    public void ShowLevelCompletePopup()
    {
        levelCompletePopup.SetActive(true);
        Time.timeScale = 0; // Dừng game
    }

    private void NextLevel()
    {
        Time.timeScale = 1; // Tiếp tục game
        // Tải level tiếp theo, thay "NextLevelScene" bằng tên scene của level tiếp theo
        SceneManager.LoadScene("NextLevelScene");
    }

    private void GoToMainMenu()
    {
        Time.timeScale = 1; // Tiếp tục game
        SceneManager.LoadScene("MainMenuScene"); // Thay "MainMenuScene" bằng tên scene của menu chính
    }
}
