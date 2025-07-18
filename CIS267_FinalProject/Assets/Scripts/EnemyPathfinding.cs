using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Cinemachine.IInputAxisOwner.AxisDescriptor;

public class EnemyPathfinding : MonoBehaviour
{
  
    private Vector3 origPos;
    private Vector3 targetPos;

    public float tileSize = 1.4f;
    private float timeToMove = 0.2f;
    public static bool enemyTurn;
    public GameObject attackRadius;


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

                FindingPath();
            }
 
        }
    }

    private void FindingPath()
    {
        Debug.Log("finding path");
        GameObject[] highlightedBoxes = GameObject.FindGameObjectsWithTag("EnemyHighlightedBox");
        GameObject closestPos = null;
        GameObject retreatTile = null;

        //this is set to infinity so that way at the start you will always find
        //a distance smaller than it
        float shortestDistance = Mathf.Infinity;
        float longestDistance = 0f;
        float diagonalDistance = tileSize * Mathf.Sqrt(2f);
        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;

        foreach (GameObject highlightedBox in highlightedBoxes)
        {
            HighlightBox highlight = highlightedBox.GetComponent<HighlightBox>();

            if (highlight != null && highlight.highlighted)
            {
                float distance = Vector3.Distance(highlightedBox.transform.position, playerPos);
 
                float distanceToPlayer = Vector3.Distance(highlightedBox.transform.position, playerPos);
                float distanceFromEnemy = Vector3.Distance(highlightedBox.transform.position, transform.position);

                bool occupiedByPlayer = false;
                Collider2D[] hits = Physics2D.OverlapCircleAll(highlightedBox.transform.position, 0.3f);
                foreach (Collider2D hit in hits)
                {
                    if (hit.CompareTag("Player"))
                    {
                        occupiedByPlayer = true;
                        break;
                    }
                }



                //gives some room for it to be off with the (distanceFromEnemy - tilesize) < 0.1f, but this ensures
                //that the enemy only moves once. This is so it doesn't just run towards the enemy
                //and so it's turned based
                //diagonalDistance is typically a tilesize * root(2), so it's set to that and used
                //instead of tilesize. This is because diagonal distance doesn't fit into the
                //Mathf.Abs(distanceFromEnemy - tileSize) < 0.1f range, so it needs an extra place.
                //the 0.1f is tolerance threshold
                if (!RangeFromPlayer.playerTooClose && !occupiedByPlayer && (Mathf.Abs(distanceFromEnemy - tileSize) < 0.1f || Mathf.Abs(distanceFromEnemy - diagonalDistance) < 0.1f))
                {
                    if (distanceToPlayer < shortestDistance)
                    {
                        shortestDistance = distanceToPlayer;
                        closestPos = highlightedBox;
                    }
                }
            }
        }

        foreach (GameObject box in highlightedBoxes)
        {
            HighlightBox retreatHighlight = box.GetComponent<HighlightBox>();
            if (retreatHighlight != null && retreatHighlight.highlighted)
            {
                float retreatDistanceToPlayer = Vector3.Distance(box.transform.position, playerPos);
                float retreatDistanceFromEnemy = Vector3.Distance(box.transform.position, transform.position);
                bool isFartherFromPlayer = retreatDistanceToPlayer > Vector3.Distance(transform.position, playerPos);

                bool occupiedByPlayer = false;

                Collider2D[] hits = Physics2D.OverlapCircleAll(box.transform.position, 0.3f);
                foreach (Collider2D hit in hits)
                {
                    if (hit.CompareTag("Player"))
                    { 
                        occupiedByPlayer = true; 
                        break; 
                    }
                }

                if (RangeFromPlayer.playerTooClose && !occupiedByPlayer && isFartherFromPlayer && (Mathf.Abs(retreatDistanceFromEnemy - tileSize) < 0.1f || Mathf.Abs(retreatDistanceFromEnemy - diagonalDistance) < 0.1f))
                {
                    if (retreatDistanceToPlayer > longestDistance)
                    {
                        longestDistance = retreatDistanceToPlayer;
                        retreatTile = box;
                    }
                }
            }
        }

        if (RangeFromPlayer.playerTooClose && retreatTile != null)
        {
            Debug.Log("retreating");
            StartCoroutine(MoveEnemy(retreatTile.transform.position));
            enemyTurn = false;
            PlayerControllerOnGrid.playerTurn = true;
        }

        else if (!RangeFromPlayer.playerTooClose && closestPos != null)
        {
            Debug.Log("advancing");
            StartCoroutine(MoveEnemy(closestPos.transform.position));
            enemyTurn = false;
            PlayerControllerOnGrid.playerTurn = true;
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
