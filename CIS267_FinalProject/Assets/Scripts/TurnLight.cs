using UnityEngine;
using UnityEngine.UI;

public class TurnLight : MonoBehaviour
{
    public Image EnemyTurnLight;
    public Image PlayerTurnLight;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerControllerOnGrid.playerTurn)
        {
          
            if (PlayerTurnLight.gameObject.activeSelf == false)
            {
                //Debug.Log("Player Turn");
                PlayerTurnLight.gameObject.SetActive(true);
                EnemyTurnLight.gameObject.SetActive(false);
            }
           
        }
        else if (EnemyPathfinding.enemyTurn || EnemyMovementUpDown.enemyTurn || EnemyMovementLeftRight.enemyTurn)
        {
            //Debug.Log("Enemy Turn");
            PlayerTurnLight.gameObject.SetActive(false);
            EnemyTurnLight.gameObject.SetActive(true);
        }
        else
        {
            Debug.Log("Error, no turn");
        }
    }
}
