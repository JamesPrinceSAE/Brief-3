using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowCloneManager : MonoBehaviour
{

    public GameObject clonePrefab;
    public List<Transform> allSpawnPoints = new List<Transform>();
    public List<GameObject> allClones = new List<GameObject>();

    private void OnEnable()
    {
        CloneEvents.SpawnEvent += StartCloning;
        CloneEvents.OnSpawnEvent += AddNewClone;
        CloneEvents.OnDespawnEvent += RemoveClone;
    }

    private void OnDisable()
    {
        CloneEvents.SpawnEvent -= StartCloning;
        CloneEvents.OnSpawnEvent -= AddNewClone;
        CloneEvents.OnDespawnEvent -= RemoveClone;
    }

    void StartCloning()
    {
        for (int i = 0; i < allSpawnPoints.Count; i++)
        {
            Instantiate(clonePrefab, allSpawnPoints[i].position, allSpawnPoints[i].rotation);
        }
    }

    void AddNewClone(GameObject cloneToAdd)
    {
        allClones.Add (cloneToAdd);
    }

    void RemoveClone(GameObject cloneToRemove)
    {
        allClones.Remove (cloneToRemove);
    }
}
