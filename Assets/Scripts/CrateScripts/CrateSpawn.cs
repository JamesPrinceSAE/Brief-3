using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CrateSpawn : MonoBehaviour
{
    public List<Transform> allPossibleSpawnPoints = new List<Transform>(); // this a list of all the possible tank spawn locations
    private List<Transform> startingAllPossibleSpawnPoints = new List<Transform>();// storing the starting value of all possible spawn points
    public List<GameObject> cratePrefabs = new List<GameObject>(); // a list of all the possible crate prefabs
    public List<GameObject> allCratesSpawnedIn = new List<GameObject>(); // a list of all the crates spawned in
    public List<Transform> UsedSpawnPoints = new List<Transform>();

    private void OnEnable()
    {
        CrateGameEvents.SpawnCratesEvent += SpawnCrates;
        TankGameEvents.OnResetGameEvent += Reset;
        TankGameEvents.OnRoundResetEvent += Reset;
    }

    private void OnDisable()
    {
        CrateGameEvents.SpawnCratesEvent -= SpawnCrates;
        TankGameEvents.OnResetGameEvent -= Reset;
        TankGameEvents.OnRoundResetEvent -= Reset;
    }


    private void Start()
    {
              
    }
    bool spawnInProgress = false;

    private void Update()
    {
        if(allCratesSpawnedIn.Count < 5 && !spawnInProgress)
        {
            Invoke("Replace", 3);
            spawnInProgress = true;
        }
    }

    void Replace()
    {
        CrateGameEvents.SpawnCratesEvent?.Invoke(1);
    }

    /// <summary>
    /// This is called in our scene help us with debugging.
    /// </summary>
    private void OnDrawGizmos()
    {
        // loops through all the possible spawn points
        for(int i=0; i<allPossibleSpawnPoints.Count; i++)
        {
            Gizmos.color = Color.blue; // set the colour of our gizmo to blue
            Gizmos.DrawSphere(allPossibleSpawnPoints[i].position, 0.25f); // draw a gizmo for our spawn point location
        }
    }

    /// <summary>
    /// Resets our game and destroys the current tanks
    /// </summary>
    private void Reset()
    {
        for (int i = 0; i < allCratesSpawnedIn.Count; i++)
        {
            Destroy(allCratesSpawnedIn[i]);// destroy each crate we spawned in
        }
        allCratesSpawnedIn.Clear(); // clear the list so we can start fresh
        startingAllPossibleSpawnPoints.Clear(); // clear our starting spawn points
        // get a new copy of all the possible spawn points
        for (int i = 0; i < allPossibleSpawnPoints.Count; i++)
        {
            startingAllPossibleSpawnPoints.Add(allPossibleSpawnPoints[i]); // do a hard copy, and copy across all the possible spawn points to our private list
        }
    }

    private void SpawnCrates(int NumberToSpawn)
    {
            // we good to go
            for (int i = 0; i < NumberToSpawn; i++)
            {
                // checking if I have enough unique prefabs so I can spawn different tanks
                // spawn in a tank prefab, at a random spawn point
                Transform tempSpawnPoint = startingAllPossibleSpawnPoints[Random.Range(0, startingAllPossibleSpawnPoints.Count)]; // getting a random spawn point
                
                if(tempSpawnPoint != UsedSpawnPoints.Contains(tempSpawnPoint))
                {
                    GameObject clone = Instantiate(cratePrefabs[Random.Range(0, cratePrefabs.Count)], tempSpawnPoint.position, Quaternion.identity);
                    UsedSpawnPoints.Add(tempSpawnPoint); // remove the temp spawn point from our possible spawn point list
                    allCratesSpawnedIn.Add(clone); // keep track of the tank we just spawned in
                }
                
                

            }
        

        CrateGameEvents.OnCratesSpawnedEvent?.Invoke(allCratesSpawnedIn); // tell the game that our tanks have been spawned in!
        spawnInProgress = false;
    }
}
