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
            string savedScene = PlayerPrefs.GetString("SavedScene");
            SceneManager.LoadScene(savedScene);
        }
        else
        {
            noSavedGameText.SetActive(true);
        }
    }
}
