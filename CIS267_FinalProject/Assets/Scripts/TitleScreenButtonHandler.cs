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
    public void exitToMainMenu()
    {
        Destroy(GameManager.instance);
        SceneManager.LoadScene("TitleScreen");
    }
}
