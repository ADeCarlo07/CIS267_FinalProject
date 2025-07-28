using UnityEngine;

public class EnemyDamageDealer03 : MonoBehaviour
{
    public GameObject player;
    public GameObject attackRadius;
    private bool damageDealt;
    private bool isBoss;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isBoss = gameObject.GetComponent<EnemyPathfinding>().isFinalBoss;
    }

    // Update is called once per frame
    void Update()
    {
        if (isBoss)
        {

            if (!damageDealt && !AttackRadius.canMove && EnemyPathfinding.enemyTurn)
            {
                Debug.Log("Damage Taken");
                player.GetComponent<HealthBarManager>().TakeDamage(40);
                damageDealt = true;

                EnemyPathfinding.enemyTurn = false;
                PlayerControllerOnGrid.playerTurn = true;      
            }

            if (!EnemyPathfinding.enemyTurn)
            {
                damageDealt = false;
     
            }

            
        }
        else
        {
            if (!damageDealt && attackRadius.GetComponent<AttackRadius>().playerInRadius && EnemyPathfinding.enemyTurn)
            {
                Debug.Log("Damage Taken");
                player.GetComponent<HealthBarManager>().TakeDamage(30);
                damageDealt = true;

                EnemyPathfinding.enemyTurn = false;
                PlayerControllerOnGrid.playerTurn = true;
            }

            if (!EnemyPathfinding.enemyTurn)
            {
                damageDealt = false;
            }
        }
        

    }
}
