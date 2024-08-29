using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject tapToPlayButtonObject; // GameObject cho nút "Tap to Play"
    public GameObject levelSelectPanelObject; // GameObject cho Panel chọn level
    public GameObject backButtonObject; // GameObject cho nút "Back"

    void Start()
    {
        UIHelper.AddButtonListener(tapToPlayButtonObject, "TapToPlayButton", OnTapToPlayButtonPressed);
        UIHelper.AddButtonListener(backButtonObject, "BackButton", OnBackButtonPressed);

        // Thêm Button cho từng level
        for (int i = 1; i <= 21; i++)
        {
            string buttonName = "Level" + i + "Button";
            UIHelper.AddButtonListener(levelSelectPanelObject, buttonName, () => LoadLevel(i));
            UIHelper.SetButtonText(levelSelectPanelObject, buttonName, "Level " + i);
        }

        ShowMainMenu();
    }

    void ShowMainMenu()
    {
        tapToPlayButtonObject.SetActive(true);
        levelSelectPanelObject.SetActive(false);
    }

    void ShowLevelSelect()
    {
        tapToPlayButtonObject.SetActive(false);
        levelSelectPanelObject.SetActive(true);
    }

    void OnTapToPlayButtonPressed()
    {
        ShowLevelSelect();
    }

    void OnBackButtonPressed()
    {
        ShowMainMenu();
    }

    void LoadLevel(int level)
    {
        Debug.Log("Loading Level " + level);
        // Thêm mã để tải level tương ứng
    }

    internal void ShowScreen(GameManager.ScreenType screenType)
    {
        throw new NotImplementedException();
    }

    internal void ShowPausePopup()
    {
        throw new NotImplementedException();
    }

    internal void HidePausePopup()
    {
        throw new NotImplementedException();
    }

    internal void ShowCompletePopup()
    {
        throw new NotImplementedException();
    }

    internal void ShowFailPopup()
    {
        throw new NotImplementedException();
    }

    internal void ShowGameScreen()
    {
        throw new NotImplementedException();
    }
}
