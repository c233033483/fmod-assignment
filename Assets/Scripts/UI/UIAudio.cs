using UnityEngine;

public enum UISound
{
    Click = 0,
    Back = 1
}

public class UIAudio : MonoBehaviour
{
    public static UIAudio Instance { get; private set; }
    private void Awake() {
        Instance = this;
    }
    
    
    [SerializeField] private FMODUnity.EventReference clickAudio;
    
    public void PlayUISound(UISound sound) 
    {
        var instance = FMODUnity.RuntimeManager.CreateInstance(Instance.clickAudio);
        instance.setParameterByName("UISound", (float)sound);
        instance.start();
        instance.release();
    }
}
