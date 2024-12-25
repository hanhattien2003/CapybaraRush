using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class InfoMenu : MonoBehaviour
{

[SerializeField] private GameObject infoBox;
public void BackToMainMenu()
    {
        // Tải lại scene MainMenu
        SceneManager.LoadScene("MainMenu");
    }

}
