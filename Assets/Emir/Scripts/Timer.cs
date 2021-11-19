using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{       
    [SerializeField] private TextMeshProUGUI currentTimeText;
    [SerializeField] private float startMinutes;
    [SerializeField] private float currentTime;

    private bool timerActive = false;

    private void Start()
    {
        currentTime = startMinutes * 60;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
            StartTimer();
        else if (Input.GetKeyDown(KeyCode.Y))
            StopTimer();

        if (timerActive){
            currentTime = currentTime - Time.deltaTime;

            if(currentTime <= 0)
                timerActive = false; // Gameover

            TimeSpan time = TimeSpan.FromSeconds(currentTime);
            currentTimeText.text = time.ToString(@"mm\:ss");
        }
    }

    private void StartTimer() {
        timerActive = true;
    }

    private void StopTimer() {
        timerActive = false;
    }
}
