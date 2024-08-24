using UnityEngine;

public class TouchDragAndThrow : MonoBehaviour
{
    private Vector2 startPos;
    private Vector2 endPos;
    private bool isDragging = false;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                startPos = Camera.main.ScreenToWorldPoint(touch.position);
                isDragging = true;
            }

            if (touch.phase == TouchPhase.Ended && isDragging)
            {
                endPos = Camera.main.ScreenToWorldPoint(touch.position);
                Vector2 throwDirection = endPos - startPos;
                GetComponent<Rigidbody2D>().AddForce(throwDirection * 500); // Điều chỉnh lực ném
                isDragging = false;
            }
        }
    }
}
