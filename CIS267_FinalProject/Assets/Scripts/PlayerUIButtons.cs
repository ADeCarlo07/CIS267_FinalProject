using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerUIButtons : MonoBehaviour
{
    public GameObject playerMovementRadius;
    public Button move;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void MoveButton()
    {
        PlayerControllerOnGrid.playerTurn = true;
        PlayerControllerOnGrid.ableToMove = true;
        playerMovementRadius.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);
    }

    public void AbilitiesButton()
    {

    }

    public void InventoryButton()
    {

    }

    public void SkipTurnButton()
    {
        EnemyPathfinding.enemyTurn = true;
        EnemyMovementUpDown.enemyTurn = true;
        EnemyMovementLeftRight.enemyTurn = true;
        PlayerControllerOnGrid.playerTurn = false;
    }
}
