using UnityEngine;

public class Level01GameManager : MonoBehaviour
{
    public GameObject slice;
    public GameObject seedShot;
    public GameObject shutDown;
    public GameObject player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (GameManager.instance.IsPlayerPosSaved())
        {
            player.transform.position = GameManager.instance.GetPlayerPos();
        }
  
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.sliceFound)
        {
            slice.SetActive(false);
        }

        if (GameManager.instance.seedShotFound)
        {
            seedShot.SetActive(false);
        }

        if (GameManager.instance.shutDownFound)
        {
            shutDown.SetActive(false);
        }
    }
}
