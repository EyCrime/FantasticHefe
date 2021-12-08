using UnityEngine;
using UnityEngine.UI;

public class PickUp2 : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private SignalObject co2Signal;
    [SerializeField] private SignalObject coldWaterSignal;
    [SerializeField] private SignalObject hotWaterSignal;
    [SerializeField] private SignalObject scoreSignal;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && other.isTrigger)
        {
            Destroy(gameObject);

            inventory.score += 20;
            scoreSignal.Raise();

            if (gameObject.CompareTag("co2"))
            {
                inventory.currentCO2++;
                co2Signal.Raise();
            }
            else if (gameObject.CompareTag("coldWater"))
            {
                inventory.coldWater += 2;
                coldWaterSignal.Raise();
            }
            else if (gameObject.CompareTag("hotWater"))
            {
                inventory.hotWater += 2;
                hotWaterSignal.Raise();
            }
        }
    }
}