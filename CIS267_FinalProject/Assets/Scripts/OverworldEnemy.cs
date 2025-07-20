using UnityEngine;
using UnityEngine.SceneManagement;

public class OverworldEnemy : MonoBehaviour
{
    public string enemyID;
    private int digit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (GameManager.instance.IsEnemyDefeated(enemyID))
        {
            gameObject.SetActive(false);

            digit = Random.Range(0, 101);
            
            if (digit <= 25)
            {
                Debug.Log("health potion drop");

                // health potion
            }
  
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
