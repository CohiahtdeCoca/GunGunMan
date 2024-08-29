using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIManager1 : MonoBehaviour
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
        HideAllPopups();

        if (screenType == GameManager.ScreenType.Level)
        {
            FindObjectOfType<LevelManager>().CreateLevelButtons(); // Tạo các nút level khi vào màn hình chọn level
        }

        AddScreenButtonListeners(screenType);
    }

    private void AddScreenButtonListeners(GameManager.ScreenType screenType)
    {
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

    private void HideAllPopups()
    {
        popupPause.SetActive(false);
        popupComplete.SetActive(false);
        popupFail.SetActive(false);
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
        homeScreen.SetActive(false);
        levelSelectScreen.SetActive(false);
        gameScreen.SetActive(true);
        HideAllPopups();
    }

    public void AddButtonToPopup(GameObject popup)
    {
        AddButton(popup, levelButtonPrefab, "LevelButton", OnLevelButtonClicked);
        AddButton(popup, homeButtonPrefab, "HomeButton", OnHomeButtonClicked);
        AddButton(popup, soundButtonPrefab, "SoundButton", OnSoundButtonClicked);
    }

    private void AddButton(GameObject parent, GameObject prefab, string name, UnityAction action)
    {
        GameObject button = Instantiate(prefab, parent.transform);
        button.name = name;
        AddButtonComponent(button);
        UIHelper.AddButtonListener(button, name, action);
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
