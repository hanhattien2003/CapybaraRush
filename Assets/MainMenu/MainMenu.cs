using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadGame()
    {
        // Load sang màn hình hiển thị 4 màn chơi
        SceneManager.LoadScene("Game");
    }


    public void LoadSettingMenu()
    {
        // Màn setting để chỉnh sửa cài đặt game
        SceneManager.LoadScene("SettingMenu");
    }

    public void LoadInfo() 
    {
        SceneManager.LoadScene("InfoMenu");
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

<<<<<<< HEAD
    
=======
    public void LoadInfo() 
    {
        // Màn info dùng để nói về nhóm sáng tạo game
        SceneManager.LoadScene("InfoMenu");
    }
>>>>>>> 599d0b515f0257a910627cb1a80f0cb4c837974a
}
