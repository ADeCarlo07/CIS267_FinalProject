using System.Collections;
using UnityEngine;

public class EnemyMovementLeftRightV2 : MonoBehaviour
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
    private bool movingUp = true;
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

                attackRadius.SetActive(false);

                MoveLeftToRight();

                //I had to do this because when certain attack rads were on the enemy some combat symbols weren't
                //being deleted on the grid. But, making its active self false and turning it back on after a short
                //delay causes all symbols to be deleted and nothing left behind.
                StartCoroutine(Wait());


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
            StartCoroutine(MoveEnemy(tarPos));
            enemyTurn = false;
            PlayerControllerOnGrid.playerTurn = true;
        }
        else
        {
            movingLeft = !movingLeft;

            Vector3 verticalDir;

            if (movingUp)
            {
                verticalDir = Vector3.up;
            }
            else
            {
                verticalDir = Vector3.down;
            }

            Vector3 nextVerticalPos = transform.position + (verticalDir * tileSize);

            bool rowValid = false;
            bool rowOccupied = false;

            Collider2D[] sideHits = Physics2D.OverlapCircleAll(nextVerticalPos, 0.3f);
            foreach (Collider2D hit in sideHits)
            {
                if (hit.CompareTag("Player"))
                {
                    rowOccupied = true;
                }

                HighlightBox tile = hit.GetComponent<HighlightBox>();
                if (tile != null && tile.highlighted)
                {
                    rowValid = true;
                }
            }

            if (rowValid && !rowOccupied)
            {
                StartCoroutine(MoveEnemy(nextVerticalPos));
                enemyTurn = false;
                PlayerControllerOnGrid.playerTurn = true;
            }
            else
            {
                //flip row direction if blocked
                movingUp = !movingUp;
            }
        }

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

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(.2f);
        attackRadius.SetActive(true);
    }
}


