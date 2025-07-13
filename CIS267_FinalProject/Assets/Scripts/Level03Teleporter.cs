using Unity.Cinemachine;
using UnityEngine;

public class Level03Teleporter : MonoBehaviour
{
    public GameObject teleportLocation;
    public GameObject player;
    //public Camera cam;
    public CinemachineCamera cam02;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.transform.position = teleportLocation.transform.position;
            //cam.transform.position = teleportLocation.transform.position;
            //cam02.transform.position = teleportLocation.transform.position;

            cam02.Priority = 20;
        }
    }
}
