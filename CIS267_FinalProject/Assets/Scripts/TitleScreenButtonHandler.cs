using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreenButtonHandler : MonoBehaviour
{
    public void startGame()
    {
        SceneManager.LoadScene("Level01");
    }
    public void exitGame()
    {
        Application.Quit();
    }
}
