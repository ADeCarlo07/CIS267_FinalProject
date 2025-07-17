using TMPro;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerUIButtons : MonoBehaviour
{
    public GameObject playerMovementRadius;
    public Button move;
    public Button abilities;
    public Button inventory;
    public Button skipTurn;
    public static bool buttonPressed;
    public static bool moveButtonPressed;
    public static bool abilitiesButtonPressed;
    public static bool inventoryButtonPressed;
    public GameObject abilityHolder;
    public GameObject inventoryHolder;
    public GameObject firstAbility;

    public TextMeshProUGUI[] InventorySlots = new TextMeshProUGUI[3];

    void Update()
    {
        if (buttonPressed == true)
        {
            move.enabled = false;
            abilities.enabled = false;
            inventory.enabled = false;
            skipTurn.enabled = false;
        }

        if (buttonPressed == false)
        {
            move.enabled = true;
            abilities.enabled = true;
            inventory.enabled = true;
            skipTurn.enabled = true;
        }
    }

    public void MoveButton()
    {
        PlayerControllerOnGrid.playerTurn = true;
        PlayerControllerOnGrid.ableToMove = true;
        playerMovementRadius.SetActive(true);

        moveButtonPressed = true;
        buttonPressed = true;
    }

    public void AbilitiesButton()
    {
        
        abilityHolder.SetActive(true);
        abilitiesButtonPressed = true;
        EventSystem.current.SetSelectedGameObject(firstAbility);
        buttonPressed = true;
        
    }

    public void InventoryButton()
    {
        for (int i = 0; i < InventorySlots.Length; i++)
        {
            if(InventoryManager.GetItem(i) != null)
            {
                InventorySlots[i].text = InventoryManager.GetItem(i);
            }    
        }

        inventoryHolder.SetActive(true);
        inventoryButtonPressed = true;

        buttonPressed = true;
    }

    public void SkipTurnButton()
    {
        EnemyPathfinding.enemyTurn = true;
        EnemyMovementUpDown.enemyTurn = true;
        EnemyMovementLeftRight.enemyTurn = true;
        PlayerControllerOnGrid.playerTurn = false;
    }
}
