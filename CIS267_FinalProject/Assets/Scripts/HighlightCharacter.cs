using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

public class HighlightCharacter : MonoBehaviour
{
    public bool selected;
    public GameObject highlight;
    public GameObject movementRadius;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void recenterRadius()
    {
        movementRadius.SetActive(false);
        //movementRadius.transform.SetParent(transform, false);
        movementRadius.transform.position = transform.position;
        movementRadius.SetActive(true);


    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerControllerOnGrid.canMove == false)
        {
            if (movementRadius.transform.parent != null)
            {
                movementRadius.transform.parent = null;
            }
           
        }
   


        //if (selected)
        //{

        //    //highlight.SetActive(true);
        //    movementRadius.SetActive(true);
        //}
        //if (!selected)
        //{
        //    //highlight.SetActive(false);
        //    movementRadius.SetActive(false);
        //}
    }
}
