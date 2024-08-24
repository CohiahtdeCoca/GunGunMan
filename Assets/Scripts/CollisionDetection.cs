using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Xử lý khi va chạm với kẻ địch
            Debug.Log("You Win!");
            // Thêm các hành động khác như chuyển sang màn hình chiến thắng
        }
    }
}
