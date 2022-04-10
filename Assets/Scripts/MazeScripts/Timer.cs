using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float maxTimeInSeconds;

    [SerializeField] TextMeshProUGUI uiTimer;

    [SerializeField] LosingMessageDisplayer losingMessageDisplayer;

    TimeSpan timer;

    float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = maxTimeInSeconds;

        SetTheUiTimer();


        StartCoroutine("StartTimer");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartTimer()
    {
        while(currentTime>0)
        {
            currentTime--;

            SetTheUiTimer();

            yield return new WaitForSeconds(1);
        }

        losingMessageDisplayer.DisplayTheLosingUiPanel("" +
            "The Guards found you wondering around the maze and arrested you");
    }

    void SetTheUiTimer()
    {

        timer = TimeSpan.FromSeconds(currentTime);

        uiTimer.text = string.Format("{0}:{1}", timer.Minutes, timer.Seconds);
    }

    public void StopTimer()
    {
        StopCoroutine("StartTimer");
    }
}
