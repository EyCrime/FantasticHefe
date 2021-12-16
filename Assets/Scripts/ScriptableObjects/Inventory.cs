using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Inventory : ScriptableObject
{
   public int maxHealth;
   public int currentHealth;
   public int coldWater;
   public int hotWater;
   public int score;
   public int maxCO2;
   public int currentCO2;
   public string gameOverReason;
}