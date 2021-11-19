using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    [SerializeField] private FloatValue maxHealth;
    [SerializeField] private FloatValue currentHealth;
    [SerializeField] private Inventory playerInventory;
    [SerializeField] private SignalObject playerHealthSignal;
    [SerializeField] private SignalObject coldWaterSignal;
    [SerializeField] private SignalObject hotWaterSignal;
    [SerializeField] private SignalObject scoreSignal;
    [SerializeField] private SignalObject switchAmmoSignal;

    private void Awake()
    {
        currentHealth.initialValue = maxHealth.initialValue;
        playerHealthSignal.Raise();
        coldWaterSignal.Raise();
        hotWaterSignal.Raise();
        scoreSignal.Raise();
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            currentHealth.initialValue--;
            playerHealthSignal.Raise();
            if(currentHealth.initialValue <= 0)
                gameObject.SetActive(false); // Gameover
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(currentHealth.initialValue < maxHealth.initialValue)
            {
                currentHealth.initialValue++;
                playerHealthSignal.Raise();
            }
        }
        else if(Input.GetKeyDown(KeyCode.W))
        {
            playerInventory.coldWater++;
            coldWaterSignal.Raise();
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            if(playerInventory.coldWater > 0)
            {
                playerInventory.coldWater--;
                coldWaterSignal.Raise();
            }
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            playerInventory.hotWater++;
            hotWaterSignal.Raise();
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            if(playerInventory.hotWater > 0)
            {
                playerInventory.hotWater--;
                hotWaterSignal.Raise();
            }
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            playerInventory.score += 10;
            scoreSignal.Raise();
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(playerInventory.score > 0)
            {
                playerInventory.score -= 10;
                scoreSignal.Raise();
            }
        }
        else if(Input.GetKeyDown(KeyCode.R))
        {
            switchAmmoSignal.Raise();
        }
    }
}
