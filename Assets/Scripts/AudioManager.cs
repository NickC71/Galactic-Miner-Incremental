
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource sfxSource;

    [Header("Sound Effects")]
    public AudioClip laserSound;
    public AudioClip impactSound;
    public AudioClip oreBreakSound;
    public AudioClip upgradeSound;

    [Header("Background Music")]
    public AudioClip backgroundMusic;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        SetMasterVolume(PlayerPrefs.GetFloat("MasterVolume", 1f));
        SetMusicVolume(PlayerPrefs.GetFloat("MusicVolume", 0.3f));
        SetSFXVolume(PlayerPrefs.GetFloat("SFXVolume", 0.7f));

        if (backgroundMusic != null)
        {
            musicSource.clip = backgroundMusic;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    public void PlayLaser()
    {
        if (laserSound != null)
            sfxSource.PlayOneShot(laserSound);
    }

    public void PlayImpact()
    {
        if (impactSound != null)
            sfxSource.PlayOneShot(impactSound);
    }

    public void PlayOreBreak()
    {
        if (oreBreakSound != null)
            sfxSource.PlayOneShot(oreBreakSound);
    }

    public void PlayUpgrade()
    {
        if (upgradeSound != null)
            sfxSource.PlayOneShot(upgradeSound);
    }
    public void SetMasterVolume(float volume)
    {
        AudioListener.volume = volume;
        PlayerPrefs.SetFloat("MasterVolume", volume);
        PlayerPrefs.Save();
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
        PlayerPrefs.SetFloat("MusicVolume", volume);
        PlayerPrefs.Save();
    }

    public void SetSFXVolume(float volume)
    {
        sfxSource.volume = volume;
        PlayerPrefs.SetFloat("SFXVolume", volume);
        PlayerPrefs.Save();
    }
}
