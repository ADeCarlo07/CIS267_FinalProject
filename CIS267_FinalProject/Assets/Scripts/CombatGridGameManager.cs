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
            SceneManager.LoadScene("Level01");
        }
    }

   
}
