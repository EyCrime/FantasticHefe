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
            playerInventory.gameOverReason = "Denkst du, dass du fliegen kannst ya salame?!";
            gameOverSignal.Raise();
        }
    }
}
