using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas;
    private bool isPaused = false;
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
        SceneManager.LoadScene("TitleScreen");
        Time.timeScale = 1;
    }
}
