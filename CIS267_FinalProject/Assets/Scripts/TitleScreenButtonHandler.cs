using UnityEngine;

public class TitleScreenButtonHandler : MonoBehaviour
{
    public void startGame()
    {
        //this will load our first scene, commented out until we decide what said scene's name will be
        //SceneManager.LoadScene("Level01");
    }
    public void exitGame()
    {
        Application.Quit();
    }
}
