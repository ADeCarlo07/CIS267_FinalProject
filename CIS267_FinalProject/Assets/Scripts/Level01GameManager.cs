using UnityEngine;
using UnityEngine.SceneManagement;

public class Level01GameManager : MonoBehaviour
{
    public GameObject slice;
    public GameObject seedShot;
    public GameObject shutDown;
    public GameObject player;
    public GameObject lifeLeech;
    public GameObject detonate;
    public GameObject burrow;
    public GameObject sporeCloud;
    public GameObject lazerBeam;
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
        if (SceneManager.GetActiveScene().name == "Level01")
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

            if (GameManager.instance.lifeLeechFound)
            {
                lifeLeech.SetActive(false);
            }
        }

        if (SceneManager.GetActiveScene().name == "Level02")
        {
            if (GameManager.instance.detonateFound)
            {
                detonate.SetActive(false);
            }

            if (GameManager.instance.sporeCloudFound)
            {
                sporeCloud.SetActive(false);
            }

            if (GameManager.instance.burrowFound)
            {
                burrow.SetActive(false);
            }
        }

        if (SceneManager.GetActiveScene().name == "Level03")
        {
            if (GameManager.instance.lazerBeamFound)
            {
                lazerBeam.SetActive(false);
            }
        }


    }
}
