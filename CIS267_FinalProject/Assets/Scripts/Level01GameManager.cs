using UnityEngine;

public class Level01GameManager : MonoBehaviour
{
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
        
    }
}
