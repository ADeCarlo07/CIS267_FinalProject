using UnityEngine;
using UnityEngine.SceneManagement;

public class TEST_LOADNEXTLEVEL : MonoBehaviour
{
    //this script is just for ensuring all levels can be seen on a build
    public int levelToLoad;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (levelToLoad == 2)
            {
                SceneManager.LoadScene("Level02");
            }
            else if (levelToLoad == 3)
            {
                SceneManager.LoadScene("Level03");
            }
            
                
        }
        
    }



}
