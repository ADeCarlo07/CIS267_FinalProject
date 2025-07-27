using System.Collections.Generic;
using TMPro;

//commenting this out for now to be able to make the build
//using UnityEditor.Playables;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class InventoryAndAbilities : MonoBehaviour
{
    public GameObject inventoryAndAbilities;
    public GameObject boxUI;
    public static bool buttonPressed;
    private bool abilButtonPressed;
    private bool inventoryButtonPressed;
    public Button abil;
    public Button inventory;
    public Button burrow;
    public Button sporeCloud;
    public Button slice;
    public Button detonate;
    public Button lazerBeam;
    public Button shutDown;
    public Button seedShot;
    public Button lifeLeech;
    public GameObject boxUI2;


    public string burrowID = "Burrow";
    public string sporeCloudID = "Spore Cloud";
    public string sliceID = "Slice";
    public string detonateID = "Detonate";
    public string lazerBeamID = "Lazer Beam";
    public string shutDownID = "Shut Down";
    public string seedShotID = "Seed Shot";
    public string lifeLeechID = "Life Leech";



    private List<Button> plantAbilities = new List<Button>();
    private List<Button> robotAbilities = new List<Button>();

    public TextMeshProUGUI[] InventorySlots = new TextMeshProUGUI[3];
    public Image[] InventoryImages = new Image[3];

    public Sprite healthPotion;
    public Sprite emptyItem;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        plantAbilities.AddRange(new[] { burrow, sporeCloud, lifeLeech, seedShot});
        robotAbilities.AddRange(new[] { lazerBeam, shutDown, detonate, slice});
    }

    // Update is called once per frame
    void Update()
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


        if (!PauseMenu.isPaused && !abilButtonPressed && !inventoryButtonPressed)
        {
            if (Gamepad.current == null)
            {
                if (Keyboard.current.iKey.wasPressedThisFrame)
                {
                    abil.Select();
                    Time.timeScale = 0;
                    buttonPressed = true;
                    inventoryAndAbilities.SetActive(true);
                }
                if (Keyboard.current.uKey.wasPressedThisFrame)
                {
                    Time.timeScale = 1;
                    inventoryAndAbilities.SetActive(false);
                    buttonPressed = false;
                }
            }
            else
            {
                if (Gamepad.current.yButton.wasPressedThisFrame)
                {
                    abil.Select();
                    Time.timeScale = 0;
                    buttonPressed = true;
                    inventoryAndAbilities.SetActive(true);

                }
                if (Gamepad.current.bButton.wasPressedThisFrame && buttonPressed)
                {
                    Time.timeScale = 1;
                    inventoryAndAbilities.SetActive(false);
                    buttonPressed = false;
                }
            }
        }

        if (!PauseMenu.isPaused && abilButtonPressed)
        {
            if (Gamepad.current == null)
            {

                if (Keyboard.current.uKey.wasPressedThisFrame)
                {
                    boxUI.SetActive(false);
                    abilButtonPressed = false;
                    abil.enabled = true;
                    inventory.enabled = true;
                    abil.Select();
                }
            }
            else
            {

                if (Gamepad.current.bButton.wasPressedThisFrame && buttonPressed)
                {
                    boxUI.SetActive(false);
                    abilButtonPressed = false;
                    abil.enabled = true;
                    inventory.enabled = true;
                    abil.Select();
                }
            }
        }

        if (!PauseMenu.isPaused && inventoryButtonPressed)
        {
            if (Gamepad.current == null)
            {

                if (Keyboard.current.uKey.wasPressedThisFrame)
                {
                    boxUI2.SetActive(false);
                    inventoryButtonPressed = false;
                    abil.enabled = true;
                    inventory.enabled = true;
                    abil.Select();
                }
            }
            else
            {

                if (Gamepad.current.bButton.wasPressedThisFrame && buttonPressed)
                {
                    boxUI2.SetActive(false);
                    inventoryButtonPressed = false;
                    abil.enabled = true;
                    inventory.enabled = true;
                    abil.Select();
                }
            }
        }
    }


public void AbilitiesButton()
    {
        abil.enabled = false;
        inventory.enabled = false;
        abilButtonPressed = true;
        boxUI.SetActive(true);

      

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
    }

    public void BurrowButton()
    {
        if (abilButtonPressed)
        {
            SelectAbility(burrowID, burrow);
            Debug.Log(GameManager.instance.PlantAbility());
            Debug.Log(GameManager.instance.RobotAbility());
        }
    }

    public void SliceButtion()
    {
        if (abilButtonPressed)
        {
            SelectAbility(sliceID, slice);
            Debug.Log(GameManager.instance.PlantAbility());
            Debug.Log(GameManager.instance.RobotAbility());
        }
    }

    public void SporeCloudButton()
    {
        if (abilButtonPressed)
        {
            SelectAbility(sporeCloudID, sporeCloud);
            Debug.Log(GameManager.instance.PlantAbility());
            Debug.Log(GameManager.instance.RobotAbility());
        }
    }

    public void LazerBeamButton()
    {
        if (abilButtonPressed)
        {
            SelectAbility(lazerBeamID, lazerBeam);
            Debug.Log(GameManager.instance.PlantAbility());
            Debug.Log(GameManager.instance.RobotAbility());
        }
    }

    public void LifeLeechButton()
    {
        if (abilButtonPressed)
        {
            SelectAbility(lifeLeechID, lifeLeech);
            Debug.Log(GameManager.instance.PlantAbility());
            Debug.Log(GameManager.instance.RobotAbility());
        }
    }

    public void DetonateButton()
    {
        if (abilButtonPressed)
        {
            SelectAbility(detonateID, detonate);
            Debug.Log(GameManager.instance.PlantAbility());
            Debug.Log(GameManager.instance.RobotAbility());
        }
    }

    public void SeedShotButton()
    {
        if (abilButtonPressed)
        {
            SelectAbility(seedShotID, seedShot);
            Debug.Log(GameManager.instance.PlantAbility());
            Debug.Log(GameManager.instance.RobotAbility());
        }
    }

    public void ShutDownButton()
    {
        if (abilButtonPressed)
        {
            SelectAbility(shutDownID, shutDown);
            Debug.Log(GameManager.instance.PlantAbility());
            Debug.Log(GameManager.instance.RobotAbility());
        }
    }



    //====================================================================================

    private void SelectAbility(string ID, Button button)
    {
        Debug.Log("SelectAbility going off");

        // Turn off all outlines
        foreach (Button b in plantAbilities)
        {
            var outline = b.transform.Find("Outline");
            if (outline != null) 
            {
                outline.gameObject.SetActive(false);
            }
        }

        foreach (Button b in robotAbilities)
        {
            var outline = b.transform.Find("Outline");
            if (outline != null) 
            {
                outline.gameObject.SetActive(false);
            }
        }

        // Turn on the selected button’s outline
        var selectedOutline = button.transform.Find("Outline");
        if (selectedOutline != null) 
        {
            selectedOutline.gameObject.SetActive(true);
        }


        if (plantAbilities.Contains(button))
        {
            GameManager.instance.selectedPlantAbilityID = ID;
        }  
        else if (robotAbilities.Contains(button))
        {
            GameManager.instance.selectedRobotAbilityID = ID;
        }
 
    }

    public void InventoryButton()
    {
        abil.enabled = false;
        inventory.enabled = false;
        inventoryButtonPressed = true;
        boxUI2.SetActive(true);

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

    }


}
