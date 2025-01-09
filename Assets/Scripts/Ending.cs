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
            PlayerPrefs.DeleteKey("SavedScene");
            PlayerPrefs.DeleteKey("PlayerPosX");
            PlayerPrefs.DeleteKey("PlayerPosY");
            PlayerPrefs.DeleteKey("PlayerPosZ");

            PlayerPrefs.Save();
            Debug.Log("Saved scene and position deleted.");
        }
    }
    
    void Start()
    {
        // Xóa đối tượng này khi scene mới bắt đầu
        Destroy(GameObject.Find("BackgroundMusic"));
    }

}
