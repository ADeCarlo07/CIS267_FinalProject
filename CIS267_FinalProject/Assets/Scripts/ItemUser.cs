using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemUser : MonoBehaviour
{
    public GameObject player;
    public GameObject InventoryPanel;
    public Button button;

    public void UseItem(string callerID)
    {
        //close boolean prevents repeated code
        bool close = false;

        if(callerID == "one")
        {
            if (InventoryManager.playerItems[0] == null)
            {
                //do nothing
                close = false;
            }
            if(InventoryManager.playerItems[0] == "HealthPotion")
            {
                player.GetComponent<HealthBarManager>().heal(50);
                close = true;
            }
            InventoryManager.playerItems[0] = null;
            //button.Select();
        }
        if (callerID == "two")
        {
            if (InventoryManager.playerItems[1] == null)
            {
                //do nothing
                close = false;

            }
            if (InventoryManager.playerItems[1] == "HealthPotion")
            {
                player.GetComponent<HealthBarManager>().heal(50);
                close = true;

            }

            InventoryManager.playerItems[1] = null;
            //button.Select();


        }
        if (callerID == "three")
        {
            if (InventoryManager.playerItems[2] == null)
            {
                //do nothing
                close = false;

            }
            if (InventoryManager.playerItems[2] == "HealthPotion")
            {
                player.GetComponent<HealthBarManager>().heal(50);
                close = true;

            }
            InventoryManager.playerItems[2] = null;
            //button.Select();

        }
        if (close)
        {
            InventoryPanel.SetActive(false);
            PlayerControllerOnGrid.playerTurn = false;
            EnemyPathfinding.enemyTurn = true;
            //button.Select();

        }
        button.Select();
    }
}
