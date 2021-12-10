using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieWhenFall : MonoBehaviour
{
    [SerializeField] private SignalObject gameOverSignal;
    [SerializeField] private AudioSource deathSound;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            gameOverSignal.Raise();
            deathSound.Play();
        }
    }
}
