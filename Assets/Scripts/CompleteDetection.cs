using UnityEngine;

public class CompleteDetection : MonoBehaviour
{
    public LevelCompleteManager levelCompleteManager;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Xử lý khi nhân vật chính chạm vào mục tiêu
            levelCompleteManager.ShowLevelCompletePopup();
        }
    }
}
