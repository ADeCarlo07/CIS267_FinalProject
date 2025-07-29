using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenButtonHandler : MonoBehaviour
{
    private bool isCrediting = false;
    public GameObject creditsPrefab;
    public GameObject controlsPrefab;
    private GameObject activeCredits;

    void Update()
    {
        if (isCrediting && (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.JoystickButton0)))
        {
            isCrediting = false;
            Destroy(activeCredits);
        }
    }
    public void startGame()
    {
        SceneManager.LoadScene("Level01");
    }
    public void firstStart()
    {
        SceneManager.LoadScene("Story");
    }
    public void exitGame()
    {
        Application.Quit();
    }
    public void creditsButton()
    {
        if (!isCrediting)
        {
            isCrediting = true;
            activeCredits = Instantiate(creditsPrefab);
        }
    }
    public void controlsButton()
    {
        if (!isCrediting)
        {
            isCrediting = true;
            activeCredits = Instantiate(controlsPrefab);
        }
    }

    //these functions are edited from PauseMenu.cs so this script can just be used in the game over
    //scene as well

    public void exitToMainMenu()
    {
        Destroy(GameManager.instance);
        SceneManager.LoadScene("TitleScreen");
    }
    public void startOver()
    {
        Destroy(GameManager.instance);
        InventoryManager.playerItems[0] = null;
        InventoryManager.playerItems[1] = null;
        InventoryManager.playerItems[2] = null;
        Time.timeScale = 1;
        SceneManager.LoadScene("LoadingScreen");
    }
}
