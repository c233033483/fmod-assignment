using System;
using UnityEngine;

public class AudioZoneTriggering : MonoBehaviour
{
    [SerializeField] private FMODUnity.EventReference snapshotEvent;
    private FMOD.Studio.EventInstance snapshot;

    private bool inZone;

    private void Update()
    {
        if (Player.Instance.transform.position.x < -5.7f && !inZone) {
            snapshot = FMODUnity.RuntimeManager.CreateInstance(snapshotEvent);
            snapshot.start();
            inZone = true;
        } else if (Player.Instance.transform.position.x >= -5.7f && inZone) {
            snapshot.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            snapshot.release();
            inZone = false;
        }
    }
}
