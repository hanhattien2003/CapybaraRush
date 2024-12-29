using UnityEngine;
using UnityEngine.SceneManagement;
public class Ending : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     public void GetBackToMainMenu()
    {
        // Tải lại scene MainMenu
        SceneManager.LoadScene("MainMenu");
        if (PlayerPrefs.HasKey("SavedScene"))
        {
            PlayerPrefs.DeleteKey("SavedScene"); // Xóa key "SavedScene" khỏi PlayerPrefs
            PlayerPrefs.Save(); // Lưu lại thay đổi
            Debug.Log("Saved scene deleted.");
        }
    }
    
    void Start()
    {
        // Xóa đối tượng này khi scene mới bắt đầu
        Destroy(GameObject.Find("BackgroundMusic"));
    }

}
