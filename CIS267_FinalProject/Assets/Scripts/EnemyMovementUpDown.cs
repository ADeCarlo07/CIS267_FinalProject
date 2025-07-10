using System.Collections;
using UnityEngine;

public class EnemyMovementUpDown : MonoBehaviour
{
    private Vector3 origPos;
    private Vector3 targetPos;
    public float tileSize = 1.4f;
    private float timeToMove = 0.2f;
    private bool validMove;
    private bool occupiedByPlayer;
    public static bool enemyTurn;
    public GameObject attackRadius;
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
                Debug.Log("Moving");
                MoveUpDown();

            }
        }
    }

    private void MoveUpDown()
    {
        Vector3 direction;

        if (movingUp)
        {
            direction = Vector3.up;
        }
        else
        {
            direction = Vector3.down;
        }

        Vector3 tarPos = transform.position + (direction * tileSize);

        occupiedByPlayer = false;
        validMove = false;

        Collider2D[] hits = Physics2D.OverlapCircleAll(tarPos, 0.3f);

        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Player"))
            {
                occupiedByPlayer = true;
            }

            HighlightBox tile = hit.GetComponent<HighlightBox>();
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
            //set it to the opposite of what it is
            movingUp = !movingUp;

            Vector3 reverseDir;
            if (movingUp)
            {
                reverseDir = Vector3.up;
            }
            else
            {
                reverseDir = Vector3.down;
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

        enemyTurn = false;
        PlayerControllerOnGrid.playerTurn = true;
        PlayerControllerOnGrid.ableToMove = true;

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
