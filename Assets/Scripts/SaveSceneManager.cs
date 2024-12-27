using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveSceneManager : MonoBehaviour
{
    // Phương thức này được gọi khi người chơi chuyển đến một scene mới
    public void SaveCurrentScene()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("SavedScene", currentScene); // Lưu tên scene vào PlayerPrefs
        PlayerPrefs.Save(); // Đảm bảo lưu ngay lập tức
        Debug.Log("Scene saved: " + currentScene);
    }

    // Phương thức này có thể được gọi khi trò chơi kết thúc hoặc người chơi muốn quay lại
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

    // Thay đổi OnApplicationQuit() bằng một phương thức công khai để gán qua nút
    public void SaveSceneOnButtonPress()
    {
        SaveCurrentScene(); // Lưu scene khi nút được nhấn
    }
}
