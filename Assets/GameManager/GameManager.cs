using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel; // Tham chiếu đến Game Over Panel trong Inspector
    [SerializeField] public GameObject player;
    // Hàm này sẽ được gọi khi game kết thúc

    public void GameOver()
    {
        if (player != null)
        {
            player.SetActive(false);  // Tắt đối tượng Player khi game over
        }
        gameOverPanel.SetActive(true); // Kích hoạt panel Game Over
    }

    // Hàm chơi lại game (Reload lại scene hiện tại)
    public void RestartGame()
    {
        // Reload lại scene hiện tại
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Hàm quay lại Main Menu
    public void GoToMainMenu()
    {
        // Quay lại scene Main Menu
        SceneManager.LoadScene("MainMenu"); // Đảm bảo rằng tên scene "MainMenu" chính xác
    }
}
