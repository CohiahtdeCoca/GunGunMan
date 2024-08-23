using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public GameObject[] levels;
    public GameObject[] turns;
    private GameObject currentLevel;
    public GameObject buttonPrefab;
    public Transform buttonContainer;
    public Sprite enabledSprite;
    public Sprite disabledSprite;
    public Sprite enabledSpriteTurns;
    public Sprite disabledSpriteTurns;

    public int numberOfLevels = 21;
    public int turnsPerLevel = 5; // Số lượt chơi mặc định cho mỗi level
    private int currentTurns;

    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        for (int i = 1; i <= numberOfLevels; i++)
        {
            GameObject newButton = Instantiate(buttonPrefab, buttonContainer);
            newButton.GetComponentInChildren<Text>().text = i.ToString("00");
            Button buttonComponent = newButton.GetComponent<Button>();
            Image buttonImage = newButton.GetComponent<Image>();
            int levelIndex = i - 1; // Điều chỉnh chỉ số để khớp với mảng

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

            buttonComponent.onClick.AddListener(() => LoadLevel(levelIndex));
        }
    }

    void LoadLevel(int levelIndex)
    {
        Debug.Log("Loading Level " + (levelIndex + 1));

        if (currentLevel != null)
        {
            Destroy(currentLevel);
        }

        currentLevel = Instantiate(levels[levelIndex], Vector3.zero, Quaternion.identity);
        gameManager.ShowMainScreen();
        currentTurns = turnsPerLevel;
        UnlockNextLevel(levelIndex);
    }

    public void UseTurn()
    {
        currentTurns--;

        if (currentTurns <= 0)
        {
            // Xử lý khi hết lượt chơi
            Debug.Log("Game Over");
            // Thêm logic để xử lý thua cuộc
        }
    }

    public void CompleteLevel()
    {
        Debug.Log("Level Completed");
        // Thêm logic để xử lý hoàn thành màn chơi
        // Hiển thị nút Next
    }

    void UnlockNextLevel(int currentLevelIndex)
    {
        if (currentLevelIndex + 1 < numberOfLevels)
        {
            Transform nextButton = buttonContainer.GetChild(currentLevelIndex + 1);
            Button buttonComponent = nextButton.GetComponent<Button>();
            Image buttonImage = nextButton.GetComponent<Image>();
            buttonComponent.interactable = true;
            buttonImage.sprite = enabledSprite;
        }
    }
}
