using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource[] sfxAudioSources; // Danh sách các AudioSource cho SFX

    private void Start()
    {
        float sfxVolume = MusicManager.Instance.GetSFXVolume();
        SetSFXVolume(sfxVolume);
    }

    public void PlaySFX(int index)
    {
        if (index >= 0 && index < sfxAudioSources.Length)
        {
            sfxAudioSources[index].Play();
        }
    }

    public void SetSFXVolume(float volume)
    {
        foreach (AudioSource source in sfxAudioSources)
        {
            source.volume = volume;
        }
    }

    private void Update()
    {
        // Luôn đồng bộ âm lượng với MusicManager
        float sfxVolume = MusicManager.Instance.GetSFXVolume();
        SetSFXVolume(sfxVolume);
    }
}
