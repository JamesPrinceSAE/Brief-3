using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    private void OnEnable()
    {
        CloneEvents.DespawnEvent += Death;
    }

    private void OnDisable()
    {
        CloneEvents.DespawnEvent -= Death;
    }
    void Start()
    {
        CloneEvents.OnSpawnEvent?.Invoke(gameObject);
    }

    private void Death()
    {
        CloneEvents.OnDespawnEvent?.Invoke(gameObject);
        Destroy(gameObject);
    }
}
