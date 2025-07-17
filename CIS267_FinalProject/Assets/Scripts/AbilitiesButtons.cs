using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class AbilitiesButtons : MonoBehaviour
{
    private bool isMoving;
    public GameObject burrowMoveBox;
    private Vector3 origPos;
    private Vector3 targetPos;
    private float timeToMove = 0.2f;
    public float tileSize = 1.4f;
    private float inputVertical;
    private float inputHorizontal;
    private bool occupiedByEnemy;
    private bool validMove;
    public GameObject abilityHolder;
    private bool burrowButtonPressed;
    public GameObject player;
    public Transform teleportPoint;
    public Button move;
    public Transform playerMovePoint;
    public GameObject playerMovementRadius;
    private SpriteRenderer sr;
    private Color transparent;
    private Color notTransparent;
    public GameObject dirtMound;
    private bool burrowOneTimeUse;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        burrowOneTimeUse = false;
        transparent.a = 0;
        notTransparent.a = 1;
        notTransparent.r = 1;
        notTransparent.g = 1;
        notTransparent.b = 1;
        sr = player.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        inputVertical = Input.GetAxisRaw("Vertical");
        inputHorizontal = Input.GetAxisRaw("Horizontal");

        if (burrowButtonPressed && !burrowOneTimeUse)
        {
            sr.color = transparent;
            if (Gamepad.current == null)
            {

            }
            else
            {
                if (inputHorizontal == 1 && !isMoving)
                {

                    //right
                    Vector3 tarPos = player.transform.position + (Vector3.right * tileSize);
                    //gets all colliders in the area
                    Collider2D[] hits = Physics2D.OverlapCircleAll(tarPos, 0.3f);
                    validMove = true;

                    for (int i = 0; i < hits.Length; i++)
                    {
                        if (hits[i].CompareTag("Obstacle") || hits[i].CompareTag("Enemy") || hits[i].CompareTag("GridBorder"))
                        {
                            validMove = false;
                            break;
                        }
                    }

                    if (validMove)
                    {
                        StartCoroutine(BurrowMove(Vector3.right));
                    }

                }
                if (inputHorizontal == -1 && !isMoving)
                {
                    //left
                    Vector3 tarPos = player.transform.position + (Vector3.left * tileSize);

                    //gets all colliders in the area
                    Collider2D[] hits = Physics2D.OverlapCircleAll(tarPos, 0.3f);

                    validMove = true;

                    for (int i = 0; i < hits.Length; i++)
                    {
                        if (hits[i].CompareTag("Obstacle") || hits[i].CompareTag("Enemy") || hits[i].CompareTag("GridBorder"))
                        {
                            validMove = false;
                            break;
                        }
                    }

                    if (validMove)
                    {
                        StartCoroutine(BurrowMove(Vector3.left));
                    }
                }
                if (inputVertical == 1 && !isMoving)
                {
                    //up
                    Vector3 tarPos = player.transform.position + (Vector3.up * tileSize);

                    //gets all colliders in the area
                    Collider2D[] hits = Physics2D.OverlapCircleAll(tarPos, 0.3f);

                    validMove = true;

                    for (int i = 0; i < hits.Length; i++)
                    {
                        if (hits[i].CompareTag("Obstacle") || hits[i].CompareTag("Enemy") || hits[i].CompareTag("GridBorder"))
                        {
                            validMove = false;
                            break;
                        }
                    }

                    if (validMove)
                    {
                        StartCoroutine(BurrowMove(Vector3.up));
                    }
                }
                if (inputVertical == -1 && !isMoving)
                {
                    //down
                    Vector3 tarPos = player.transform.position + (Vector3.down * tileSize);

                    //gets all colliders in the area
                    Collider2D[] hits = Physics2D.OverlapCircleAll(tarPos, 0.3f);
                    validMove = true;

                    for (int i = 0; i < hits.Length; i++)
                    {
                        if (hits[i].CompareTag("Obstacle") || hits[i].CompareTag("Enemy") || hits[i].CompareTag("GridBorder"))
                        {
                            validMove = false;
                            break;
                        }
                    }

                    if (validMove)
                    {
                        StartCoroutine(BurrowMove(Vector3.down));

                    }
                }

                if (Gamepad.current.xButton.wasPressedThisFrame)
                {

                    dirtMound.SetActive(false);
                    sr.color = notTransparent;
                    //player.transform.position = teleportPoint.position;
                    //burrowMoveBox.transform.position = playerMovePoint.transform.position;
                    player.GetComponent<HighlightCharacter>().recenterRadius();

                    playerMovementRadius.SetActive(false);

                    PlayerControllerOnGrid.canMove = true;

                    burrowMoveBox.SetActive(false);
                    burrowButtonPressed = false;
                    PlayerControllerOnGrid.playerTurn = false;
                    EnemyPathfinding.enemyTurn = true;
                    EnemyMovementLeftRight.enemyTurn = true;
                    EnemyMovementUpDown.enemyTurn = true;

                    PlayerUIButtons.buttonPressed = false;
                    move.Select();
                    burrowOneTimeUse = true;
                }

                if (Gamepad.current.bButton.wasPressedThisFrame)
                {
                    dirtMound.SetActive(false);
                    sr.color = notTransparent;

                    burrowMoveBox.SetActive (false);
                    burrowMoveBox.transform.position = playerMovePoint.transform.position;
                    burrowButtonPressed = false;

                    PlayerUIButtons.buttonPressed = false;
                    move.Select();
                }
            }
        }
    }

    public void BurrowButton()
    {
        if (!burrowOneTimeUse)
        {
            dirtMound.SetActive(true);
            PlayerUIButtons.abilitiesButtonPressed = false;
            abilityHolder.SetActive(false);
            PlayerControllerOnGrid.playerTurn = true;
            burrowMoveBox.SetActive(true);
            burrowButtonPressed = true;
        }
        
       

    }

    public void SporeCloudButton()
    {

    }

    public void LifeLeechButton()
    {

    }

    public void SeedShotButton()
    {

    }

    public void SliceButton()
    {

    }

    public void LazerBeamButton()
    {

    }

    public void DetonateButton()
    {

    }

    public void ShutDownButton()
    {

    }

    private IEnumerator BurrowMove(Vector3 direction)
    {
        isMoving = true;

        float elapsedTime = 0;
        origPos = player.transform.position;
        targetPos = origPos + (direction * tileSize);

        while (elapsedTime < timeToMove)
        {
            //lerp is for smooth transition
            player.transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        player.transform.position = targetPos;

        isMoving = false;

    }
}
