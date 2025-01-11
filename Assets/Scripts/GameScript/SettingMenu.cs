using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SettingMenu : MonoBehaviour
{
    public Slider musicSlider;  // Slider điều chỉnh âm lượng nhạc
    public Slider sfxSlider;    // Slider điều chỉnh âm lượng SFX
    private MusicManager musicManager; // Tham chiếu tới MusicManager

    private void Start()
    {
        // Tìm MusicManager trong scene (nếu đã tồn tại)
        musicManager = Object.FindFirstObjectByType<MusicManager>();

        if (musicManager != null)
        {
            // Gán giá trị âm lượng cho các slider từ PlayerPrefs khi khởi động
            musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);  // Giá trị mặc định là 0.75f
            sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume", 0.75f);  // Giá trị mặc định là 0.75f

            // Gán sự kiện cho slider khi giá trị thay đổi
            musicSlider.onValueChanged.AddListener(delegate { 
                musicManager.SetMusicVolume(musicSlider.value); 
                PlayerPrefs.SetFloat("MusicVolume", musicSlider.value); // Lưu âm lượng nhạc
            });

            sfxSlider.onValueChanged.AddListener(delegate { 
                musicManager.SetSFXVolume(sfxSlider.value);
                PlayerPrefs.SetFloat("SFXVolume", sfxSlider.value); // Lưu âm lượng SFX
            });
        }
        else
        {
            Debug.LogError("MusicManager không được tìm thấy trong scene.");
        }
    }

    // Lưu âm lượng khi thoát setting
    public void Save()
    {
        PlayerPrefs.Save(); // Lưu tất cả các thay đổi trong PlayerPrefs
    }
}
