using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }
    
    [SerializeField] private FMODUnity.EventReference musicEvent;
    private FMOD.Studio.EventInstance musicInstance;

    private void Awake() 
    {
        Instance = this;
        musicInstance = FMODUnity.RuntimeManager.CreateInstance(musicEvent);
        musicInstance.start();
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
}