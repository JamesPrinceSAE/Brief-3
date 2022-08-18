using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBooster : MonoBehaviour
{
    private float boostDuration = 6f;
    public TankMovement tankScript;

    public void Start()
    {
        tankScript = new TankMovement();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player" && other.name == "Player_01")
        {
            tankScript.speed = 30f;
        }
        else if (other.tag == "Player" && other.name == "Player_02")
        {

        }
    }
}
