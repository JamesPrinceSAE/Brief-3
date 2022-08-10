using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    private void OnEnable()
    {
        CrateEvents.DespawnEvent += Death;
    }

    private void OnDisable()
    {
        CrateEvents.DespawnEvent -= Death;
    }
    void Start()
    {
        CrateEvents.OnSpawnEvent?.Invoke(gameObject);
    }

    private void Death()
    {
        CrateEvents.OnDespawnEvent?.Invoke(gameObject);
        Destroy(gameObject);
    }
}
