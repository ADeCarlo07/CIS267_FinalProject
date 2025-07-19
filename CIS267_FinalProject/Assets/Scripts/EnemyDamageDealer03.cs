using UnityEngine;

public class EnemyDamageDealer03 : MonoBehaviour
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
        if (!damageDealt && attackRadius.GetComponent<AttackRadius>().playerInRadius && EnemyPathfinding.enemyTurn)
        {
            Debug.Log("Damage Taken");
            player.GetComponent<HealthBarManager>().TakeDamage(25);
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
