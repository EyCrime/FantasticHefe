using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TimerManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentTimeText;
    [SerializeField] private Timer timer;

    private bool timerActive = false;

    private void Start()
    {
        timer.currentTime = timer.startMinutes * 60;
    }

    private void Update()
    {
        if (timerActive){
            timer.currentTime = timer.currentTime - Time.deltaTime;

            if(timer.currentTime <= 0)
                timerActive = false; // Gameover

            TimeSpan time = TimeSpan.FromSeconds(timer.currentTime);
            currentTimeText.text = time.ToString(@"mm\:ss");
        }
    }

    public void StartTimer() {
        timerActive = true;
    }

    public void StopTimer() {
        timerActive = false;
    }
}
