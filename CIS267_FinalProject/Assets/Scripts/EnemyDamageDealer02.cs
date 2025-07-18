using UnityEngine;

public class EnemyDamageDealer02 : MonoBehaviour
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
        //for enemies that move left to right on grid, since movement is simple their
        //attacks deal extra damage
        if (!damageDealt && attackRadius.GetComponent<AttackRadius>().playerInRadius && EnemyMovementLeftRight.enemyTurn)
        {
            Debug.Log("Damage Taken");
            player.GetComponent<HealthBarManager>().TakeDamage(40);
            damageDealt = true;

            EnemyMovementLeftRight.enemyTurn = false;
            PlayerControllerOnGrid.playerTurn = true;
            PlayerControllerOnGrid.ableToMove = true;
        }

        if (!EnemyMovementLeftRight.enemyTurn)
        {
            damageDealt = false;
        }

    }
}
