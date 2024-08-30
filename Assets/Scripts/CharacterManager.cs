using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public GameObject[] playerPrefabs; // Danh sách các prefab của player
    public GameObject enemyPrefab;
    public Transform characterContainer;

    private GameObject player;
    private GameObject enemy;

    public Vector3 playerDefaultPosition = new Vector3(-8, 0, 0);
    private bool isCreated = false;

    private int selectedPlayerIndex = 0; // Chỉ số của nhân vật được chọn

    public void InitializeCharacters()
    {
        // Khởi tạo player và enemy từ prefab
        if (isCreated == false)
        {
            player = Instantiate(playerPrefabs[selectedPlayerIndex], characterContainer);
            enemy = Instantiate(enemyPrefab, characterContainer);
            ResetPositions();
            isCreated = true;
        } 
            
    }

    private void ResetPositions()
    {
        // Đặt lại vị trí của các nhân vật và địch
        if (player != null)
        {
            // Đặt vị trí mặc định cho player
            player.transform.position = playerDefaultPosition;
        }

        if (enemy != null)
        {
            float randomX = Random.Range(4f, 8f);
            Vector3 enemyPosition = new Vector3(randomX, 0, 0);
            enemy.transform.position = enemyPosition;
        }
    }

    public void SelectPlayer(int index)
    {
        if (index >= 0 && index < playerPrefabs.Length)
        {
            selectedPlayerIndex = index;
            if (player != null)
            {
                Destroy(player);
            }
            player = Instantiate(playerPrefabs[selectedPlayerIndex], characterContainer);
            ResetPositions();
        }
        else
        {
            Debug.LogWarning("Invalid player index selected: " + index);
        }
    }
}
