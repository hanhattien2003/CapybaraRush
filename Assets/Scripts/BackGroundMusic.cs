using UnityEngine;

public class BackGroundMusic : MonoBehaviour
{
    public AudioSource musicSource;  // AudioSource cho nhạc nền

    private static BackGroundMusic instance;

    void Awake()
    {
        // Nếu đã có đối tượng BackGroundMusic tồn tại, hủy bản sao mới
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Đảm bảo đối tượng này không bị hủy khi chuyển scene
        }

        // Kiểm tra lại nếu musicSource chưa được gán hoặc đã bị mất
        if (musicSource == null)
        {
            musicSource = GetComponent<AudioSource>();  // Gán lại AudioSource từ GameObject hiện tại
        }
    }

    void Start()
    {
        // Đảm bảo nhạc đang phát nếu chưa phát
        if (musicSource != null && !musicSource.isPlaying)
        {
            musicSource.Play();
        }
    }

    public void SetMusicVolume(float volume)
    {
        // Kiểm tra null trước khi thay đổi âm lượng
        if (musicSource != null)
        {
            musicSource.volume = volume;
            PlayerPrefs.SetFloat("MusicVolume", volume); // Lưu âm lượng
        }
    }

    public void SetSFXVolume(float volume)
    {
        // Nếu có SFX, bạn có thể gán âm lượng ở đây
    }
}
