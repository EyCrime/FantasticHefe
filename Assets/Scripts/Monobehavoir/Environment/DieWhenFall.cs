using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieWhenFall : MonoBehaviour
{
    [SerializeField] private SignalObject gameOverSignal;
    [SerializeField] private Inventory playerInventory;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            playerInventory.gameOverReason = "Du darfst natürlich nicht runterfallen, Idiot!";
            gameOverSignal.Raise();
        }
    }
}
