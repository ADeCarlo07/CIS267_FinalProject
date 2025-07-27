using UnityEngine;

public class HealthPotionPickUp : MonoBehaviour
{
    InventoryManager inventoryManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            InventoryManager.AppendItem("HealthPotion");
            Debug.Log(InventoryManager.playerItems[0] + " " + InventoryManager.playerItems[1] + " " + InventoryManager.playerItems[2]);
            Destroy(gameObject);

        }
    }
}
