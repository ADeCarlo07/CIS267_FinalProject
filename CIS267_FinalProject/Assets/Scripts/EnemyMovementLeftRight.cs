using System.Collections;
using UnityEngine;
using static Unity.Cinemachine.IInputAxisOwner.AxisDescriptor;

public class EnemyMovementLeftRight : MonoBehaviour
{
    private Vector3 origPos;
    private Vector3 targetPos;
    public float tileSize = 1.4f;
    private float timeToMove = 0.2f;
    private bool validMove;
    private bool occupiedByPlayer;
    public static bool enemyTurn;
    public GameObject attackRadius;
    private bool movingLeft = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyTurn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyTurn)
        {
            if (attackRadius.GetComponent<AttackRadius>().playerInRadius != true)
            {

                MoveLeftToRight();

            }
        }
    }

    private void MoveLeftToRight()
    {
        Vector3 direction;

        //starting off, if you're moving left then direction is left, vice versa
        if (movingLeft)
        {
            direction = Vector3.left;
        }
        else
        {
            direction = Vector3.right;
        }


        //you want the enemy to move in the direction (being left or right) * the tile size so
        //its a nice blocky movement on the grid
        Vector3 tarPos = transform.position + (direction * tileSize);

        occupiedByPlayer = false;
        validMove = false;

        //you're storing att the hits in the target direction (where the enemy
        //wants to go) and seeing if it 1. is occupied by player, 2. valid move
        Collider2D[] hits = Physics2D.OverlapCircleAll(tarPos, 0.3f);

        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Player"))
            {
                occupiedByPlayer = true;
            }

            //Enemy highlighted box is yellow. Enemy can't move
            //outside of highlighted box
            HighlightBox tile = hit.GetComponent<HighlightBox>();

            //if there is a tile (not outside of grid) and its highlighted
            //move is valid
            if (tile != null && tile.highlighted)
            {
                validMove = true;
            }
        }

        if (validMove && !occupiedByPlayer)
        {
            StartCoroutine(MoveEnemy(transform.position + (direction * tileSize)));
        }
        else
        {
            //set it to the opposite of what it is, same stuff but reverse direction
            //I don't remember why exactly I did this, but it was the only
            //thing that would work for me :(
            movingLeft = !movingLeft;

            Vector3 reverseDir;
            if (movingLeft)
            {
                reverseDir = Vector3.left;
            }
            else
            {
                reverseDir = Vector3.right;
            }

            Vector3 reversePos = transform.position + reverseDir * tileSize;

            Collider2D[] reverseHits = Physics2D.OverlapCircleAll(reversePos, 0.3f);
            bool reverseValid = false;
            bool reverseOccupied = false;

            foreach (Collider2D hit in reverseHits)
            {
                if (hit.CompareTag("Player"))
                {
                    reverseOccupied = true;
                }

                HighlightBox tile = hit.GetComponent<HighlightBox>();

                if (tile != null && tile.highlighted)
                {
                    reverseValid = true;
                }
            }

            if (reverseValid && !reverseOccupied)
            {
                StartCoroutine(MoveEnemy(reversePos));
            }
        }

        //after enemy has moved it's not their turn anymore and
        //player can do turn

        enemyTurn = false;
        PlayerControllerOnGrid.playerTurn = true;

    }

    private IEnumerator MoveEnemy(Vector3 direction)
    {

        float elapsedTime = 0;
        origPos = transform.position;
        targetPos = direction;

        while (elapsedTime < timeToMove)
        {
            //lerp is for smooth transition
            transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        transform.position = targetPos;


    }
}
