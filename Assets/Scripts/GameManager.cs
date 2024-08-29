using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public enum ScreenType { Home, Level, Main, Player }
    private bool isPaused = false;

    [SerializeField] private UIManager _uiManager;
    // [SerializeField] private CharacterManager _characterManager;
    [SerializeField] private TurnManager _turnManager;

    private void Start()
    {
        ShowScreen(ScreenType.Home);
    }

    public void ShowScreen(ScreenType screenType)
    {
        _uiManager.ShowScreen(screenType);

        if (screenType == ScreenType.Main)
        {
            // _characterManager.InitializeCharacters();
            // _characterManager.ShowCharacters(true);
        }
        else
        {
            // _characterManager.ShowCharacters(false);
        }
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
        FindObjectOfType<LevelManager>().UnlockNextLevel(); // Mở khóa level tiếp theo
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
        _uiManager.ShowGameScreen();
    }

    public void ReplayLevel()
    {
        Time.timeScale = 1f;
        ResetLevel();
        _uiManager.ShowGameScreen();
    }

    private void ResetLevel()
    {
        // _characterManager.ResetPositions();
        _turnManager.ResetTurns();
        // Reset any other necessary game state here
    }
}