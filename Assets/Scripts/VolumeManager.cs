using UnityEngine;

public class VolumeManager : MonoBehaviour
{
    public static VolumeManager Instance { get; private set; }

    private FMOD.Studio.VCA masterVCA;
    private FMOD.Studio.VCA musicVCA;
    private FMOD.Studio.VCA sfxVCA;

    [SerializeField] private UnityEngine.UI.Slider masterSlider;
    [SerializeField] private UnityEngine.UI.Slider musicSlider;
    [SerializeField] private UnityEngine.UI.Slider sfxSlider;
    
    private void Awake() {
        Instance = this;
        masterVCA = FMODUnity.RuntimeManager.GetVCA("vca:/Master");
        musicVCA = FMODUnity.RuntimeManager.GetVCA("vca:/Music");
        sfxVCA = FMODUnity.RuntimeManager.GetVCA("vca:/SFX");
    }
    
    private void Start() {
        masterSlider.onValueChanged.AddListener((v) => SetMasterVolume(v));
        musicSlider.onValueChanged.AddListener((v) => SetMusicVolume(v));
        sfxSlider.onValueChanged.AddListener((v) => SetSFXVolume(v));
    }
    
    private void SetMasterVolume(float volume) {
        masterVCA.setVolume(volume);
    }

    private void SetMusicVolume(float volume) {
        musicVCA.setVolume(volume);
    }

    private void SetSFXVolume(float volume) {
        sfxVCA.setVolume(volume);
    }
}
