using UnityEngine;
using UnityEngine.SceneManagement;
public class SettingMenu : MonoBehaviour
{
    public void BackToMainMenu()
    {
        // Tải lại scene MainMenu
        SceneManager.LoadScene("MainMenu");
    }
}
