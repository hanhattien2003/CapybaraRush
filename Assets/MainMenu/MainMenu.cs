using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadGame()
    {
        // Sử dụng SceneManager để tải scene "Game"
        SceneManager.LoadScene("Game");
    }


    public void LoadSettingMenu()
    {
        // Sử dụng SceneManager để tải scene "Game"
        SceneManager.LoadScene("SettingMenu");
    }
    public void ExitGame()
    {
        // Thoát ứng dụng
        Application.Quit();

        // Nếu bạn đang phát trong Editor, sử dụng đoạn mã dưới để dừng ứng dụng (dành cho Unity Editor)
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void LoadInfo() 
    {
        SceneManagement.LoadScene("InfoMenu");
    }
}
