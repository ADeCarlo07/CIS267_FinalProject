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
    private bool validMove;
    public GameObject abilityHolder;
    private bool burrowButtonPressed;
    public GameObject player;
    public Button move;
    public GameObject playerMovementRadius;
    private SpriteRenderer sr;
    private Color transparent;
    private Color notTransparent;
    public GameObject dirtMound;
    private bool burrowOneTimeUse;
    private Vector3 startPos;

    public GameObject sliceAttackRad;
    public GameObject detonateAttackRad;
    public GameObject lazerBeamAttackRad;
    public GameObject seedShotAttackRad;
    public GameObject sporeCloudAttackRad;
    public GameObject lifeLeechAttackRad;

    private bool sporeCloudButtonPressed;
    private bool seedShotButtonPressed;
    private bool sliceButtonPressed;
    private bool lazerBeamButtonPressed;
    private bool detonateButtonPressed;
    private bool lifeLeechButtonPressed;
    public GameObject enemy;
    public Transform playerMovePoint;
    public Transform otherMovePoint;
    private int timesDone;
    private int timesDone02;
    private int timesDone03;
    private int timesDone04;
    private int timesDone05;
    private int timesDone06;

    public string burrowID = "Burrow";
    public string sporeCloudID = "Spore Cloud";
    public string sliceID = "Slice";
    public string detonateID = "Detonate";
    public string lazerBeamID = "Lazer Beam";
    public string shutDownID = "Shut Down";
    public string seedShotID = "Seed Shot";
    public string lifeLeechID = "Life Leech";


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timesDone = 0;
        timesDone02 = 0;
        timesDone03 = 0;
        timesDone04 = 0;
        timesDone05 = 0;

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

                if (Keyboard.current.qKey.wasPressedThisFrame)
                {

                    dirtMound.SetActive(false);
                    sr.color = notTransparent;
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
                    PlayerUIButtons.abilitiesButtonPressed = false;
                    move.Select();
                    burrowOneTimeUse = true;

                }

                if (Keyboard.current.eKey.wasPressedThisFrame)
                {

                    dirtMound.SetActive(false);
                    sr.color = notTransparent;

                    burrowMoveBox.SetActive(false);
                    burrowButtonPressed = false;

                    PlayerUIButtons.buttonPressed = false;
                    PlayerUIButtons.abilitiesButtonPressed = false;

                    player.transform.position = startPos;


                    move.Select();

                }
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
                    PlayerUIButtons.abilitiesButtonPressed = false;

                    move.Select();
                    burrowOneTimeUse = true;

                }

                if (Gamepad.current.bButton.wasPressedThisFrame)
                {

                    dirtMound.SetActive(false);
                    sr.color = notTransparent;

                    burrowMoveBox.SetActive (false);
                    burrowButtonPressed = false;

                    PlayerUIButtons.buttonPressed = false;
                    PlayerUIButtons.abilitiesButtonPressed = false;

                    player.transform.position = startPos;
                    move.Select();

                }
            }
        }

        if (sporeCloudButtonPressed)
        {
            if (Gamepad.current == null)
            {
                if (Keyboard.current.qKey.wasPressedThisFrame)
                {
                    if (sporeCloudAttackRad.GetComponent<AttackRadius>().enemyInRadius && PlayerControllerOnGrid.playerTurn)
                    {
                        enemy.GetComponent<EnemyHealthBarManager>().TakeDamage(15);
                    }

                    sporeCloudAttackRad.SetActive(false);
                    sporeCloudButtonPressed = false;

                    PlayerControllerOnGrid.playerTurn = false;
                    EnemyPathfinding.enemyTurn = true;
                    EnemyMovementLeftRight.enemyTurn = true;
                    EnemyMovementUpDown.enemyTurn = true;

                    PlayerUIButtons.buttonPressed = false;
                    PlayerUIButtons.abilitiesButtonPressed = false;
                    move.Select();
                }
                if (Keyboard.current.eKey.wasPressedThisFrame)
                {
                    sporeCloudAttackRad.SetActive(false);
                    sporeCloudButtonPressed = false;
                    PlayerUIButtons.buttonPressed = false;
                    PlayerUIButtons.abilitiesButtonPressed = false;
                    move.Select();
                }
            }
            else
            {
                if (Gamepad.current.xButton.wasPressedThisFrame)
                {
                    if (sporeCloudAttackRad.GetComponent<AttackRadius>().enemyInRadius && PlayerControllerOnGrid.playerTurn)
                    {
                        enemy.GetComponent<EnemyHealthBarManager>().TakeDamage(15);
                    }

                    sporeCloudAttackRad.SetActive(false);
                    sporeCloudButtonPressed = false;

                    PlayerControllerOnGrid.playerTurn = false;
                    EnemyPathfinding.enemyTurn = true;
                    EnemyMovementLeftRight.enemyTurn = true;
                    EnemyMovementUpDown.enemyTurn = true;

                    PlayerUIButtons.buttonPressed = false;
                    PlayerUIButtons.abilitiesButtonPressed = false;
                    move.Select();
                }
                if (Gamepad.current.bButton.wasPressedThisFrame)
                {
                    sporeCloudAttackRad.SetActive(false);
                    sporeCloudButtonPressed = false;
                    PlayerUIButtons.buttonPressed = false;
                    PlayerUIButtons.abilitiesButtonPressed = false;
                    move.Select();
                }
            }
        }

        if (seedShotButtonPressed)
        {
            if (Gamepad.current == null)
            {
                if (Keyboard.current.qKey.wasPressedThisFrame)
                {
                    if (seedShotAttackRad.GetComponent<AttackRadius>().enemyInRadius && PlayerControllerOnGrid.playerTurn)
                    {
                        enemy.GetComponent<EnemyHealthBarManager>().TakeDamage(30);
                    }

                    seedShotAttackRad.SetActive(false);
                    seedShotButtonPressed = false;

                    PlayerControllerOnGrid.playerTurn = false;
                    EnemyPathfinding.enemyTurn = true;
                    EnemyMovementLeftRight.enemyTurn = true;
                    EnemyMovementUpDown.enemyTurn = true;

                    PlayerUIButtons.buttonPressed = false;
                    PlayerUIButtons.abilitiesButtonPressed = false;
                    move.Select();
                }
                if (Keyboard.current.eKey.wasPressedThisFrame)
                {
                    seedShotAttackRad.SetActive(false);
                    seedShotButtonPressed = false;
                    PlayerUIButtons.buttonPressed = false;
                    PlayerUIButtons.abilitiesButtonPressed = false;
                    move.Select();
                }
            }
            else
            {
                if (Gamepad.current.xButton.wasPressedThisFrame)
                {
                    if (seedShotAttackRad.GetComponent<AttackRadius>().enemyInRadius && PlayerControllerOnGrid.playerTurn)
                    {
                        enemy.GetComponent<EnemyHealthBarManager>().TakeDamage(30);
                    }

                    seedShotAttackRad.SetActive(false);
                    seedShotButtonPressed = false;

                    PlayerControllerOnGrid.playerTurn = false;
                    EnemyPathfinding.enemyTurn = true;
                    EnemyMovementLeftRight.enemyTurn = true;
                    EnemyMovementUpDown.enemyTurn = true;

                    PlayerUIButtons.buttonPressed = false;
                    PlayerUIButtons.abilitiesButtonPressed = false;
                    move.Select();
                }
                if (Gamepad.current.bButton.wasPressedThisFrame)
                {
                    seedShotAttackRad.SetActive(false);
                    seedShotButtonPressed = false;
                    PlayerUIButtons.buttonPressed = false;
                    PlayerUIButtons.abilitiesButtonPressed = false;
                    move.Select();
                }
            }
        }

        if (sliceButtonPressed)
        {
            if (Gamepad.current == null)
            {
                if (Keyboard.current.qKey.wasPressedThisFrame)
                {
                    if (sliceAttackRad.GetComponent<AttackRadius>().enemyInRadius && PlayerControllerOnGrid.playerTurn)
                    {
                        enemy.GetComponent<EnemyHealthBarManager>().TakeDamage(20);
                    }

                    sliceAttackRad.SetActive(false);
                    sliceButtonPressed = false;

                    PlayerControllerOnGrid.playerTurn = false;
                    EnemyPathfinding.enemyTurn = true;
                    EnemyMovementLeftRight.enemyTurn = true;
                    EnemyMovementUpDown.enemyTurn = true;

                    PlayerUIButtons.buttonPressed = false;
                    PlayerUIButtons.abilitiesButtonPressed = false;
                    move.Select();
                }
                if (Keyboard.current.eKey.wasPressedThisFrame)
                {
                    sliceAttackRad.SetActive(false);
                    sliceButtonPressed = false;
                    PlayerUIButtons.buttonPressed = false;
                    PlayerUIButtons.abilitiesButtonPressed = false;
                    move.Select();
                }
            }
            else
            {
                if (Gamepad.current.xButton.wasPressedThisFrame)
                {
                    if (sliceAttackRad.GetComponent<AttackRadius>().enemyInRadius && PlayerControllerOnGrid.playerTurn)
                    {
                        enemy.GetComponent<EnemyHealthBarManager>().TakeDamage(20);
                    }

                    sliceAttackRad.SetActive(false);
                    sliceButtonPressed = false;

                    PlayerControllerOnGrid.playerTurn = false;
                    EnemyPathfinding.enemyTurn = true;
                    EnemyMovementLeftRight.enemyTurn = true;
                    EnemyMovementUpDown.enemyTurn = true;

                    PlayerUIButtons.buttonPressed = false;
                    PlayerUIButtons.abilitiesButtonPressed = false;
                    move.Select();
                }
                if (Gamepad.current.bButton.wasPressedThisFrame)
                {
                    sliceAttackRad.SetActive(false);
                    sliceButtonPressed = false;
                    PlayerUIButtons.buttonPressed = false;
                    PlayerUIButtons.abilitiesButtonPressed = false;
                    move.Select();
                }
            }
        }

        if (lazerBeamButtonPressed)
        {
            if (Gamepad.current == null)
            {
                if (Keyboard.current.qKey.wasPressedThisFrame)
                {
                    if (lazerBeamAttackRad.GetComponent<AttackRadius>().enemyInRadius && PlayerControllerOnGrid.playerTurn)
                    {
                        enemy.GetComponent<EnemyHealthBarManager>().TakeDamage(35);
                    }

                    lazerBeamAttackRad.SetActive(false);
                    lazerBeamButtonPressed = false;

                    PlayerControllerOnGrid.playerTurn = false;
                    EnemyPathfinding.enemyTurn = true;
                    EnemyMovementLeftRight.enemyTurn = true;
                    EnemyMovementUpDown.enemyTurn = true;

                    PlayerUIButtons.buttonPressed = false;
                    PlayerUIButtons.abilitiesButtonPressed = false;
                    move.Select();
                }
                if (Keyboard.current.eKey.wasPressedThisFrame)
                {
                    lazerBeamAttackRad.SetActive(false);
                    lazerBeamButtonPressed = false;
                    PlayerUIButtons.buttonPressed = false;
                    PlayerUIButtons.abilitiesButtonPressed = false;
                    move.Select();
                }
            }
            else
            {
                if (Gamepad.current.xButton.wasPressedThisFrame)
                {
                    if (lazerBeamAttackRad.GetComponent<AttackRadius>().enemyInRadius && PlayerControllerOnGrid.playerTurn)
                    {
                        enemy.GetComponent<EnemyHealthBarManager>().TakeDamage(35);
                    }

                    lazerBeamAttackRad.SetActive(false);
                    lazerBeamButtonPressed = false;

                    PlayerControllerOnGrid.playerTurn = false;
                    EnemyPathfinding.enemyTurn = true;
                    EnemyMovementLeftRight.enemyTurn = true;
                    EnemyMovementUpDown.enemyTurn = true;

                    PlayerUIButtons.buttonPressed = false;
                    PlayerUIButtons.abilitiesButtonPressed = false;
                    move.Select();
                }
                if (Gamepad.current.bButton.wasPressedThisFrame)
                {
                    lazerBeamAttackRad.SetActive(false);
                    lazerBeamButtonPressed = false;
                    PlayerUIButtons.buttonPressed = false;
                    PlayerUIButtons.abilitiesButtonPressed = false;
                    move.Select();
                }
            }
        }

        if (detonateButtonPressed)
        {
            if (Gamepad.current == null)
            {
                if (Keyboard.current.qKey.wasPressedThisFrame)
                {
                    if (detonateAttackRad.GetComponent<AttackRadius>().enemyInRadius)
                    {
                        enemy.GetComponent<EnemyHealthBarManager>().TakeDamage(50);
                        player.GetComponent<HealthBarManager>().TakeDamage(50);

                        
                    }

                    detonateAttackRad.SetActive(false);
                    detonateButtonPressed = false;

                    PlayerControllerOnGrid.playerTurn = false;
                    EnemyPathfinding.enemyTurn = true;
                    EnemyMovementLeftRight.enemyTurn = true;
                    EnemyMovementUpDown.enemyTurn = true;

                    PlayerUIButtons.buttonPressed = false;
                    PlayerUIButtons.abilitiesButtonPressed = false;
                    move.Select();
                }
                if (Keyboard.current.eKey.wasPressedThisFrame)
                {
                    detonateAttackRad.SetActive(false);
                    detonateButtonPressed = false;
                    PlayerUIButtons.buttonPressed = false;
                    PlayerUIButtons.abilitiesButtonPressed = false;
                    move.Select();
                }
            }
            else
            {
                if (Gamepad.current.xButton.wasPressedThisFrame)
                {
                    if (detonateAttackRad.GetComponent<AttackRadius>().enemyInRadius && PlayerControllerOnGrid.playerTurn)
                    {
                        enemy.GetComponent<EnemyHealthBarManager>().TakeDamage(50);
                        player.GetComponent<HealthBarManager>().TakeDamage(50);
                    }

                    detonateAttackRad.SetActive(false);
                    detonateButtonPressed = false;

                    PlayerControllerOnGrid.playerTurn = false;
                    EnemyPathfinding.enemyTurn = true;
                    EnemyMovementLeftRight.enemyTurn = true;
                    EnemyMovementUpDown.enemyTurn = true;

                    PlayerUIButtons.buttonPressed = false;
                    PlayerUIButtons.abilitiesButtonPressed = false;
                    move.Select();
                }
                if (Gamepad.current.bButton.wasPressedThisFrame)
                {
                    detonateAttackRad.SetActive(false);
                    detonateButtonPressed = false;
                    PlayerUIButtons.buttonPressed = false;
                    PlayerUIButtons.abilitiesButtonPressed = false;
                    move.Select();
                }
            }
        }

        if (lifeLeechButtonPressed)
        {
            if (Gamepad.current == null)
            {
                if (Keyboard.current.qKey.wasPressedThisFrame)
                {
                    
                    if (lifeLeechAttackRad.GetComponent<AttackRadius>().enemyInRadius)
                    {
                        enemy.GetComponent<EnemyHealthBarManager>().TakeDamage(15);
                        player.GetComponent<HealthBarManager>().heal(15);


                    }

                    lifeLeechAttackRad.SetActive(false);
                    lifeLeechButtonPressed = false;

                    PlayerControllerOnGrid.playerTurn = false;
                    EnemyPathfinding.enemyTurn = true;
                    EnemyMovementLeftRight.enemyTurn = true;
                    EnemyMovementUpDown.enemyTurn = true;

                    PlayerUIButtons.buttonPressed = false;
                    PlayerUIButtons.abilitiesButtonPressed = false;
                    move.Select();
                }
                if (Keyboard.current.eKey.wasPressedThisFrame)
                {
                    lifeLeechAttackRad.SetActive(false);
                    lifeLeechButtonPressed = false;
                    PlayerUIButtons.buttonPressed = false;
                    PlayerUIButtons.abilitiesButtonPressed = false;
                    move.Select();
                }
            }
            else
            {
                if (Gamepad.current.xButton.wasPressedThisFrame)
                {
                    if (lifeLeechAttackRad.GetComponent<AttackRadius>().enemyInRadius)
                    {
                        enemy.GetComponent<EnemyHealthBarManager>().TakeDamage(15);
                        player.GetComponent<HealthBarManager>().heal(15);


                    }

                    lifeLeechAttackRad.SetActive(false);
                    lifeLeechButtonPressed = false;

                    PlayerControllerOnGrid.playerTurn = false;
                    EnemyPathfinding.enemyTurn = true;
                    EnemyMovementLeftRight.enemyTurn = true;
                    EnemyMovementUpDown.enemyTurn = true;

                    PlayerUIButtons.buttonPressed = false;
                    PlayerUIButtons.abilitiesButtonPressed = false;
                    move.Select();
                }
                if (Gamepad.current.bButton.wasPressedThisFrame)
                {
                    lifeLeechAttackRad.SetActive(false);
                    lifeLeechButtonPressed = false;
                    PlayerUIButtons.buttonPressed = false;
                    PlayerUIButtons.abilitiesButtonPressed = false;
                    move.Select();
                }
            }
        }

    }

    public void BurrowButton()
    {
        if (GameManager.instance.PlantAbility() == burrowID)
        {
            if (!burrowOneTimeUse)
            {
                startPos = player.transform.position;

                dirtMound.SetActive(true);
                PlayerUIButtons.abilitiesButtonPressed = false;
                abilityHolder.SetActive(false);
                PlayerControllerOnGrid.playerTurn = true;
                burrowMoveBox.SetActive(true);
                burrowButtonPressed = true;
            }
        }
        
        
       

    }

    public void SporeCloudButton()
    {
        if (GameManager.instance.PlantAbility() == sporeCloudID)
        {
            timesDone++;
            PlayerUIButtons.abilitiesButtonPressed = false;
            abilityHolder.SetActive(false);
            PlayerControllerOnGrid.playerTurn = true;

            sporeCloudAttackRad.SetActive(true);

            //I made this because the attack symbols would only appear if the radius
            //was moved for some reason, so every even/odd turn would have
            //a different movement done to the radius so the symbols would appear.
            //I seriously don't know why this is happening, if it works it works
            if (timesDone % 2 == 0)
            {
                sporeCloudAttackRad.transform.position = playerMovePoint.position;
            }
            else
            {
                sporeCloudAttackRad.transform.position = otherMovePoint.position;
            }

            sporeCloudButtonPressed = true;
        }
        
    }

    public void LifeLeechButton()
    {
        if (GameManager.instance.PlantAbility() == lifeLeechID)
        {
            timesDone06++;
            PlayerUIButtons.abilitiesButtonPressed = false;
            abilityHolder.SetActive(false);
            PlayerControllerOnGrid.playerTurn = true;

            lifeLeechAttackRad.SetActive(true);
            if (timesDone06 % 2 == 0)
            {

                lifeLeechAttackRad.transform.position = playerMovePoint.position;
            }
            else
            {
                lifeLeechAttackRad.transform.position = otherMovePoint.position;
            }

            lifeLeechButtonPressed = true;
        }
       
    }

    public void SeedShotButton()
    {
        if (GameManager.instance.PlantAbility() == seedShotID)
        {
            timesDone02++;

            PlayerUIButtons.abilitiesButtonPressed = false;
            abilityHolder.SetActive(false);
            PlayerControllerOnGrid.playerTurn = true;

            seedShotAttackRad.SetActive(true);

            if (timesDone02 % 2 == 0)
            {
                seedShotAttackRad.transform.position = playerMovePoint.position;
            }
            else
            {
                seedShotAttackRad.transform.position = otherMovePoint.position;
            }

            seedShotButtonPressed = true;
        }
       
    }

    public void SliceButton()
    {
        if (GameManager.instance.RobotAbility() == sliceID)
        {
            timesDone03++;

            PlayerUIButtons.abilitiesButtonPressed = false;
            abilityHolder.SetActive(false);
            PlayerControllerOnGrid.playerTurn = true;

            sliceAttackRad.SetActive(true);

            if (timesDone03 % 2 == 0)
            {
                sliceAttackRad.transform.position = playerMovePoint.position;
            }
            else
            {
                sliceAttackRad.transform.position = otherMovePoint.position;
            }

            sliceButtonPressed = true;
        }
        
    }

    public void LazerBeamButton()
    {
        if (GameManager.instance.RobotAbility() == lazerBeamID)
        {
            timesDone04++;

            PlayerUIButtons.abilitiesButtonPressed = false;
            abilityHolder.SetActive(false);
            PlayerControllerOnGrid.playerTurn = true;

            lazerBeamAttackRad.SetActive(true);

            if (timesDone04 % 2 == 0)
            {
                lazerBeamAttackRad.transform.position = playerMovePoint.position;
            }
            else
            {
                lazerBeamAttackRad.transform.position = otherMovePoint.position;
            }

            lazerBeamButtonPressed = true;
        }
        
    }

    public void DetonateButton()
    {
        if (GameManager.instance.RobotAbility() == detonateID)
        {
            timesDone05++;

            PlayerUIButtons.abilitiesButtonPressed = false;
            abilityHolder.SetActive(false);
            PlayerControllerOnGrid.playerTurn = true;

            detonateAttackRad.SetActive(true);

            if (timesDone05 % 2 == 0)
            {
                detonateAttackRad.transform.position = playerMovePoint.position;
            }
            else
            {
                detonateAttackRad.transform.position = otherMovePoint.position;
            }

            detonateButtonPressed = true;
        }
       
    }

    public void ShutDownButton()
    {
        if (GameManager.instance.RobotAbility() == shutDownID)
        {
            if (GameManager.instance.CanUseShutDown())
            {
                GameManager.instance.UseShutDown();

                PlayerUIButtons.abilitiesButtonPressed = false;
                abilityHolder.SetActive(false);
                PlayerControllerOnGrid.playerTurn = true;

                enemy.GetComponent<EnemyHealthBarManager>().TakeDamage(enemy.GetComponent<EnemyHealthBarManager>().maxHealth);

                PlayerControllerOnGrid.playerTurn = false;
                EnemyPathfinding.enemyTurn = true;
                EnemyMovementLeftRight.enemyTurn = true;
                EnemyMovementUpDown.enemyTurn = true;

                PlayerUIButtons.buttonPressed = false;
                PlayerUIButtons.abilitiesButtonPressed = false;
                move.Select();

            }
        }
        
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
