using UnityEngine;
using UnityEngine.UI;

// public class LevelManager : MonoBehaviour
// {
//     public GameObject[] levels;
//     public GameObject[] turns;
//     private GameObject currentLevel;
//     public GameObject buttonPrefab;
//     public Transform buttonContainer;
//     public Sprite enabledSprite;
//     public Sprite disabledSprite;
//     public Sprite enabledSpriteTurns;
//     public Sprite disabledSpriteTurns;

//     public int numberOfLevels = 21;
//     public int turnsPerLevel = 5; // Số lượt chơi mặc định cho mỗi level
//     private int currentTurns;

//     private GameManager gameManager;

//     // Default position for the first character
//     public Vector3 character1DefaultPosition = new Vector3(-30, 0, 0);

//     public GameObject character1;
//     public GameObject character2;

//     void Start()
//     {
//         gameManager = FindObjectOfType<GameManager>();

//         // Set default position for the first character
//         character1.transform.position = character1DefaultPosition;

//         for (int i = 1; i <= numberOfLevels; i++)
//         {
//             GameObject newButton = Instantiate(buttonPrefab, buttonContainer);
//             newButton.GetComponentInChildren<Text>().text = i.ToString("00");
//             Button buttonComponent = newButton.GetComponent<Button>();
//             Image buttonImage = newButton.GetComponent<Image>();
//             int levelIndex = i - 1; // Điều chỉnh chỉ số để khớp với mảng

//             if (i == 1)
//             {
//                 buttonComponent.interactable = true;
//                 buttonImage.sprite = enabledSprite;
//             }
//             else
//             {
//                 buttonComponent.interactable = false;
//                 buttonImage.sprite = disabledSprite;
//             }

//             buttonComponent.onClick.AddListener(() => LoadLevel(levelIndex));
//         }
//     }

//     void LoadLevel(int levelIndex)
//     {
//         Debug.Log("Loading Level " + (levelIndex + 1));

//         if (currentLevel != null)
//         {
//             Destroy(currentLevel);
//         }

//         currentLevel = Instantiate(levels[levelIndex], Vector3.zero, Quaternion.identity);
//         currentLevel.transform.SetParent(gameManager.MainScreen.transform.Find("Levels").transform);
//         currentLevel.transform.localScale = Vector3.one;

//         // Set default position for the first character
//         character1.transform.position = character1DefaultPosition;

//         // Spawn the second character with a random x position between 10 and 30
//         float randomX = Random.Range(10f, 30f);
//         Vector3 character2Position = new Vector3(randomX, 0, 0);
//         character2.transform.position = character2Position;

//         gameManager.ShowMainScreen();
//         currentTurns = turnsPerLevel;
//         UnlockNextLevel(levelIndex);
//     }

//     public void UseTurn()
//     {
//         currentTurns--;

//         if (currentTurns <= 0)
//         {
//             // Xử lý khi hết lượt chơi
//             Debug.Log("Game Over");
//             // Thêm logic để xử lý thua cuộc
//         }
//     }

//     public void CompleteLevel()
//     {
//         Debug.Log("Level Completed");
//         // Thêm logic để xử lý hoàn thành màn chơi
//         // Hiển thị nút Next
//     }

//     void UnlockNextLevel(int currentLevelIndex)
//     {
//         if (currentLevelIndex + 1 < numberOfLevels)
//         {
//             Transform nextButton = buttonContainer.GetChild(currentLevelIndex + 1);
//             Button buttonComponent = nextButton.GetComponent<Button>();
//             Image buttonImage = nextButton.GetComponent<Image>();
//             buttonComponent.interactable = true;
//             buttonImage.sprite = enabledSprite;
//         }
//     }
// }

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

    // Default position for the first character
    public Vector3 character1DefaultPosition = new Vector3(-30, 0, 0);

    public GameObject character1;
    public GameObject character2;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        // Set default position for the first character
        character1.transform.position = character1DefaultPosition;

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
        currentLevel.transform.SetParent(gameManager.MainScreen.transform.Find("Levels").transform);
        currentLevel.transform.localScale = Vector3.one;

        // Set default position for the first character
        character1.transform.position = character1DefaultPosition;

        // Spawn the second character with a random x position between 10 and 30
        float randomX = Random.Range(10f, 30f);
        Vector3 character2Position = new Vector3(randomX, 0, 0);
        character2.transform.position = character2Position;

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
