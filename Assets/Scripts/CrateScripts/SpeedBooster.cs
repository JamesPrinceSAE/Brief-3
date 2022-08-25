using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBooster : MonoBehaviour
{

    public float boostDuration = 3f;

    public void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && other.name == "Player_01(Clone)")
        {
            Tank myTank = other.GetComponent<Tank>();
            myTank.boostTimer = boostDuration;
            myTank.tankMovement.speed = myTank.tankMovement.boostSpeed;
            Debug.Log("Tank1 Boosted");
        }
        else if (other.tag == "Player" && other.name == "Player_02(Clone)")
        {
            Tank myTank = other.GetComponent<Tank>();
            myTank.boostTimer = boostDuration;
            myTank.tankMovement.speed = myTank.tankMovement.boostSpeed;
            Debug.Log("Tank2 Boosted");
        }
    }
}
