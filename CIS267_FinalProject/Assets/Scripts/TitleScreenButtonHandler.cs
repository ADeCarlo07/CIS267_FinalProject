using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenButtonHandler : MonoBehaviour
{
    private bool isCrediting = false;
    public GameObject creditsPrefab;
    private GameObject activeCredits;

    void Update()
    {
        if (isCrediting && Input.anyKeyDown)
        {
            isCrediting = false;
            Destroy(activeCredits);
        }
    }
    public void startGame()
    {
        SceneManager.LoadScene("Level01");
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
        Time.timeScale = 1;
        SceneManager.LoadScene("LoadingScreen");
    }
}
