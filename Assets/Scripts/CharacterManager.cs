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

    private Rigidbody2D rb;
    public LineRenderer lr;

    public float dragLimit = 1f;
    public float forceToAdd = 2f;

    private Camera cam;
    private bool isDragging;

    private bool isGameScreenReady = false;  

    Vector3 MousePosition
    {
        get
        {
            Vector3 pos = cam.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 0f;
            return pos;
        }
    }


    private void Update()
    {
        if (isGameScreenReady)
        {
            if (Input.GetMouseButtonDown(0) && !isDragging)
            {
                DragStart();
            }
            if (isDragging)
            {
                Drag();
            }
            if (Input.GetMouseButtonUp(0) && isDragging)
            {
                DragEnd();
            }
        }
        else{
            lr.enabled = false;
        }
    }



    public void InitializeCharacters()
    {
        // Khởi tạo player và enemy từ prefab
        if (isCreated == false)
        {
            player = Instantiate(playerPrefabs[selectedPlayerIndex], characterContainer);
            enemy = Instantiate(enemyPrefab, characterContainer);
            ResetPositions();
            player.name = playerPrefabs[selectedPlayerIndex].name;
            enemy.name = enemyPrefab.name;
            isCreated = true;

            cam = Camera.main;
            lr.positionCount = 2;
            lr.SetPosition(0, Vector2.zero);
            lr.SetPosition(1, Vector2.zero);
            lr.enabled = false;
            rb = player.GetComponent<Rigidbody2D>();

            isGameScreenReady = true;
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

    void Drag()
    {
        Vector3 startPos = lr.GetPosition(0);
        Vector3 currentPos = MousePosition;

        Vector3 distance = currentPos - startPos;

        if (distance.magnitude <= dragLimit)
        {
            lr.SetPosition(1, currentPos);
        }
        else
        {
            Vector3 limitVector = startPos + (distance.normalized * dragLimit);
            lr.SetPosition(1, limitVector);
        }
    }

    void DragStart()
    {
        lr.enabled = true;
        isDragging = true;
        lr.SetPosition(0, MousePosition);
    }

    void DragEnd()
    {
        isDragging = false;
        lr.enabled = false;

        Vector3 startPos = lr.GetPosition(0);
        Vector3 currentPos = lr.GetPosition(1);

        Vector3 distance = currentPos - startPos;
        Vector3 finalForce = distance * forceToAdd;

        rb.AddForce(-finalForce, ForceMode2D.Impulse);
    }

    internal void SetGameScreenReady(bool isReady)
    {
        isGameScreenReady = isReady;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Kiểm tra va chạm với đối tượng có tag "Enemy"
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Va chạm với Enemy!");
            // Xử lý logic khi va chạm với Enemy
        }
    }
}
