using UnityEngine;

public class EnemyDamageDealer : MonoBehaviour
{
    public GameObject player;
    public GameObject attackRadius;
    private bool damageDealt;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!damageDealt && attackRadius.GetComponent<AttackRadius>().playerInRadius && EnemyMovementUpDown.enemyTurn)
        {
            Debug.Log("Damage Taken");
            player.GetComponent<HealthBarManager>().TakeDamage(25);
            damageDealt = true;

            EnemyMovementUpDown.enemyTurn = false;
            PlayerControllerOnGrid.playerTurn = true;
            PlayerControllerOnGrid.ableToMove = true;
        }

        if (!EnemyMovementUpDown.enemyTurn)
        {
            damageDealt = false;
        }

    }
}   
