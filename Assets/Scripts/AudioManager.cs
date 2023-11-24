using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public AudioMixer musicAudioMixer;
    public AudioMixer sfxAudioMixer;
    public const string MusicPlayerPrefsKey = "MusicVolume";
    public const string SFXPlayerPrefsKey = "SFXVolume";
    private const float MinVolume = 0.0001f;
    private static AudioManager instance;
    
    private void Awake() {
        if (instance == null) {
            // If this is the first instance, make it persistent
            instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            // If there is an existing instance from a different scene, destroy it
            if (instance.gameObject.scene.name != SceneManager.GetActiveScene().name)
            {
                Destroy(instance.gameObject);
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                // If it's from the same scene, destroy this instance
                Destroy(gameObject);
            }
        }
    }

    private void Start() {
        float savedMusicVolume = PlayerPrefs.GetFloat(MusicPlayerPrefsKey, 1f);
        SetMusicVolume(savedMusicVolume);

        float savedSFXVolume = PlayerPrefs.GetFloat(SFXPlayerPrefsKey, 1f);
        SetSFXVolume(savedSFXVolume);
    }

    public void SetMusicVolume(float volume) {
        SetVolume(musicAudioMixer, MusicPlayerPrefsKey, volume);
    }

    public void SetSFXVolume(float volume) {
        SetVolume(sfxAudioMixer, SFXPlayerPrefsKey, volume);
    }

    private void SetVolume(AudioMixer audioMixer, string playerPrefsKey, float volume) {
        if (volume < MinVolume) {
            volume = MinVolume;
        }
        audioMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat(playerPrefsKey, volume);
        PlayerPrefs.Save();
    }

    public static AudioManager Instance {
        get { return instance; }
    }
}








