using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStartCountdownUI : MonoBehaviour {



    private const string NUMBER_POPUP = "NumberPopup";


    [SerializeField] private TextMeshProUGUI countdownText;


    private Animator animator;
    private int previousCountdownNumber;
    [SerializeField] private FMODUnity.EventReference countdownSound;
    
    private void Awake() {
        animator = GetComponent<Animator>();
    }

    private void Start() {
        KitchenGameManager.Instance.OnStateChanged += KitchenGameManager_OnStateChanged;

        Hide();
    }

    private void KitchenGameManager_OnStateChanged(object sender, System.EventArgs e) {
        if (KitchenGameManager.Instance.IsCountdownToStartActive()) {
            Show();
        } else {
            Hide();
        }
        
        if (KitchenGameManager.Instance.IsGamePlaying()) {
            var instance = FMODUnity.RuntimeManager.CreateInstance(countdownSound);
            instance.setParameterByName("Countdown", 0);
            instance.start();
            instance.release();
        }
    }

    private void Update() {
        int countdownNumber = Mathf.CeilToInt(KitchenGameManager.Instance.GetCountdownToStartTimer());
        countdownText.text = countdownNumber.ToString();

        if (previousCountdownNumber != countdownNumber) {
            previousCountdownNumber = countdownNumber;
            animator.SetTrigger(NUMBER_POPUP);
            
            
            var instance = FMODUnity.RuntimeManager.CreateInstance(countdownSound);
            instance.setParameterByName("Countdown", countdownNumber);
            instance.start();
            instance.release();
            
            print (countdownNumber);
        }
    }

    private void Show() {
        gameObject.SetActive(true);
    }

    private void Hide() {
        gameObject.SetActive(false);
    }

}