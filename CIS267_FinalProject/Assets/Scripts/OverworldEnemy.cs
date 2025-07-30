using UnityEngine;
using UnityEngine.SceneManagement;

public class OverworldEnemy : MonoBehaviour
{
    public string enemyID;
    private int digit;
    public GameObject healthPotion;
    public Transform spawn;
    private bool alreadyDefeated;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (GameManager.instance.IsEnemyDefeated(enemyID))
        {
            gameObject.SetActive(false);

            digit = Random.Range(0, 101);
            
            if (digit <= 50 && !GameManager.instance.IsEnemyDropped(enemyID))
            {
                Debug.Log("health potion drop" + " " + enemyID);

                Instantiate(healthPotion, gameObject.transform.position, Quaternion.identity);
                GameManager.instance.EnemeyDroppedHealth(enemyID);
            }
            else
            {
                GameManager.instance.EnemeyDroppedHealth(enemyID);
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
