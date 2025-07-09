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
        Vector3 tarPos = transform.position + (Vector3.left * tileSize);
        //gets all colliders in the area
        Collider2D[] hits = Physics2D.OverlapCircleAll(tarPos, 0.3f);

        occupiedByPlayer = false;
        validMove = false;

        if (movingLeft)
        {
            direction = Vector3.left;
        }
        else
        {
            direction = Vector3.right;
        }

        GameObject[] highlightedBoxes = GameObject.FindGameObjectsWithTag("EnemyHighlightedBox");

        foreach (GameObject highlightedBox in highlightedBoxes)
        {
           

            for (int i = 0; i < hits.Length; i++)
            {
                HighlightBox tile = hits[i].GetComponent<HighlightBox>();
                if (tile != null && tile.highlighted)
                {
                    validMove = true;
                    break;
                }
            }

          
            
        }

        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Player"))
            {
                occupiedByPlayer = true;
                break;
            }
        }

        if (validMove && !occupiedByPlayer)
        {
            StartCoroutine(MoveEnemy(transform.position + (direction * tileSize)));
            enemyTurn = false;
            PlayerControllerOnGrid.playerTurn = true;
            PlayerControllerOnGrid.ableToMove = true;
        }
        else
        {
            movingLeft = false;
            Vector3 reverseDir;
            if (movingLeft)
            {
                reverseDir = Vector3.left;
            }
            else
            {
                reverseDir = Vector3.right;
            }

            Vector3 reversePos = transform.position + (reverseDir * tileSize);

            validMove = false;
            occupiedByPlayer = false;

            Collider2D[] reverseHits = Physics2D.OverlapCircleAll(reversePos, 0.3f);
            foreach (Collider2D hit in reverseHits)
            {
                HighlightBox tile = hit.GetComponent<HighlightBox>();
                if (tile != null && tile.highlighted)
                {
                    validMove = true;
                }

                if (hit.CompareTag("Player"))
                {
                    occupiedByPlayer = true;
                }
            }

            if (validMove && !occupiedByPlayer)
            {
                StartCoroutine(MoveEnemy(reversePos));
                enemyTurn = false;
                PlayerControllerOnGrid.playerTurn = true;
                PlayerControllerOnGrid.ableToMove = true;
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
}
