using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishPoint : MonoBehaviour
{
  // Tên scene mà bạn muốn chuyển đến
    public string sceneName = "Scene2"; // Thay thế bằng tên scene bạn muốn

    // Hàm này sẽ được gọi khi đối tượng trigger được kích hoạt
    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Kiểm tra xem đối tượng trigger có phải là Player không
        if (collider.CompareTag("Player"))
        {
            // Chuyển sang scene mới
            SceneManager.LoadScene(sceneName);
        }
    }
}
