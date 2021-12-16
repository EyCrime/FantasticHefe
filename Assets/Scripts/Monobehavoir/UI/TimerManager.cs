using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TimerManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentTimeText;
    [SerializeField] private SignalObject gameOverSignal;
    [SerializeField] private Timer timer;
    [SerializeField] private Inventory playerInventory;

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
            {
                playerInventory.gameOverReason = "Hast du dich verlaufen oder warum bist du immernoch nicht am Ziel?";
                gameOverSignal.Raise();
                timerActive = false;
            }

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
