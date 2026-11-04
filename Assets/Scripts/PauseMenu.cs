using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PauseMenu : MonoBehaviour
{
    public GameObject settingsPanel;
    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;

    private bool isPaused = false;

    void Start()
    {
        settingsPanel.SetActive(false);

        masterSlider.SetValueWithoutNotify(
            PlayerPrefs.GetFloat("MasterVolume", 1f));

        musicSlider.SetValueWithoutNotify(
            PlayerPrefs.GetFloat("MusicVolume", 0.3f));

        sfxSlider.SetValueWithoutNotify(
            PlayerPrefs.GetFloat("SFXVolume", 0.7f));

        masterSlider.onValueChanged.AddListener(
            AudioManager.Instance.SetMasterVolume);

        musicSlider.onValueChanged.AddListener(
            AudioManager.Instance.SetMusicVolume);

        sfxSlider.onValueChanged.AddListener(
            AudioManager.Instance.SetSFXVolume);
    }

    void Update()
    {
        if (Keyboard.current != null &&
            Keyboard.current.escapeKey.wasPressedThisFrame)
        {
            ToggleSettings();
        }
    }

    public void ToggleSettings()
    {
        isPaused = !isPaused;

        settingsPanel.SetActive(isPaused);
        Time.timeScale = isPaused ? 0f : 1f;
    }

    public void CloseSettings()
    {
        isPaused = false;
        settingsPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}