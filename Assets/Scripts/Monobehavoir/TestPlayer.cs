using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    [SerializeField] private Inventory playerInventory;
    [SerializeField] private Temperature temperature;
    [SerializeField] private SignalObject playerHealthSignal;
    [SerializeField] private SignalObject CO2Signal;
    [SerializeField] private SignalObject temperatureSignal;
    [SerializeField] private SignalObject coldWaterSignal;
    [SerializeField] private SignalObject hotWaterSignal;
    [SerializeField] private SignalObject scoreSignal;
    [SerializeField] private SignalObject switchAmmoSignal;
    [SerializeField] private SignalObject startTimerSignal;
    [SerializeField] private SignalObject stopTimerSignal;

    private void Awake()
    {
        playerInventory.currentHealth = playerInventory.maxHealth;
        playerInventory.currentCO2 = 0;
        temperature.current = temperature.normal;
        playerHealthSignal.Raise();
        coldWaterSignal.Raise();
        hotWaterSignal.Raise();
        scoreSignal.Raise();
        CO2Signal.Raise();
        temperatureSignal.Raise();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {           
            if (playerInventory.currentHealth <= 0)
            {
                GameOver();
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (playerInventory.currentHealth < playerInventory.maxHealth)
            {
                playerInventory.currentHealth++;
                playerHealthSignal.Raise();
            }
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            playerInventory.coldWater++;
            coldWaterSignal.Raise();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            if (playerInventory.coldWater > 0)
            {
                playerInventory.coldWater--;
                coldWaterSignal.Raise();
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            playerInventory.hotWater++;
            hotWaterSignal.Raise();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            if (playerInventory.hotWater > 0)
            {
                playerInventory.hotWater--;
                hotWaterSignal.Raise();
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            playerInventory.score += 10;
            scoreSignal.Raise();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (playerInventory.score > 0)
            {
                playerInventory.score -= 10;
                scoreSignal.Raise();
            }
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            switchAmmoSignal.Raise();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            if (playerInventory.currentCO2 < playerInventory.maxCO2)
            {
                playerInventory.currentCO2++;
                CO2Signal.Raise();
            }
        }
        else if (Input.GetKeyDown(KeyCode.V))
        {
            if (playerInventory.currentCO2 > 0)
            {
                playerInventory.currentCO2--;
                CO2Signal.Raise();
            }
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            if (temperature.current < temperature.max)
            {
                temperature.current++;
                temperatureSignal.Raise();
            }
            else
            {
                GameOver();
            }
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            if (temperature.current > temperature.min)
            {
                temperature.current--;
                temperatureSignal.Raise();
            }
            else
            {
                GameOver();
            }
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            startTimerSignal.Raise();
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {   
            stopTimerSignal.Raise();
        }
    }

    void GameOver()
    {
        gameObject.SetActive(false);
        stopTimerSignal.Raise();
    }
}
