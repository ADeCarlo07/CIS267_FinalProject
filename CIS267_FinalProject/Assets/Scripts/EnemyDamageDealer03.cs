using UnityEngine;

public class EnemyDamageDealer03 : MonoBehaviour
{
    public GameObject player;
    public GameObject attackRadius;
    private bool damageDealt;
    private bool isBoss;

    public GameObject[] attackRads;
    private bool playerInRange;
    private int curIndex;

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
            GameObject currentRad = attackRads[curIndex];
            playerInRange = currentRad.GetComponent<AttackRadius>().playerInRadius;

            if (!damageDealt && playerInRange && EnemyPathfinding.enemyTurn)
            {
                Debug.Log("Damage Taken");
                player.GetComponent<HealthBarManager>().TakeDamage(10);
                damageDealt = true;

                EnemyPathfinding.enemyTurn = false;
                PlayerControllerOnGrid.playerTurn = true;

                curIndex++;
                if (curIndex >= attackRads.Length)
                {
                    curIndex = 0;
                }
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
                player.GetComponent<HealthBarManager>().TakeDamage(10);
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
