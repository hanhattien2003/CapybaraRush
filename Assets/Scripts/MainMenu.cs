using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Tham chiếu đến InfoBox và các nút
    public GameObject infoBox;
    public Button infoButton;
    public Button closeButton;

    void Start()
    {
        // Đảm bảo InfoBox bị ẩn khi bắt đầu
        if (infoBox != null)
        {
            infoBox.SetActive(false);
        }

        // Gắn sự kiện cho các nút
        if (infoButton != null)
        {
            infoButton.onClick.AddListener(ShowInfoBox);
        }

        if (closeButton != null)
        {
            closeButton.onClick.AddListener(HideInfoBox);
        }
    }

    public void ShowInfoBox()
    {
        if (infoBox != null)
        {
            infoBox.SetActive(true);
        }
    }

    public void HideInfoBox()
    {
        if (infoBox != null)
        {
            infoBox.SetActive(false);
        }
    }

    public void LoadGame()
    {
        // Load sang màn hình hiển thị game
        SceneManager.LoadScene("Game");
    }

    public void LoadSettingMenu()
    {
        // Màn setting để chỉnh sửa cài đặt game
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
}