using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveSceneManager : MonoBehaviour
{
    // Phương thức lưu scene hiện tại
    public void SaveCurrentScene()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("SavedScene", currentScene); // Lưu tên scene vào PlayerPrefs
        PlayerPrefs.Save(); // Đảm bảo lưu ngay lập tức
        Debug.Log("Scene saved: " + currentScene);
    }

    // Phương thức tải scene đã lưu
    public void LoadSavedScene()
    {
        if (PlayerPrefs.HasKey("SavedScene"))
        {
            string savedScene = PlayerPrefs.GetString("SavedScene");
            SceneManager.LoadScene(savedScene); // Chuyển đến scene đã lưu
            Debug.Log("Loading saved scene: " + savedScene);
        }
        else
        {
            Debug.Log("No saved scene found.");
        }
    }

    // Phương thức xóa scene đã lưu
    public void DeleteSavedScene()
    {
        if (PlayerPrefs.HasKey("SavedScene"))
        {
            PlayerPrefs.DeleteKey("SavedScene"); // Xóa key "SavedScene" khỏi PlayerPrefs
            PlayerPrefs.Save(); // Lưu lại thay đổi
            Debug.Log("Saved scene deleted.");
        }
        else
        {
            Debug.Log("No saved scene to delete.");
        }
    }

    // Lưu scene khi nhấn nút
    public void SaveSceneOnButtonPress()
    {
        SaveCurrentScene(); // Lưu scene khi nút được nhấn
    }
}
