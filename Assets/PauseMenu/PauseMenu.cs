using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
   public void GetBackToMainMenu()
    {
        // Sử dụng SceneManager để tải scene "Game"
        SceneManager.LoadScene("MainMenu");
    }
}
