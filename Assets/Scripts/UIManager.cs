using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject levelButtonPrefab;
    public GameObject homeButtonPrefab;
    public GameObject soundButtonPrefab;

    public GameObject popupPause;
    public GameObject popupComplete;
    public GameObject popupFail;

    private GameManager _gameManager;

    public GameObject homeScreen;
    public GameObject levelSelectScreen;
    public GameObject gameScreen;
   

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
    }

    public void ShowScreen(GameManager.ScreenType screenType)
    {
        homeScreen.SetActive(screenType == GameManager.ScreenType.Home);
        levelSelectScreen.SetActive(screenType == GameManager.ScreenType.Level);
        gameScreen.SetActive(screenType == GameManager.ScreenType.Main);
        popupPause.SetActive(false);
        popupComplete.SetActive(false);
        popupFail.SetActive(false);

        switch (screenType)
        {
            case GameManager.ScreenType.Home:
                UIHelper.AddButtonListener(homeScreen, "StartButton", () => ShowScreen(GameManager.ScreenType.Level));
                break;
            case GameManager.ScreenType.Level:
                UIHelper.AddButtonListener(levelSelectScreen, "BackButton", () => ShowScreen(GameManager.ScreenType.Home));
                break;
            case GameManager.ScreenType.Main:
                UIHelper.AddButtonListener(gameScreen, "BackButton", () => ShowScreen(GameManager.ScreenType.Level));
                UIHelper.AddButtonListener(gameScreen, "PauseButton", _gameManager.PauseGame);
                break;
        }
    }

    public void ShowPausePopup()
    {
        popupPause.SetActive(true);
    }

    public void HidePausePopup()
    {
        popupPause.SetActive(false);
    }

    public void ShowCompletePopup()
    {
        popupComplete.SetActive(true);
    }

    public void ShowFailPopup()
    {
        popupFail.SetActive(true);
    }

    public void ShowGameScreen()
    {
        ShowScreen(GameManager.ScreenType.Main);
    }

    public void AddButtonToPopup(GameObject popup)
    {
        GameObject levelButton = Instantiate(levelButtonPrefab, popup.transform);
        levelButton.name = "LevelButton";
        AddButtonComponent(levelButton);
        UIHelper.AddButtonListener(levelButton, "LevelButton", OnLevelButtonClicked);

        GameObject homeButton = Instantiate(homeButtonPrefab, popup.transform);
        homeButton.name = "HomeButton";
        AddButtonComponent(homeButton);
        UIHelper.AddButtonListener(homeButton, "HomeButton", OnHomeButtonClicked);

        GameObject soundButton = Instantiate(soundButtonPrefab, popup.transform);
        soundButton.name = "SoundButton";
        AddButtonComponent(soundButton);
        UIHelper.AddButtonListener(soundButton, "SoundButton", OnSoundButtonClicked);
    }

    private void OnLevelButtonClicked()
    {
        _gameManager.ShowScreen(GameManager.ScreenType.Level);
    }

    private void OnHomeButtonClicked()
    {
        _gameManager.ShowScreen(GameManager.ScreenType.Home);
    }

    private void OnSoundButtonClicked()
    {
        Debug.Log("Sound Button Clicked!");
    }

    private void AddButtonComponent(GameObject button)
    {
        if (button.GetComponent<Button>() == null)
        {
            button.AddComponent<Button>();
        }
    }
}
