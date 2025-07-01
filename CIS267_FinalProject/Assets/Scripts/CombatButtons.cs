using UnityEngine;
using UnityEngine.UI;

public class CombatButtons : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void skipMovementButton()
    {
        //this is very basic, not meant to be final

        Debug.Log("skip movement button pressed");
        PlayerControllerOnGrid.ableToMove = false;
    }

    public void attackButton()
    {
        //put attack stuff here
        Debug.Log("attack button pressed");
    }
}
