using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject HomeScreen;
    public GameObject LevelScreen;
    public GameObject GameScreen;

    public GameObject levelsContainer;
    public enum ScreenType { Home, Level, Game }
    private bool isCreated = false;
    private bool isPaused = false;
    public string prefabPath = "Assets/Resources/Prefabs/Levels";
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private CharacterManager _characterManager;
    // [SerializeField] private TurnManager _turnManager;

    private void Start()
    {
        ChangeScreen(ScreenType.Home);
    }

    public void ChangeScreen(ScreenType screenType)
    {
        HomeScreen.SetActive(false);
        LevelScreen.SetActive(false);
        GameScreen.SetActive(false);
        _uiManager.HideAllsPopup();

        switch (screenType)
        {
            case ScreenType.Home:
                // Tải màn hình chính
                LoadHomeScreen();
                break;
            case ScreenType.Level:
                // Tải màn hình chọn cấp độ
                LoadLevelScreen();
                break;
            case ScreenType.Game:
                // Tải màn hình chơi game
                LoadGameScreen();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(screenType), screenType, null);
        }
    }

    private void LoadHomeScreen()
    {
        HomeScreen.SetActive(true);
        UIHelper.AddButtonListener(HomeScreen, "StartButton", () => ChangeScreen(ScreenType.Level));
    }

    private void LoadLevelScreen()
    {
        // Code để tải màn hình chọn cấp độ
        LevelScreen.SetActive(true);
        if (!isCreated)
        {
            if (_levelManager != null)
            {
                _levelManager.CreateLevelButtons();
                isCreated = true;
            }
            else
            {
                Debug.LogError("_levelManager is not assigned!");
            }
        }

        UIHelper.AddButtonListener(LevelScreen, "BackButton", () => ChangeScreen(ScreenType.Home));
    }

    private void LoadGameScreen()
    {
        // Code để tải màn hình chơi game
        GameScreen.SetActive(true);
        Debug.Log("111");
        int currentLevel = PlayerPrefs.GetInt("currentLevel", 1);
        string prefabName = currentLevel.ToString("00"); // Sử dụng tên từ "01" đến "21"
        GameObject levelPrefab = Resources.Load<GameObject>(prefabPath + "/" + prefabName);

        if (levelPrefab != null)
        {
            GameObject instantiatedLevel = Instantiate(levelPrefab, levelsContainer.transform);
            
        }
        else
        {
            Debug.LogWarning("Prefab not found: " + prefabName);
        }
        _characterManager.InitializeCharacters();
        UIHelper.AddButtonListener(GameScreen,"BackButton", () =>ChangeScreen(ScreenType.Level));
        UIHelper.AddButtonListener(GameScreen,"PauseButton", () =>{
            _uiManager.ShowPausePopup();
        });
    }



    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        if (_uiManager != null)
        {
            _uiManager.ShowPausePopup();
        }
        else
        {
            Debug.LogError("_uiManager is not assigned!");
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        if (_uiManager != null)
        {
            _uiManager.HideAllsPopup();
        }
        else
        {
            Debug.LogError("_uiManager is not assigned!");
        }
    }

    public void CompleteLevel()
    {
        Time.timeScale = 0f;
        int currentLevel = PlayerPrefs.GetInt("currentLevel", 1);
        if (currentLevel >= PlayerPrefs.GetInt("levelReached", 1))
        {
            PlayerPrefs.SetInt("levelReached", currentLevel + 1);
        }
        if (_uiManager != null)
        {
            _uiManager.ShowCompletePopup();
        }
        else
        {
            Debug.LogError("_uiManager is not assigned!");
        }
    }
    public void FailLevel()
    {
        Time.timeScale = 0f;
        _uiManager.ShowFailPopup();
    }

    public void NextLevel()
    {
        Time.timeScale = 1f;
        ResetLevel();

    }

    public void ReplayLevel()
    {
        Time.timeScale = 1f;
        ResetLevel();
    }

    private void ResetLevel()
    {
        // _characterManager.ResetPositions();
        // _turnManager.ResetTurns();
        // Reset any other necessary game state here
    }

}