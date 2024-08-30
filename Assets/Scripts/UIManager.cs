using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject popupPause;
    public GameObject popupComplete;
    public GameObject popupFail;
    public GameObject levelButtonPrefab;
    public GameObject homeButtonPrefab;
    public GameObject soundButtonPrefab;

    private GameManager _gameManager;

    private bool _isButtonPopupAdded = false;

    private void Awake()
    {
        // Initialize _gameManager here
        _gameManager = FindObjectOfType<GameManager>();

        if (_gameManager == null)
        {
            Debug.LogError("GameManager not found!");
        }
    }

    internal void ShowPausePopup()
    {
        HideAllsPopup();
        popupPause.SetActive(true);
        if (!_isButtonPopupAdded)
        {
            AddButtonToPopup(popupPause.transform.GetChild(2).gameObject);
            _isButtonPopupAdded = true;
        }
    }

    internal void HideAllsPopup()
    {
        popupPause.SetActive(false);
        popupComplete.SetActive(false);
        popupFail.SetActive(false);
    }

    internal void ShowCompletePopup()
    {
        HideAllsPopup();
        popupComplete.SetActive(true);
        if (!_isButtonPopupAdded)
        {
            AddButtonToPopup(popupComplete.transform.GetChild(2).gameObject);
            _isButtonPopupAdded = true;
        }
    }

    internal void ShowFailPopup()
    {
        HideAllsPopup();
        popupFail.SetActive(true);
        if (!_isButtonPopupAdded)
        {
            AddButtonToPopup(popupFail.transform.GetChild(2).gameObject);
            _isButtonPopupAdded = true;
        }
    }

    public void AddButtonToPopup(GameObject popup)
    {
        Debug.Log("Adding buttons to popup");
        AddButton(popup, levelButtonPrefab, "LevelButton", () =>
        {
            Debug.Log("LevelButton clicked");
            OnLevelButtonClicked(levelButtonPrefab);
        });
        AddButton(popup, homeButtonPrefab, "HomeButton", () =>
        {
            Debug.Log("HomeButton clicked");
            OnHomeButtonClicked(homeButtonPrefab);
        });
        AddButton(popup, soundButtonPrefab, "SoundButton", () =>
        {
            Debug.Log("SoundButton clicked");
            OnSoundButtonClicked(soundButtonPrefab);
        });
    }

    private void AddButton(GameObject parent, GameObject prefab, string name, UnityAction action)
    {
        GameObject button = Instantiate(prefab, parent.transform);
        button.name = name;
        AddButtonComponent(button);
        UIHelper.AddButtonListener(button, name, action);
        Debug.Log("Added listener to " + name);
    }

    private void AddButtonComponent(GameObject button)
    {
        if (button.GetComponent<Button>() == null)
        {
            button.AddComponent<Button>();
        }
    }


    private void OnLevelButtonClicked(GameObject button)
    {
        Debug.Log("OnLevelButtonClicked: " + button.name);
        _gameManager.ChangeScreen(GameManager.ScreenType.Level);
    }

    private void OnHomeButtonClicked(GameObject button)
    {
        Debug.Log("OnHomeButtonClicked: " + button.name);
        _gameManager.ChangeScreen(GameManager.ScreenType.Home);
    }

    private void OnSoundButtonClicked(GameObject button)
    {
        Debug.Log("OnSoundButtonClicked: " + button.name);
        Debug.Log("Sound Button Clicked!");
    }

    
}
