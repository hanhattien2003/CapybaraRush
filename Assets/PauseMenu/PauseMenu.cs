using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Tham chiếu đến game object của Pause Menu
    public GameObject pauseMenuObject;

    // Hàm để tạm dừng trò chơi và hiển thị menu pause
    public void Pause()
    {


        
        // Tạm dừng game (đặt Time.timeScale = 0)
        Time.timeScale = 0;
    }

    // Hàm để quay lại Main Menu
    public void GetBackToMainMenu()
    {
        // Tải lại scene MainMenu
        SceneManager.LoadScene("MainMenu");

        // Bật lại thời gian bình thường
        Time.timeScale = 1;
    }

    // Hàm để tiếp tục trò chơi và ẩn menu pause
    public void Resume()
    {


        // Đặt lại thời gian bình thường
        Time.timeScale = 1;
    }
}
