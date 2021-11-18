using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayer : MonoBehaviour
{
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private FloatValue currentHealth;
    [SerializeField] private SignalObject playerHealthSignal;

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            currentHealth.runtimeValue--;
            playerHealthSignal.Raise();
            if(currentHealth.runtimeValue <= 0)
                gameObject.SetActive(false); // Gameover
        }
        else if(Input.GetKeyDown(KeyCode.Return))
        {
            if(currentHealth.runtimeValue < maxHealth)
            {
                currentHealth.runtimeValue++;
                playerHealthSignal.Raise();
            }
        }
    }
}
