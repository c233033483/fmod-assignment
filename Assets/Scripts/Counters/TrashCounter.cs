using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCounter : BaseCounter {


    public static event EventHandler OnAnyObjectTrashed;

    [SerializeField] private FMODUnity.StudioEventEmitter binSoundEmitter;
    

    new public static void ResetStaticData() {
        OnAnyObjectTrashed = null;
    }



    public override void Interact(Player player) {
        if (player.HasKitchenObject()) {
            player.GetKitchenObject().DestroySelf();

            binSoundEmitter.Play();
            
            OnAnyObjectTrashed?.Invoke(this, EventArgs.Empty);
        }
    }

}