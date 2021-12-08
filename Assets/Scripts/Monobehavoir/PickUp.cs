using UnityEngine;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private SignalObject co2Signal;
    [SerializeField] private SignalObject coldWaterSignal;
    [SerializeField] private SignalObject hotWaterSignal;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && other.isTrigger )
        {
            Destroy(gameObject);

            if (gameObject.CompareTag("co2"))
            {
                inventory.currentCO2++;
                co2Signal.Raise();
            }  
            else if (gameObject.CompareTag("coldWater"))
            {
                inventory.coldWater += 20;
                coldWaterSignal.Raise();
            }   
            else if (gameObject.CompareTag("hotWater"))
            {
                inventory.hotWater += 20;
                hotWaterSignal.Raise();
            }
        }
    }
}
