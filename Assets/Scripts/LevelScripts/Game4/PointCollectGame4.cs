using UnityEngine;

public class PointCollectGame4 : MonoBehaviour
{
    public GameObject door; // Cửa sẽ ẩn khi đủ điểm
    private int pointsCollected = 0; // Biến lưu số điểm đã thu thập
    public int pointsRequired = 5; // Số điểm cần để mở cửa

    void Start()
    {
        // Đảm bảo cửa xuất hiện khi bắt đầu
        door.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Points"))
        {
            Debug.Log("Hit point");
            pointsCollected++;
            Destroy(collision.gameObject); // Hủy vật "Points"

            // Kiểm tra nếu đủ điểm để mở cửa
            if (pointsCollected >= pointsRequired)
            {
                Destroy(door); // Hủy cửa để mở đường
                Debug.Log("Door is destroyed!");
            }
        }
    }
}
