using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieWhenFall : MonoBehaviour
{
    [SerializeField] private SignalObject gameOverSignal;
    private void OnTriggerEnter2D(Collider2D other) 
    {
        gameOverSignal.Raise();
    }
}
