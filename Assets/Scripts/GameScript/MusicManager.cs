using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource musicSource;  // AudioSource cho nhạc nền
    private static MusicManager instance;

    private float musicVolume = 0.75f;
    private float sfxVolume = 0.75f;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        if (musicSource == null)
        {
            musicSource = GetComponent<AudioSource>();
        }
    }

    private void Start()
    {
        musicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
        sfxVolume = PlayerPrefs.GetFloat("SFXVolume", 0.75f);

        SetMusicVolume(musicVolume);
    }

    public static MusicManager Instance
    {
        get
        {
            if (instance == null)
            {
                Debug.LogError("MusicManager chưa được khởi tạo!");
            }
            return instance;
        }
    }

    public void SetMusicVolume(float volume)
    {
        musicVolume = volume;
        if (musicSource != null)
        {
            musicSource.volume = musicVolume;
        }
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
        PlayerPrefs.Save();
    }

    public void SetSFXVolume(float volume)
    {
        sfxVolume = volume;
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
        PlayerPrefs.Save();
    }

    public float GetSFXVolume()
    {
        return sfxVolume;
    }
}
