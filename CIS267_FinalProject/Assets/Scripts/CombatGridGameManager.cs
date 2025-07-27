using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CombatGridGameManager : MonoBehaviour
{
    public string enemyID;
    public GameObject player;
    public GameObject enemy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<HealthBarManager>().curHealth == 0)
        {
            SceneManager.LoadScene("GameOverScreen");
        }

        if (enemy.GetComponent<EnemyHealthBarManager>().curHealth == 0)
        {
            Debug.Log("enemy defeated");
            GameManager.instance.EnemyDefeated(enemyID);

            if (GameManager.instance.GetLastScene() == "Level01")
            {
                SceneManager.LoadScene("Level01");
            }
            if (GameManager.instance.GetLastScene() == "Level02")
            {
                SceneManager.LoadScene("Level02");
            }
            if (GameManager.instance.GetLastScene() == "Level03")
            {
                if (GameManager.instance.IsEnemyDefeated("Level03_Enemy03"))
                {
                    SceneManager.LoadScene("TitleScreen");
                }
                else
                {
                    SceneManager.LoadScene("Level03");
                }
                    
            }
            
        }
    }

   
}
