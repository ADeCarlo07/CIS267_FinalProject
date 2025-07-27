using UnityEngine;
using UnityEngine.SceneManagement;

public class OverworldEnemy : MonoBehaviour
{
    public string enemyID;
    private int digit;
    public GameObject healthPotion;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (GameManager.instance.IsEnemyDefeated(enemyID))
        {
            gameObject.SetActive(false);

            digit = Random.Range(0, 101);
            
            if (digit <= 50)
            {
                Debug.Log("health potion drop");

                healthPotion.SetActive(true);
            }
  
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
