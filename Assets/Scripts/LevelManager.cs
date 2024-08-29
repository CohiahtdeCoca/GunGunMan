using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    //Level
    public GameObject[] levels;
    public Sprite enabledSprite;
    public Sprite disabledSprite;
    public Sprite enabledSpriteTurns;
    public Sprite disabledSpriteTurns;
    public GameObject levelButtonPrefab; // Đường dẫn tới prefab của bạn
    public Transform container; // GameObject chứa các button
    public int numberOfLevels = 21;
    private int currentLevel;
    private bool isCreated= false;

    //Prefabs
    public string prefabPath = "Assets/Resources/Prefabs/Levels";



    public void CreateLevelButtons()
    {
        for (int i = 1; i <= numberOfLevels; i++)
        {
            GameObject newLevelButton = Instantiate(levelButtonPrefab, container);
            newLevelButton.name = "Level " + i.ToString("00");
            newLevelButton.GetComponentInChildren<Text>().text = i.ToString("00");
            Button buttonComponent = newLevelButton.GetComponent<Button>();
            Image buttonImage = newLevelButton.GetComponent<Image>();

            int levelIndex = i - 1;

            if(i == 1){
                buttonComponent.interactable = true;
                buttonImage.sprite = enabledSprite;
            }
            else{
                buttonComponent.interactable = false;
                buttonImage.sprite = disabledSprite;
            }
            buttonComponent.onClick.AddListener(()=>{
                LoadPrefabs();

            });

        }
        
    }

    private void LoadPrefabs()
    {
        string buttonName = transform.name;
        string prefabName = buttonName.Replace("Level ", "");

        GameObject levelPrefab = Resources.Load<GameObject>(prefabPath + prefabName);
        if(levelPrefab != null){
            Instantiate(levelPrefab);
        }
        Debug.LogWarning("Prefab not found: " + prefabName);
    }
}