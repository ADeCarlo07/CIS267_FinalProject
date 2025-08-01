
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //think getters and setters for most of this code


    public static GameManager instance;

    //GLOBAL SHUTDOWN ABILITY STATE AND PLAYER POS TRACK
    public bool shutDownUsed = false;
    public Vector3 lastPlayerPos;
    private bool hasSavedPlayerPos = false;
    public bool shutDownFound = false;
    public bool sporeCloudFound = false;
    public bool burrowFound = false;
    public bool lifeLeechFound = false;
    public bool seedShotFound = false;
    public bool lazerBeamFound = false;
    public bool detonateFound = false;
    public bool sliceFound = false;
    public string selectedPlantAbilityID;
    public string selectedRobotAbilityID;
    public int level01SceneLoadCount;
    public int level02SceneLoadCount;
    public int level03SceneLoadCount;
    public string lastLoadedScene;
    public bool level03CamSetActive = true;
    public bool shutDownSpecialCase = false;


    //ENEMY TRACKING

    //HashSet definition online: HashSet is an unordered collection containing unique elements.
    //It has the standard collection operations Add, Remove, Contains, but since it uses a hash-based implementation, these operations are O(1).
    //(As opposed to List for example, which is O(n) for Contains and Remove.)
    //HashSet also provides standard set operations such as union, intersection, and symmetric difference.

    private HashSet<string> defeatedEnemies = new HashSet<string>();
    private HashSet<string> enemiesAlreadyDropped = new HashSet<string>();

    private void Awake()
    {
      
        //if it doesn't exist make it so
        if (instance == null)
        {
            level01SceneLoadCount = 0;
            level02SceneLoadCount = 0;
            level03SceneLoadCount = 0;

            instance = this;
            //will not be destroyed across scenes
            DontDestroyOnLoad(gameObject);
        }
        //otherwise to not have a dupe
        else
        {
            Destroy(gameObject);
        }
    }

    public void changeBooleanShutDownSpecialCase()
    {
        shutDownSpecialCase = true;
    }

    public void lastScene(string scene)
    {
        lastLoadedScene = scene;
    }

    public string GetLastScene()
    {
        return lastLoadedScene;
    }

    //going to have more of a purpose when we do the collectablity of the
    //different abilities. For example could attach && isShutDownCollected
    // and use this across different scripts and scenes to check
    public bool CanUseShutDown()
    {
        return !shutDownUsed;
    }

    public string PlantAbility()
    {
        return selectedPlantAbilityID;
    }

    public string RobotAbility()
    {
        return selectedRobotAbilityID;
    }

    public void UseShutDown()
    {
        shutDownUsed = true;
        shutDownFound = false;
    }

    public void FindShutDown()
    {
        shutDownFound = true;
    }

    public void FindSporeCloud()
    {
        sporeCloudFound = true;
    }

    public void FindSlice()
    {
        sliceFound = true;
    }

    public void FindLazerBeam()
    {
        lazerBeamFound = true;
    }

    public void FindBurrow()
    {
        burrowFound = true;
    }

    public void FindLifeLeech()
    {
        lifeLeechFound = true;
    }

    public void FindSeedShot()
    {
        seedShotFound = true;
    }

    public void FindDetonate()
    {
        detonateFound = true;
    }

    public void EnemyDefeated(string enemyID)
    {
        defeatedEnemies.Add(enemyID);
    }

    public void EnemeyDroppedHealth(string enemyID)
    {
        enemiesAlreadyDropped.Add(enemyID);
    }

    public void RemoveDefeatedEnemy(string enemyID)
    {
        defeatedEnemies.Remove(enemyID);
    }

    public bool IsEnemyDefeated(string enemyID)
    {
        return defeatedEnemies.Contains(enemyID);
    }

    public bool IsEnemyDropped(string enemyID)
    {
        return enemiesAlreadyDropped.Contains(enemyID);
    }

    public void SavePlayerPos(Vector3 pos)
    {
        lastPlayerPos = pos;
        hasSavedPlayerPos = true;
    }

    public Vector3 GetPlayerPos()
    {
        return lastPlayerPos;
    }

    public bool IsPlayerPosSaved()
    {
        return hasSavedPlayerPos;
    }
}
