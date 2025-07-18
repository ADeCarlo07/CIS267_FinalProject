using UnityEngine;
using UnityEngine.SceneManagement;

public class OverworldEnemy : MonoBehaviour
{
    public string enemyID;
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (GameManager.instance.IsEnemyDefeated(enemyID))
        {
            gameObject.SetActive(false);


        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.instance.SavePlayerPos(player.transform.position);
        SceneManager.LoadScene("Level01_CombatGrid01");
    }
}
