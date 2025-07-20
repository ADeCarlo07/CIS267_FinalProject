using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas;
    public static bool isPaused = false;
    void Start()
    {
        
    }


    void Update()
    {
        pausingTheGame();
    }
    public void pausingTheGame()
    {
        //JoystickButton7 is the Start button on Xbox controllers
        if ((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton7)))
        {
            if (!isPaused)
            {
                pauseCanvas.SetActive(true);
                Time.timeScale = 0;
                isPaused = true;
            }
            else
            {
                resumeGame();
            }
        }
    }
    public void resumeGame()
    {
        pauseCanvas.SetActive(false);
        Time.timeScale = 1;
        isPaused = false;
    }
    public void startOver()
    {
        //might need to do more than this cause of other variables, we'll see

        // yeah sorry I added this to this function and start over
        //because things weren't properly resetting - Allison
        isPaused = false;

        if (GameManager.instance.sliceFound == true)
        {
            GameManager.instance.sliceFound = false;
        }
        if (GameManager.instance.shutDownFound == true)
        {
            GameManager.instance.shutDownFound = false;
        }
        if (GameManager.instance.seedShotFound == true)
        {
            GameManager.instance.seedShotFound = false;
        }
        
        if (GameManager.instance.IsEnemyDefeated("Level01_Enemy01"))
        {
            GameManager.instance.RemoveDefeatedEnemy("Level01_Enemy01");
        }
        if (GameManager.instance.IsEnemyDefeated("Level01_Enemy02"))
        {

            GameManager.instance.RemoveDefeatedEnemy("Level01_Enemy02");
        }
        if (GameManager.instance.IsEnemyDefeated("Level01_Enemy03"))
        {
            GameManager.instance.RemoveDefeatedEnemy("Level01_Enemy03");
        }

       
        SceneManager.LoadScene("Level01");

        Time.timeScale = 1;
    }
    public void viewControls()
    {

    }
    public void viewCredits()
    {

    }
    public void exitToMainMenu()
    {
        Destroy(GameManager.instance);
        isPaused = false;
        SceneManager.LoadScene("TitleScreen");
        Time.timeScale = 1;
    }
}
