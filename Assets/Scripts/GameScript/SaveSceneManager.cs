using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveSceneManager : MonoBehaviour
{
    public Transform playerTransform; // Tham chiếu tới nhân vật

    // Phương thức lưu scene hiện tại và vị trí nhân vật
    public void SaveCurrentScene()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        PlayerPrefs.SetString("SavedScene", currentScene);

        // Lưu vị trí nhân vật
        PlayerPrefs.SetFloat("PlayerPosX", playerTransform.position.x);
        PlayerPrefs.SetFloat("PlayerPosY", playerTransform.position.y);
        PlayerPrefs.SetFloat("PlayerPosZ", playerTransform.position.z);

        PlayerPrefs.Save();
        Debug.Log($"Scene and position saved: {currentScene} | Position: {playerTransform.position}");
    }

    // Phương thức tải scene và vị trí nhân vật đã lưu
    public void LoadSavedScene()
    {
        if (PlayerPrefs.HasKey("SavedScene"))
        {
            string savedScene = PlayerPrefs.GetString("SavedScene");
            SceneManager.sceneLoaded += OnSceneLoaded; // Đăng ký sự kiện khi scene được load
            SceneManager.LoadScene(savedScene);
            Debug.Log($"Loading saved scene: {savedScene}");
        }
        else
        {
            Debug.Log("No saved scene found.");
        }
    }

    // Gọi khi scene được load để thiết lập vị trí nhân vật
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (PlayerPrefs.HasKey("PlayerPosX") && PlayerPrefs.HasKey("PlayerPosY") && PlayerPrefs.HasKey("PlayerPosZ"))
        {
            float x = PlayerPrefs.GetFloat("PlayerPosX");
            float y = PlayerPrefs.GetFloat("PlayerPosY");
            float z = PlayerPrefs.GetFloat("PlayerPosZ");

            playerTransform.position = new Vector3(x, y, z);
            Debug.Log($"Player position loaded: {playerTransform.position}");
        }

        SceneManager.sceneLoaded -= OnSceneLoaded; // Hủy đăng ký sự kiện
    }

    // Phương thức xóa scene và vị trí nhân vật đã lưu
    public void DeleteSavedScene()
    {
        if (PlayerPrefs.HasKey("SavedScene"))
        {
            PlayerPrefs.DeleteKey("SavedScene");
            PlayerPrefs.DeleteKey("PlayerPosX");
            PlayerPrefs.DeleteKey("PlayerPosY");
            PlayerPrefs.DeleteKey("PlayerPosZ");

            PlayerPrefs.Save();
            Debug.Log("Saved scene and position deleted.");
        }
        else
        {
            Debug.Log("No saved scene or position to delete.");
        }
    }

    // Lưu scene và vị trí khi nhấn nút
    public void SaveSceneOnButtonPress()
    {
        SaveCurrentScene();
    }
}
