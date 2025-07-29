using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class CombatGridGameManager : MonoBehaviour
{
    public string enemyID;
    public GameObject player;
    public GameObject enemy;

    //just used for final screen
    private bool isCrediting = false;
    public GameObject creditsPrefab;
    private GameObject activeCredits;
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
                if (!GameManager.instance.IsEnemyDefeated("Level03_Enemy03"))
                {
                   
                    SceneManager.LoadScene("Level03");
                }
                else
                {
                    //SceneManager.LoadScene("TitleScreen");
                    if (!isCrediting)
                    {
                        isCrediting = true;
                        activeCredits = Instantiate(creditsPrefab);
                    }
                }
                    
            }
            
        }


        if (isCrediting && (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.JoystickButton0)))
        {
            SceneManager.LoadScene("TitleScreen");
        }
    }

   
}
