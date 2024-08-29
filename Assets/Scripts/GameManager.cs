using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject HomeScreen;
    public GameObject LevelScreen;
    public GameObject GameScreen;
    public enum ScreenType { Home, Level, Game }
    private bool isCreated = false;
    private bool isPaused = false;

    [SerializeField] private UIManager _uiManager;
    [SerializeField] private LevelManager _levelManager;
    // [SerializeField] private CharacterManager _characterManager;
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
        UIHelper.AddButtonListener(HomeScreen, "StartButton", ()=> ChangeScreen(ScreenType.Level));


    }

    private void LoadLevelScreen()
    {
        // Code để tải màn hình chọn cấp độ
        LevelScreen.SetActive(true);
        if(isCreated==false){
            _levelManager.CreateLevelButtons();
            
            isCreated = true;

        }


        UIHelper.AddButtonListener(LevelScreen, "BackButton", () => ChangeScreen(ScreenType.Home));


    }

    private void LoadGameScreen()
    {
        // Code để tải màn hình chơi game
        GameScreen.SetActive(true);
    }



    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f;
        _uiManager.ShowPausePopup();
    }

    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f;
        _uiManager.HidePausePopup();
    }

    public void CompleteLevel()
    {
        Time.timeScale = 0f;
        _uiManager.ShowCompletePopup();
        
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