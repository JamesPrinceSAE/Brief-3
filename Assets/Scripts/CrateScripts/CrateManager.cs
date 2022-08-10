using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateManager : MonoBehaviour
{

    public GameObject cratePrefab;
    public List<Transform> allSpawnPoints = new List<Transform>();
    public List<GameObject> allCrates = new List<GameObject>();

    private void OnEnable()
    {
        CrateEvents.SpawnEvent += StartCloning;
        CrateEvents.OnSpawnEvent += AddNewCrate;
    }

    private void OnDisable()
    {
        CrateEvents.SpawnEvent -= StartCloning;
        CrateEvents.OnSpawnEvent -= AddNewCrate;
    }

    void StartCloning()
    {
        for (int i = 0; i < allSpawnPoints.Count; i++)
        {
            Instantiate(cratePrefab, allSpawnPoints[i].position, allSpawnPoints[i].rotation);
        }
    }

    void AddNewCrate(GameObject crateToAdd)
    {
        allCrates.Add (crateToAdd);
    }
}
