using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerOnGrid : MonoBehaviour
{
    private float inputVertical;
    private float inputHorizontal;
    public static bool playerTurn;
    private int currentIndex = 0;
    public GameObject[] partyMembers;
    private int partyLength;
    private GameObject selectedCharacter;
    public static bool canMove;
    private float inputWaitTime = 0;
    private float inputCoolDown = 0.2f;
    public static bool inMovementBounds = true;
    public Transform movePoint;
    private Vector3 origPos;
    private Vector3 targetPos;
    private float timeToMove = 0.2f;
    private bool isMoving;
    public float tileSize = 1.4f;
    public static bool validMove;
    private Vector3 startPos;
    private bool startPosFound;
    public static bool playerMoved;
    //private bool start;
    public static bool ableToMove;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ableToMove = true;
        //start = true;
        partyMembers[0].tag = "Player";
        selectedCharacter = partyMembers[0];
        partyMembers[0].GetComponent<HighlightCharacter>().selected = true;
      
        partyLength = partyMembers.Length;
        playerTurn = true;
        canMove = true;
        
    }

    private void moveToSelectedCharacter()
    {
        //this function isn't useful anymore. Was only to be used if there was multiple characters/players in the party!!!!!
        //Just in case some pieces of code are useful I will keep it
        if (playerTurn && canMove)
        {
            inputVertical = Input.GetAxisRaw("Vertical");

            if (Time.time >= inputWaitTime)
            {
                if (inputVertical == 1)
                {
                    //start = false;
                    // % partyMembers.Length is so it loops around back to the beginning
                    currentIndex = (currentIndex - 1 + partyLength) % partyLength;
                    selectedCharacter = partyMembers[currentIndex];
                    inputWaitTime = Time.time + inputCoolDown;

                    for (int i = 0; i < partyLength; i++)
                    {
                        if (i == currentIndex)
                        {
                        
                            selectedCharacter.GetComponent<HighlightCharacter>().selected = true;
                     

                            selectedCharacter.tag = "Player";
                        }
                        else
                        {
                            partyMembers[i].tag = "OtherPlayer";
                            partyMembers[i].GetComponent<HighlightCharacter>().selected = false;

                        }
                    }

                    
                    //highlightCharacter(selectedCharacter);

                }
                else if (inputVertical == -1)
                {
                    //start = false;
                    currentIndex = (currentIndex + 1) % partyLength;
                    selectedCharacter = partyMembers[currentIndex];
                    inputWaitTime = Time.time + inputCoolDown;

                    for (int i = 0; i < partyLength; i++)
                    {
                        if (i == currentIndex)
                        {
                            selectedCharacter.GetComponent<HighlightCharacter>().selected = true;

                            selectedCharacter.tag = "Player";
                        }
                        else
                        {
                            partyMembers[i].tag = "OtherPlayer";
                            partyMembers[i].GetComponent<HighlightCharacter>().selected = false;

                        }
                    }

                   
                    //highlightCharacter(selectedCharacter);
                }

            }

        }
    }

    private void moveSelectedCharacter()
    {
        if (playerTurn && ableToMove)
        {

            if (Gamepad.current == null)
            {
                if (Keyboard.current.leftShiftKey.isPressed)
                {
                    if (!startPosFound)
                    {
                        startPos = selectedCharacter.transform.position;
                        Debug.Log(startPos);
                        startPosFound = true;

                    }

                    canMove = false;


                    if (inputHorizontal == 1 && !isMoving && inMovementBounds)
                    {

                        //right
                        Vector3 tarPos = selectedCharacter.transform.position + (Vector3.right * tileSize);
                        //gets all colliders in the area
                        Collider2D[] hits = Physics2D.OverlapCircleAll(tarPos, 0.3f);

                        validMove = false;
                        for (int i = 0; i < hits.Length; i++)
                        {
                            HighlightBox tile = hits[i].GetComponent<HighlightBox>();
                            if (tile != null && tile.highlighted)
                            {
                                validMove = true;
                                break;
                            }
                        }

                        if (validMove)
                        {
                            StartCoroutine(MoveSelectedCharacter(Vector3.right));
                        }

                    }
                    if (inputHorizontal == -1 && !isMoving && inMovementBounds)
                    {

                        //left
                        Vector3 tarPos = selectedCharacter.transform.position + (Vector3.left * tileSize);
                        //gets all colliders in the area
                        Collider2D[] hits = Physics2D.OverlapCircleAll(tarPos, 0.3f);

                        validMove = false;
                        for (int i = 0; i < hits.Length; i++)
                        {
                            HighlightBox tile = hits[i].GetComponent<HighlightBox>();
                            if (tile != null && tile.highlighted)
                            {
                                validMove = true;
                                break;
                            }
                        }

                        if (validMove)
                        {
                            StartCoroutine(MoveSelectedCharacter(Vector3.left));
                        }

                    }
                    if (inputVertical == 1 && !isMoving && inMovementBounds)
                    {

                        //up
                        Vector3 tarPos = selectedCharacter.transform.position + (Vector3.up * tileSize);
                        //gets all colliders in the area
                        Collider2D[] hits = Physics2D.OverlapCircleAll(tarPos, 0.3f);

                        validMove = false;
                        for (int i = 0; i < hits.Length; i++)
                        {
                            HighlightBox tile = hits[i].GetComponent<HighlightBox>();
                            if (tile != null && tile.highlighted)
                            {
                                validMove = true;
                                break;
                            }
                        }

                        if (validMove)
                        {
                            StartCoroutine(MoveSelectedCharacter(Vector3.up));
                        }
                    }
                    if (inputVertical == -1 && !isMoving && inMovementBounds)
                    {

                        //down
                        Vector3 tarPos = selectedCharacter.transform.position + (Vector3.down * tileSize);
                        //gets all colliders in the area
                        Collider2D[] hits = Physics2D.OverlapCircleAll(tarPos, 0.3f);

                        validMove = false;
                        for (int i = 0; i < hits.Length; i++)
                        {
                            HighlightBox tile = hits[i].GetComponent<HighlightBox>();
                            if (tile != null && tile.highlighted)
                            {
                                validMove = true;
                                break;
                            }
                        }

                        if (validMove)
                        {
                            StartCoroutine(MoveSelectedCharacter(Vector3.down));
                        }

                    }
                }


                //======================
                if (Keyboard.current.eKey.wasPressedThisFrame)
                {
                    Debug.Log("b was pressed");
                    canMove = true;


                    selectedCharacter.transform.position = startPos;
                    startPosFound = false;

                    //clearHighlightBoxes();
                }

                //=======================
                if (Keyboard.current.qKey.wasPressedThisFrame)
                {

                    Debug.Log("x was pressed");



                    //if (!start)
                    //{
                    //    clearHighlightBoxes();
                    //}

                    selectedCharacter.GetComponent<HighlightCharacter>().recenterRadius();

                    ableToMove = false;
                    canMove = true;

                    playerMoved = true;

                    playerTurn = false;
                    EnemyPathfinding.enemyTurn = true;
                    EnemyMovementLeftRight.enemyTurn = true;
                }

            }

            else if (Gamepad.current.aButton.isPressed)
            {
              
                if (!startPosFound)
                {
                    startPos = selectedCharacter.transform.position;
                    Debug.Log(startPos);
                    startPosFound = true;

                }

                canMove = false;


                if (inputHorizontal == 1 && !isMoving && inMovementBounds)
                {
                 
                    //right
                    Vector3 tarPos = selectedCharacter.transform.position + (Vector3.right * tileSize);
                    //gets all colliders in the area
                    Collider2D[] hits = Physics2D.OverlapCircleAll(tarPos, 0.3f);

                    validMove = false;
                    for (int i = 0; i < hits.Length; i++)
                    {
                        HighlightBox tile = hits[i].GetComponent<HighlightBox>();
                        if (tile != null && tile.highlighted)
                        {
                            validMove = true;
                            break;
                        }
                    }

                    if (validMove)
                    {
                        StartCoroutine(MoveSelectedCharacter(Vector3.right));
                    }

                }
                if (inputHorizontal == -1 && !isMoving && inMovementBounds)
                {
                  
                    //left
                    Vector3 tarPos = selectedCharacter.transform.position + (Vector3.left * tileSize);
                    //gets all colliders in the area
                    Collider2D[] hits = Physics2D.OverlapCircleAll(tarPos, 0.3f);

                    validMove = false;
                    for (int i = 0; i < hits.Length; i++)
                    {
                        HighlightBox tile = hits[i].GetComponent<HighlightBox>();
                        if (tile != null && tile.highlighted)
                        {
                            validMove = true;
                            break;
                        }
                    }

                    if (validMove)
                    {
                        StartCoroutine(MoveSelectedCharacter(Vector3.left));
                    }

                }
                if (inputVertical == 1 && !isMoving && inMovementBounds)
                {
             
                    //up
                    Vector3 tarPos = selectedCharacter.transform.position + (Vector3.up * tileSize);
                    //gets all colliders in the area
                    Collider2D[] hits = Physics2D.OverlapCircleAll(tarPos, 0.3f);

                    validMove = false;
                    for (int i = 0; i < hits.Length; i++)
                    {
                        HighlightBox tile = hits[i].GetComponent<HighlightBox>();
                        if (tile != null && tile.highlighted)
                        {
                            validMove = true;
                            break;
                        }
                    }

                    if (validMove)
                    {
                        StartCoroutine(MoveSelectedCharacter(Vector3.up));
                    }
                }
                if (inputVertical == -1 && !isMoving && inMovementBounds)
                {
           
                    //down
                    Vector3 tarPos = selectedCharacter.transform.position + (Vector3.down * tileSize);
                    //gets all colliders in the area
                    Collider2D[] hits = Physics2D.OverlapCircleAll(tarPos, 0.3f);

                    validMove = false;
                    for (int i = 0; i < hits.Length; i++)
                    {
                        HighlightBox tile = hits[i].GetComponent<HighlightBox>();
                        if (tile != null && tile.highlighted)
                        {
                            validMove = true;
                            break;
                        }
                    }

                    if (validMove)
                    {
                        StartCoroutine(MoveSelectedCharacter(Vector3.down));
                    }

                }
            }

            
            //====================================================================
            else if (Gamepad.current.bButton.wasPressedThisFrame)
            {
                Debug.Log("b was pressed");
                canMove = true;


                selectedCharacter.transform.position = startPos;
                startPosFound = false;

                //clearHighlightBoxes();

            }


            //================================================================
            else if (Gamepad.current.xButton.wasPressedThisFrame)
            {

                Debug.Log("x was pressed");


               
                //if (!start)
                //{
                //    clearHighlightBoxes();
                //}

                selectedCharacter.GetComponent<HighlightCharacter>().recenterRadius();

                ableToMove = false;
                canMove = true;

                playerMoved = true;

                playerTurn = false;
                EnemyPathfinding.enemyTurn = true;
                EnemyMovementLeftRight.enemyTurn = true;
            }
            
        }
    }
    private void clearHighlightBoxes()
    {
        //This function was only used if there was multiple characters in the party!!!!
        //Could still be useful later on, so I wont delete
        GameObject[] allHighlights = GameObject.FindGameObjectsWithTag("HighlightedBox");

        foreach (GameObject box in allHighlights)
        {
            if (box != null)
            {
                HighlightBox highlight = box.GetComponent<HighlightBox>();
                if (highlight != null)
                {
                    highlight.highlighted = false;
                }
            }
        }
    }

    private IEnumerator MoveSelectedCharacter(Vector3 direction)
    {
        isMoving = true;

        float elapsedTime = 0;
        origPos = selectedCharacter.transform.position;
        targetPos = origPos + (direction * tileSize);

        while (elapsedTime < timeToMove)
        {
            //lerp is for smooth transition
            selectedCharacter.transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        selectedCharacter.transform.position = targetPos;

        isMoving = false;
        
    }

  

    private void highlightCharacter(GameObject selCharacter)
    {
        Debug.Log("Character selected" + currentIndex);
     
    }

    // Update is called once per frame
    void Update()
    {
       
        inputVertical = Input.GetAxisRaw("Vertical");
        inputHorizontal = Input.GetAxisRaw("Horizontal");

        //moveToSelectedCharacter();
        moveSelectedCharacter();
        
    }
}
