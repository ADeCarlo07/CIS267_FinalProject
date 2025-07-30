using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseCanvas;
    public static bool isPaused = false;
    public GameObject pauseFirstButton;
    private bool isCrediting = false;
    public GameObject creditsPrefab;
    public GameObject controlsPrefab;
    private GameObject activeCredits;

    public AudioClip pauseSFX;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }


    void Update()
    {
        pausingTheGame();

        if (isCrediting && (Input.anyKeyDown && !Input.GetKeyDown(KeyCode.JoystickButton0)))
        {
            isCrediting = false;
            Destroy(activeCredits);
        }
    }
    public void pausingTheGame()
    {
        //JoystickButton7 is the Start button on Xbox controllers
        if ((Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.JoystickButton7)))
        {
            if (!isPaused)
            {
                audioSource.PlayOneShot(pauseSFX);

                pauseCanvas.SetActive(true);
                Time.timeScale = 0;
                isPaused = true;
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(pauseFirstButton);
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

        //if (GameManager.instance.sliceFound == true)
        //{
        //    GameManager.instance.sliceFound = false;
        //}
        //if (GameManager.instance.shutDownFound == true)
        //{
        //    GameManager.instance.shutDownFound = false;
        //}
        //if (GameManager.instance.seedShotFound == true)
        //{
        //    GameManager.instance.seedShotFound = false;
        //}

        //if (GameManager.instance.IsEnemyDefeated("Level01_Enemy01"))
        //{
        //    GameManager.instance.RemoveDefeatedEnemy("Level01_Enemy01");
        //}
        //if (GameManager.instance.IsEnemyDefeated("Level01_Enemy02"))
        //{

        //    GameManager.instance.RemoveDefeatedEnemy("Level01_Enemy02");
        //}
        //if (GameManager.instance.IsEnemyDefeated("Level01_Enemy03"))
        //{
        //    GameManager.instance.RemoveDefeatedEnemy("Level01_Enemy03");
        //}

        //gonna try something else real quick - nick
        Destroy(GameManager.instance);
        InventoryManager.playerItems[0] = null;
        InventoryManager.playerItems[1] = null;
        InventoryManager.playerItems[2] = null;

        Time.timeScale = 1;
        SceneManager.LoadScene("LoadingScreen");
       
        //SceneManager.LoadScene("Level01");



        
    }
    public void viewControls()
    {
        if (!isCrediting)
        {
            isCrediting = true;
            activeCredits = Instantiate(controlsPrefab);
        }
    }
    public void viewCredits()
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
        InventoryManager.playerItems[0] = null;
        InventoryManager.playerItems[1] = null;
        InventoryManager.playerItems[2] = null;
        isPaused = false;
        SceneManager.LoadScene("TitleScreen");
        Time.timeScale = 1;
    }
}
