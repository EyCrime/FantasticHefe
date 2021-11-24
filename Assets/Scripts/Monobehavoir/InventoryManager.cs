using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] private Inventory playerInventory;
    [SerializeField] private TextMeshProUGUI itemDisplay;
    [SerializeField] private ItemType Item;
    public void UpdateInventory()
    {
        if(Item == ItemType.KaltesWasser)
            itemDisplay.text = "" + playerInventory.coldWater;
        else if(Item == ItemType.HeißesWasser)
            itemDisplay.text = "" + playerInventory.hotWater;
        else if(Item == ItemType.Score)
            itemDisplay.text = "" + playerInventory.score;
    }

    private enum ItemType{
        KaltesWasser, HeißesWasser, Score, CO2
    }
}
