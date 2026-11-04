using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject settingsPanel;

    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;

    void Start()
    {
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

    public void OpenSettings()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }
}