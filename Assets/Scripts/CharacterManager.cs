using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;
    public Transform characterContainer;

    private GameObject player;
    private GameObject enemy;

    public Vector3 playerDefaultPosition = new Vector3(-30, 0, 0);

    public void InitializeCharacters()
    {
        // Khởi tạo player và enemy từ prefab
        player = Instantiate(playerPrefab, characterContainer);
        enemy = Instantiate(enemyPrefab, characterContainer);

        ResetPositions();
    }

    public void ResetPositions()
    {
        // Đặt vị trí mặc định cho player
        player.transform.position = playerDefaultPosition;

        // Đặt vị trí ngẫu nhiên cho enemy
        float randomX = Random.Range(10f, 30f);
        Vector3 enemyPosition = new Vector3(randomX, 0, 0);
        enemy.transform.position = enemyPosition;
    }

    public void ShowCharacters(bool show)
    {
        characterContainer.gameObject.SetActive(show);
    }
}
