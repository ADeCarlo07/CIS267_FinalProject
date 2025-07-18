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
        // for enemies that move up and down on grid, extra damage dealt because their movement is so simple
        if (!damageDealt && attackRadius.GetComponent<AttackRadius>().playerInRadius && EnemyMovementUpDown.enemyTurn)
        {
            Debug.Log("Damage Taken");
            player.GetComponent<HealthBarManager>().TakeDamage(40);

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
