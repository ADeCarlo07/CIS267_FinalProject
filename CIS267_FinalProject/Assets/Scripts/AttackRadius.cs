using UnityEngine;

public class AttackRadius : MonoBehaviour
{
    public bool playerInRadius;
    public static bool canMove;
    public bool enemyInRadius;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player in radius");
            playerInRadius = true;
            canMove = false;
            
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyInRadius = true;
        }

        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player out of radius" + gameObject);
            playerInRadius = false;
            canMove = true;
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyInRadius = false;
        }
    }
}
