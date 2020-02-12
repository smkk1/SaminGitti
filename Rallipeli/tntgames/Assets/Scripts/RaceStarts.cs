using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RaceStarts : MonoBehaviour
{
    public UnityEvent OnGameStart;
    private float currentTime = 3f;
    private GameObject finishline;

    
    [SerializeField]Text countdownText;

    private bool triggered = false;


    void Start()
    {
        finishline = GameObject.Find("RaceFinishLine");
    }

    void Update()
    {
        currentTime -= Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0f)
        {

            if (!triggered)
            {
                OnGameStart.Invoke();
                countdownText.CrossFadeAlpha(0f, 0f, false);
                triggered = true;
                finishline.GetComponent<Timer>().raceStarted = true;
            }

        }

    }

}
