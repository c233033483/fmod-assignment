using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    [SerializeField] private FMODUnity.EventReference pickUpSound;
    [SerializeField] private FMODUnity.EventReference putDownSounda;
    
    private void Start() {
        Player.Instance.OnPickedSomething += OnPickedSomething;
        Player.Instance.OnPutDownSomething += OnPutDownSomething;
    }
    
    private void OnDestroy() {
        Player.Instance.OnPickedSomething -= OnPickedSomething;
        Player.Instance.OnPutDownSomething -= OnPutDownSomething;
    }
    
    private void OnPickedSomething(object sender, System.EventArgs e) {
        print("picking up");
        FMODUnity.RuntimeManager.PlayOneShot(pickUpSound, Player.Instance.transform.position);
    }

    private void OnPutDownSomething(object sender, System.EventArgs e) {
        print("put down");
        FMODUnity.RuntimeManager.PlayOneShot(putDownSounda, Player.Instance.transform.position);
    }
}
