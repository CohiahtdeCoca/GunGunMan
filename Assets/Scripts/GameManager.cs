using System;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public GameObject HomeScreen;
    public GameObject LevelScreen;
    public GameObject MainScreen;
    public GameObject PlayerScreen;

    void Start()
    {
        ShowHomeScreen();
    }

    public void ShowHomeScreen()
    {
        SetActiveScreen(HomeScreen);
        AddButtonListener(HomeScreen, ShowLevelScreen);
    }

    public void ShowLevelScreen()
    {
        SetActiveScreen(LevelScreen);
        AddButtonListener(LevelScreen.transform.Find("BackButton").gameObject, ShowHomeScreen);
    }

    public void ShowMainScreen()
    {
        SetActiveScreen(MainScreen);
        PlayerScreen.SetActive(true);
        UIHelper.AddButtonListener(MainScreen, "BackButton", ShowLevelScreen);
        UIHelper.AddButtonListener(MainScreen, "PauseButton", PauseGame);
    }

    private void SetActiveScreen(GameObject screen)
    {
        HomeScreen.SetActive(screen == HomeScreen);
        LevelScreen.SetActive(screen == LevelScreen);
        MainScreen.SetActive(screen == MainScreen);
        PlayerScreen.SetActive(screen == PlayerScreen);
    }

    private void AddButtonListener(GameObject buttonObject, Action action)
    {
        Button button = buttonObject.GetComponent<Button>() ?? buttonObject.AddComponent<Button>();
        button.onClick.AddListener(() => action());
    }

    private void PauseGame()
    {
        // Add your logic to pause the game here
        Debug.Log("Game paused");
    }
}
