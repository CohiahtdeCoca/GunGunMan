using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    //Level
    public Sprite enabledSprite;
    public Sprite disabledSprite;
    public Sprite enabledSpriteTurns;
    public Sprite disabledSpriteTurns;
    public GameObject levelButtonPrefab; // Đường dẫn tới prefab của bạn
    public Transform container; // GameObject chứa các button
    public int numberOfLevels = 21;
    private int currentLevel;
    private bool isCreated= false;
    [SerializeField]  private GameManager _gameManager;
    //Prefabs
    private void Awake()
    {
        // Initialize _gameManager here
        _gameManager = FindObjectOfType<GameManager>();

        if (_gameManager == null)
        {
            Debug.LogError("GameManager not found!");
        }
    }

    public void CreateLevelButtons()
    {
        for (int i = 1; i <= numberOfLevels; i++)
        {
            GameObject newLevelButton = Instantiate(levelButtonPrefab, container);
            newLevelButton.name = "Level " + i.ToString("00");
            newLevelButton.GetComponentInChildren<Text>().text = i.ToString("00");
            Button buttonComponent = newLevelButton.GetComponent<Button>();
            Image buttonImage = newLevelButton.GetComponent<Image>();

            int levelIndex = i;

            if (i == 1)
            {
                buttonComponent.interactable = true;
                buttonImage.sprite = enabledSprite;
            }
            else
            {
                buttonComponent.interactable = false;
                buttonImage.sprite = disabledSprite;
            }

            buttonComponent.onClick.AddListener(() =>
            {
                if (_gameManager != null)
                {
                    _gameManager.ChangeScreen(GameManager.ScreenType.Game);
                }
                else
                {
                    Debug.LogError("_gameManager is null!");
                }
            });
        }
    }
}