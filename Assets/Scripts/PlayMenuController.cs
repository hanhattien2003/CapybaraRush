using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenuController : MonoBehaviour
{
    public GameObject noSavedGameText;
    public GameObject playMenuPanel;     // Panel PlayMenu
    public GameObject difficultPanel;   // Panel DifficultPanel

    // Hiển thị DifficultPanel khi nhấn NewGame
    public void ShowDifficultPanel()
    {
        playMenuPanel.SetActive(false);
        difficultPanel.SetActive(true);
    }

    // Đặt độ khó và bắt đầu game
    public void SetEasyDifficulty()
    {
        DifficultyManager.SetDifficulty(DifficultyManager.DifficultyLevel.Easy);
        StartNewGame();
    }

    public void SetMediumDifficulty()
    {
        DifficultyManager.SetDifficulty(DifficultyManager.DifficultyLevel.Medium);
        StartNewGame();
    }

    public void SetHardDifficulty()
    {
        DifficultyManager.SetDifficulty(DifficultyManager.DifficultyLevel.Hard);
        StartNewGame();
    }

    // Bắt đầu trò chơi mới
    private void StartNewGame()
    {
        // Xóa các dữ liệu lưu game cũ (không xóa độ khó)
        PlayerPrefs.DeleteKey("SavedScene");
        PlayerPrefs.DeleteKey("PlayerHealth");

        // Chuyển đến màn chơi chính
        SceneManager.LoadScene("Game"); 
    }

    // Tiếp tục trò chơi đã lưu
    public void ContinueGame()
{
    if (PlayerPrefs.HasKey("SavedScene"))
    {
        noSavedGameText.SetActive(false); // Ẩn thông báo nếu có dữ liệu

        string savedScene = PlayerPrefs.GetString("SavedScene");
        SceneManager.sceneLoaded += OnSceneLoaded; // Đăng ký sự kiện để khôi phục trạng thái
        SceneManager.LoadScene(savedScene);
        Debug.Log($"Continuing saved game: {savedScene}");
    }
    else
    {
        noSavedGameText.SetActive(true); // Hiển thị thông báo nếu không có dữ liệu lưu
        Debug.Log("No saved game found.");
    }
}

// Phương thức khôi phục trạng thái sau khi scene được tải
private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
{
    // Khôi phục dữ liệu (ví dụ: vị trí nhân vật, sức khỏe)
    if (PlayerPrefs.HasKey("PlayerPosX") && PlayerPrefs.HasKey("PlayerPosY") && PlayerPrefs.HasKey("PlayerPosZ"))
    {
        float x = PlayerPrefs.GetFloat("PlayerPosX");
        float y = PlayerPrefs.GetFloat("PlayerPosY");
        float z = PlayerPrefs.GetFloat("PlayerPosZ");

        GameObject player = GameObject.FindGameObjectWithTag("Player"); // Tìm nhân vật
        if (player != null)
        {
            player.transform.position = new Vector3(x, y, z); // Đặt vị trí
            Debug.Log($"Player position restored: {player.transform.position}");
        }
    }

    if (PlayerPrefs.HasKey("PlayerHealth"))
    {
        int health = PlayerPrefs.GetInt("PlayerHealth");
        Debug.Log($"Player health restored: {health}");
        // Gọi script của nhân vật để cập nhật sức khỏe nếu cần
        // player.GetComponent<PlayerHealth>().SetHealth(health);
    }

    SceneManager.sceneLoaded -= OnSceneLoaded; // Hủy đăng ký sự kiện
}

}
