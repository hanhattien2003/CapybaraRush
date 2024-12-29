using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource musicSource;  // AudioSource cho nhạc nền
    public AudioSource sfxSource;    // AudioSource cho âm thanh hiệu ứng

    private static MusicManager instance;  // Biến static giữ đối tượng duy nhất của MusicManager

    private void Awake()
    {
        // Kiểm tra xem có bản sao nào của MusicManager không
        if (instance != null)
        {
            Destroy(gameObject);  // Nếu đã có, hủy bản sao mới tạo
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Đảm bảo không bị xóa khi chuyển scene
        }

        // Kiểm tra nếu musicSource chưa được gán
        if (musicSource == null)
        {
            musicSource = GetComponent<AudioSource>();
        }
    }

    private void Start()
    {
        // Kiểm tra xem nhạc nền đã được phát chưa, nếu chưa thì phát
        if (musicSource != null && !musicSource.isPlaying)
        {
            musicSource.Play();
        }

        // Lấy âm lượng từ PlayerPrefs khi game bắt đầu
        float musicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.75f);  // Giá trị mặc định
        SetMusicVolume(musicVolume);
    }

    public void SetMusicVolume(float volume)
    {
        if (musicSource != null)
        {
            musicSource.volume = volume;
            PlayerPrefs.SetFloat("MusicVolume", volume);  // Lưu âm lượng vào PlayerPrefs
            PlayerPrefs.Save();  // Lưu ngay lập tức
        }
    }

    public void SetSFXVolume(float volume)
    {
        if (sfxSource != null)
        {
            sfxSource.volume = volume;
             PlayerPrefs.SetFloat("SFXVolume", volume);  // Lưu âm lượng vào PlayerPrefs
            PlayerPrefs.Save();  // Lưu ngay lập tức
        }
    }
}
