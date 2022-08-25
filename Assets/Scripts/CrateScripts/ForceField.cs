using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceField : MonoBehaviour
{

    public float shieldDuration = 14f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && other.name == "Player_01(Clone)")
        {
            Tank myTank = other.GetComponent<Tank>();
            myTank.tankHealth.ForceField.SetActive(true);
            myTank.shieldTimer = shieldDuration;
            myTank.tankHealth.isShieldUp = true;
            myTank.isBoostOn = false;
            Debug.Log("Tank1 Shielded");
        }
        else if (other.tag == "Player" && other.name == "Player_02(Clone)")
        {
            Tank myTank = other.GetComponent<Tank>();
            myTank.tankHealth.ForceField.SetActive(true);
            myTank.shieldTimer = shieldDuration;
            myTank.tankHealth.isShieldUp = true;
            myTank.isBoostOn = false;
            Debug.Log("Tank2 Shielded");
        }
    }
}
