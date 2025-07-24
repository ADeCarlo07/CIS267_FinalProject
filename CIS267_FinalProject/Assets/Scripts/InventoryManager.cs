using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    //this script holds a player's inventory and allows one to modify it at will
    //it's required to be attached to the player prefab

    public static string[] playerItems = {null, null, "HealthPotion"};
    //the players inventory is stored via a string array of 3
    //WARNING: this system requires universal names for all internal items
    //we don't want 2 items called "healthPotion" and "HealthPotion"

    //below is a list of all internal item names to keep track.
    //i added some filler names to give examples
    //we can remove them as the list gets filled out

    //-----------------------------------------
    //HealthPotion
    //FlintAndSteel
    //LampOil
    //RawPorkChop
    //-----------------------------------------

    public static string GetItem(int slot)
    {
        //this function gets the item for a specific slot.
        //we could use this for an interface system, where this function is called to get the items and display the appropriate icon in an inventory display

        //example psuedocode (for usage in a different script, whichever one handles battle UI)
        //void DisplayInventory()
        //{
        //    for (int i = 0; i < playerItems.Length; i++;)
        //    {
        //        InventorySlot[i].image = getItem(i);
        //    }
        //}

        return playerItems[slot];
    }
    public void AppendItem(string itemName)
    {
        //this function adds an item to the first available slot, if none are available, it will not add the item

        //we can add something to the item's collision checks later to fix this, for example, maybe pull up a panel
        //that asks the player if they want to drop an item to pick up this one, and if they hit yes, then run the
        //DeleteItem() function, then AddItem() again to pick it up.
        //If we added this to the collision rn, it would probably delete the target item and not add it to the inventory
        for (int i = 0; i < playerItems.Length; i++)
        {
            if (playerItems[i] == null)
            {
                playerItems[i] = itemName;
                break;
            }
        }
    }
    public void DeleteItem(int slot)
    {
        //this function deletes an item in the playerItem array by changing it back to null
        playerItems[slot] = null;
        
    }
    public bool CheckForItem(string itemName)
    {
        //this function searches every slot of the inventory for a specific item and returns true if available

        bool check = false;
        for (int i = 0; i < playerItems.Length; i++)
        {
            if (playerItems[i] == itemName)
            {
                check = true;
            }
        }
        return check;
    }

}
