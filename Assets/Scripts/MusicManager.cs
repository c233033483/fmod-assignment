using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }
    
    [SerializeField] private FMODUnity.EventReference musicEvent;
    private FMOD.Studio.EventInstance musicInstance;

    private int burningCount = 0;
    
    private void Awake() 
    {
        Instance = this;
        musicInstance = FMODUnity.RuntimeManager.CreateInstance(musicEvent);
        musicInstance.start();
    }
    
    private void Start() {
        StoveCounter.OnAnyStateChanged += StoveCounter_OnAnyStateChanged;
        DeliveryManager.Instance.OnRecipeSuccess += DeliveryManager_OnRecipeSuccess;
    }
    
    public void SetMusicState(string state) 
    {
        musicInstance.setParameterByNameWithLabel("MusicState", state);
    }
    
    private void OnDestroy() 
    {
        musicInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        musicInstance.release();
    }
    
    private void StoveCounter_OnAnyStateChanged(object sender, StoveCounter.OnStateChangedEventArgs e) {
        if (e.state == StoveCounter.State.Burned) {
            musicInstance.setParameterByNameWithLabel("MusicState", "Chaos");
        }
    }

    private void DeliveryManager_OnRecipeSuccess(object sender, System.EventArgs e) {
        musicInstance.setParameterByNameWithLabel("MusicState", "Normal");
    }
}