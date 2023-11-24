using UnityEngine;
using UnityEngine.UI;

public class SceneSliderController : MonoBehaviour
{
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;
    
    private void Start() {
        if (musicVolumeSlider != null) {
            // Load the saved music volume from PlayerPrefs
            float savedMusicVolume = PlayerPrefs.GetFloat(AudioManager.MusicPlayerPrefsKey, 1f);
            musicVolumeSlider.value = savedMusicVolume;
            musicVolumeSlider.onValueChanged.AddListener(OnMusicSliderValueChanged);
        }
        if (sfxVolumeSlider != null) {
            // Load the saved SFX volume from PlayerPrefs
            float savedSFXVolume = PlayerPrefs.GetFloat(AudioManager.SFXPlayerPrefsKey, 1f);
            sfxVolumeSlider.value = savedSFXVolume;
            sfxVolumeSlider.onValueChanged.AddListener(OnSFXSliderValueChanged);
        }
    }

    private void OnMusicSliderValueChanged(float value) {
        AudioManager.Instance.SetMusicVolume(value);
    }

    private void OnSFXSliderValueChanged(float value) {
        AudioManager.Instance.SetSFXVolume(value);
    }
}

