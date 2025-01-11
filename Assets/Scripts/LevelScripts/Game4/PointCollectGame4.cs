using UnityEngine;

public class PointCollect : MonoBehaviour
{
    public GameObject door; // Cửa sẽ ẩn khi đủ điểm
    private int pointsCollected = 0; // Biến lưu số điểm đã thu thập

    void Start()
    {
        // Đảm bảo cửa xuất hiện khi bắt đầu
        door.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        // Kiểm tra nếu player chạm vào một object có tag "points"
        if (other.CompareTag("points"))
        {
            other.gameObject.SetActive(false); // Ẩn Point đã thu thập
            pointsCollected++; // Tăng số điểm đã thu thập

            // Nếu đủ điểm, ẩn cửa
            if (pointsCollected == GameObject.FindGameObjectsWithTag("points").Length)
            {
                door.SetActive(false);
            }
        }
    }
}
