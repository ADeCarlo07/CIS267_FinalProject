using TMPro;
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
        if (SceneManager.GetActiveScene().name == "Level01")
        {
            GameManager.instance.level01SceneLoadCount++;
        }
        if (SceneManager.GetActiveScene().name == "Level02")
        {
            GameManager.instance.level02SceneLoadCount++;
        }
        if (SceneManager.GetActiveScene().name == "Level03")
        {
            GameManager.instance.level03SceneLoadCount++;
        }

        if (GameManager.instance.IsPlayerPosSaved() && SceneManager.GetActiveScene().name == "Level01" && GameManager.instance.level01SceneLoadCount != 1)
        {
            player.transform.position = GameManager.instance.GetPlayerPos();
        }
        if (GameManager.instance.IsPlayerPosSaved() && SceneManager.GetActiveScene().name == "Level02" && GameManager.instance.level02SceneLoadCount != 1)
        {
            player.transform.position = GameManager.instance.GetPlayerPos();
        }
        if (GameManager.instance.IsPlayerPosSaved() && SceneManager.GetActiveScene().name == "Level03" && GameManager.instance.level03SceneLoadCount != 1)
        {
            player.transform.position = GameManager.instance.GetPlayerPos();
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Level01")
        {
            if (GameManager.instance.sliceFound && slice != null)
            {
                slice.SetActive(false);
            }

            if (GameManager.instance.seedShotFound && seedShot != null)
            {
                seedShot.SetActive(false);
            }

            if (GameManager.instance.shutDownUsed && shutDown != null)
            {
                shutDown.SetActive(false);
            }

            if (GameManager.instance.lifeLeechFound && lifeLeech != null)
            {
                lifeLeech.SetActive(false);
            }
        }

        if (SceneManager.GetActiveScene().name == "Level02")
        {
            if (GameManager.instance.detonateFound && detonate != null)
            {
                detonate.SetActive(false);
            }

            if (GameManager.instance.sporeCloudFound && sporeCloud != null)
            {
                sporeCloud.SetActive(false);
            }

            if (GameManager.instance.burrowFound && burrow != null)
            {
                burrow.SetActive(false);
            }
        }

        if (SceneManager.GetActiveScene().name == "Level03")
        {
            if (GameManager.instance.lazerBeamFound && lazerBeam != null)
            {
                lazerBeam.SetActive(false);
            }
        }


    }
}
