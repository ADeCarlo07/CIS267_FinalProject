using System.Collections;
using TMPro;
//commenting this out for now to be able to make the build
//using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerUIButtons : MonoBehaviour
{
    public GameObject playerMovementRadius;
    public Button move;
    public Button abilities;
    public Button inventory;
    public Button skipTurn;
    public static bool buttonPressed;
    public static bool moveButtonPressed;
    public static bool abilitiesButtonPressed;
    public static bool inventoryButtonPressed;
    public GameObject abilityHolder;
    public GameObject inventoryHolder;
    public GameObject firstAbility;
    public Button burrow;
    public Button sporeCloud;
    public Button slice;
    public Button detonate;
    public Button lazerBeam;
    public Button shutDown;
    public Button seedShot;
    public Button lifeLeech;

    public string burrowID = "Burrow";
    public string sporeCloudID = "Spore Cloud";
    public string sliceID = "Slice";
    public string detonateID = "Detonate";
    public string lazerBeamID = "Lazer Beam";
    public string shutDownID = "Shut Down";
    public string seedShotID = "Seed Shot";
    public string lifeLeechID = "Life Leech";


    public TextMeshProUGUI[] InventorySlots = new TextMeshProUGUI[3];
    public Image[] InventoryImages = new Image[3];

    public Sprite healthPotion;
    public Sprite emptyItem;

    public Button startOfInventory;


    //there has to be a small delay between skipping becuase
    //there are major bugs when the player spams it
    private bool canSkipTurn = true;
    private float skipCooldown = .25f;
    private float lastSkipTime = 0f;

    //private void Start()
    //{
    //    for (int i = 0; i < InventorySlots.Length; i++)
    //    {
    //        if (InventoryManager.GetItem(i) != null)
    //        {
    //            InventorySlots[i].text = InventoryManager.GetItem(i);
    //        }
    //        else
    //        {
    //            InventorySlots[i].text = "Empty Slot";

    //        }
    //    }
    //}
    void Update()
    {
        if (!canSkipTurn && Time.time - lastSkipTime >= skipCooldown)
        {
            canSkipTurn = true;
        }

        if (buttonPressed == true)
        {
            move.enabled = false;
            abilities.enabled = false;
            inventory.enabled = false;
            skipTurn.enabled = false;
        }

        if (buttonPressed == false)
        {
            move.enabled = true;
            abilities.enabled = true;
            inventory.enabled = true;
            skipTurn.enabled = true;
        }

        for (int i = 0; InventorySlots.Length < 3; i++)
        {
            InventorySlots[i].text = InventoryManager.playerItems[i];
        }
    }

    public void MoveButton()
    {
        PlayerControllerOnGrid.playerTurn = true;
        PlayerControllerOnGrid.ableToMove = true;
        playerMovementRadius.SetActive(true);

        moveButtonPressed = true;
        buttonPressed = true;
    }

    public void AbilitiesButton()
    {
        if (!GameManager.instance.burrowFound)
        {
            burrow.gameObject.SetActive(false);
        }
        else
        {
            burrow.gameObject.SetActive(true);

            if (GameManager.instance.PlantAbility() == burrowID)
            {
                var selectedOutline = burrow.transform.Find("Outline");

                if (selectedOutline != null)
                {
                    selectedOutline.gameObject.SetActive(true);
                }
            }
        }
        if (!GameManager.instance.sporeCloudFound)
        {
            sporeCloud.gameObject.SetActive(false);
        }
        else
        {
            sporeCloud.gameObject.SetActive(true);
            if (GameManager.instance.PlantAbility() == sporeCloudID)
            {
                var selectedOutline = sporeCloud.transform.Find("Outline");

                if (selectedOutline != null)
                {
                    selectedOutline.gameObject.SetActive(true);
                }
            }

        }
        if (!GameManager.instance.sliceFound)
        {
            slice.gameObject.SetActive(false);
        }
        else
        {
            slice.gameObject.SetActive(true);

            if (GameManager.instance.RobotAbility() == sliceID)
            {
                var selectedOutline = slice.transform.Find("Outline");

                if (selectedOutline != null)
                {
                    selectedOutline.gameObject.SetActive(true);
                }
            }
        }
        if (!GameManager.instance.detonateFound)
        {
            detonate.gameObject.SetActive(false);
        }
        else
        {
            detonate.gameObject.SetActive(true);

            if (GameManager.instance.RobotAbility() == detonateID)
            {
                var selectedOutline = detonate.transform.Find("Outline");

                if (selectedOutline != null)
                {
                    selectedOutline.gameObject.SetActive(true);
                }
            }
        }
        if (!GameManager.instance.lazerBeamFound)
        {
            lazerBeam.gameObject.SetActive(false);
        }
        else
        {
            lazerBeam.gameObject.SetActive(true);

            if (GameManager.instance.RobotAbility() == lazerBeamID)
            {
                var selectedOutline = lazerBeam.transform.Find("Outline");

                if (selectedOutline != null)
                {
                    selectedOutline.gameObject.SetActive(true);
                }
            }
        }
        if (!GameManager.instance.shutDownFound)
        {
            shutDown.gameObject.SetActive(false);
        }
        else
        {
            shutDown.gameObject.SetActive(true);

            if (GameManager.instance.RobotAbility() == shutDownID)
            {
                var selectedOutline = shutDown.transform.Find("Outline");

                if (selectedOutline != null)
                {
                    selectedOutline.gameObject.SetActive(true);
                }
            }
        }
        if (!GameManager.instance.seedShotFound)
        {
            seedShot.gameObject.SetActive(false);
        }
        else
        {
            seedShot.gameObject.SetActive(true);

            if (GameManager.instance.PlantAbility() == seedShotID)
            {
                var selectedOutline = seedShot.transform.Find("Outline");

                if (selectedOutline != null)
                {
                    selectedOutline.gameObject.SetActive(true);
                }
            }
        }
        if (!GameManager.instance.lifeLeechFound)
        {
            lifeLeech.gameObject.SetActive(false);
        }
        else
        {
            lifeLeech.gameObject.SetActive(true);

            if (GameManager.instance.PlantAbility() == lifeLeechID)
            {
                var selectedOutline = lifeLeech.transform.Find("Outline");

                if (selectedOutline != null)
                {
                    selectedOutline.gameObject.SetActive(true);
                }
            }
        }

        abilityHolder.SetActive(true);
        abilitiesButtonPressed = true;
        
        if (GameManager.instance.burrowFound)
        {
            burrow.Select();
        }
        else if (GameManager.instance.sliceFound)
        {
            slice.Select();
        }
        else if (GameManager.instance.sporeCloudFound)
        {
            sporeCloud.Select();
        }
        else if (GameManager.instance.lazerBeamFound)
        {
            lazerBeam.Select();
        }
        else if (GameManager.instance.lifeLeechFound)
        {
            lifeLeech.Select();
        }
        else if (GameManager.instance.detonateFound)
        {
            detonate.Select();
        }
        else if (GameManager.instance.seedShotFound)
        {
            seedShot.Select();
        }
        else if (GameManager.instance.shutDownFound)
        {
            shutDown.Select();
        }
        
        buttonPressed = true;
        
    }

    public void InventoryButton()
    {
        //for backing out of inventory button code, go to PlayerControllerOnGrid
        //and scroll to
        //if (PlayerUIButtons.moveButtonPressed)
        //{
        //    selectedCharacter.transform.position = startPos;
        //    movementRadius.SetActive(false);
        //    PlayerUIButtons.moveButtonPressed = false;
        //    PlayerUIButtons.buttonPressed = false;
        //}
        //if (PlayerUIButtons.abilitiesButtonPressed)
        //{
        //    abilityHolder.SetActive(false);
        //    PlayerUIButtons.abilitiesButtonPressed = false;
        //    PlayerUIButtons.buttonPressed = false;
        //    moveButton.Select();

        //}

        //================================================
        //INSERT EXIT CODE FOR INVENTORY DOWN BELOW
        //if (PlayerUIButtons.inventoryButtonPressed)
        //{

        //    PlayerUIButtons.inventoryButtonPressed = false;
        //    PlayerUIButtons.buttonPressed = false;
        //}


        for (int i = 0; i < InventorySlots.Length; i++)
        {
            if (InventoryManager.GetItem(i) != null)
            {
                InventorySlots[i].text = InventoryManager.GetItem(i);
                if (InventoryManager.GetItem(i) == "HealthPotion")
                {
                    InventoryImages[i].sprite = healthPotion;
                }
            }
            else
            {
                InventorySlots[i].text = "EmptySlot";
            }
            if (InventoryManager.GetItem(i) == "HealthPotion")
            {
                InventoryImages[i].sprite = healthPotion;
                InventoryImages[i].preserveAspect = true;
            }
            else
            {
                InventoryImages[i].sprite = emptyItem;

            }
        }

        inventoryHolder.SetActive(true);
        inventoryButtonPressed = true;
        startOfInventory.Select();
        buttonPressed = true;
    }

    public void SkipTurnButton()
    {
        if (!canSkipTurn)
        {
            return;
        }

        EnemyPathfinding.enemyTurn = true;
        EnemyMovementUpDown.enemyTurn = true;
        EnemyMovementLeftRight.enemyTurn = true;
        EnemyMovementLeftRightV2.enemyTurn = true;
        EnemyMovementUpDownV2.enemyTurn = true;
        PlayerControllerOnGrid.playerTurn = false;

        canSkipTurn = false;
        lastSkipTime = Time.time;
    }

 
}
