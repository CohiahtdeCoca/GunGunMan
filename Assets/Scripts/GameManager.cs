using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject HomeScreen;
    public GameObject LevelScreen;
    public GameObject MainScreen;
    public GameObject PlayerScreen;

    public GameObject[] MainPopup;
    public GameObject[] MainButton;

    void Start()
    {
        ShowHomeScreen();
    }

    public void ShowHomeScreen()
    {
        HomeScreen.SetActive(true);
        LevelScreen.SetActive(false);
        MainScreen.SetActive(false);
        PlayerScreen.SetActive(false);
    }

    public void ShowLevelScreen()
    {
        HomeScreen.SetActive(false);
        LevelScreen.SetActive(true);
        MainScreen.SetActive(false);
        PlayerScreen.SetActive(false);
    }

    public void ShowMainScreen()
    {
        HomeScreen.SetActive(false);
        LevelScreen.SetActive(false);
        MainScreen.SetActive(true);
        PlayerScreen.SetActive(true);
    }
}
