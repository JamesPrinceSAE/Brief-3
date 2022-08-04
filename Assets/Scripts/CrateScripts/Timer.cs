using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{

    private bool startTimer = false;
    public float timeAmount = 5f;
    public float currentTime;

    private void OnEnable()
    {
        CloneEvents.SpawnEvent += StartTimer;    
    }
    private void OnDisable()
    {
        CloneEvents.SpawnEvent -= StartTimer;
    }

    void StartTimer()
    {
        startTimer = true;
        currentTime = 0;
    }
    void StopTimer()
    {
        startTimer= false;
        Debug.Log("Time's Up!");
        CloneEvents.DespawnEvent?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer == true)
        {
            currentTime += Time.deltaTime;
            if(currentTime > timeAmount)
            {
                StopTimer();
            }
        }

    }
}
