using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healer : MonoBehaviour
{
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
            myTank.tankHealth.CurrentHealth += (myTank.tankHealth.maxHealth / 4);
            Debug.Log("Tank1 Healed");
        }
        else if (other.tag == "Player" && other.name == "Player_02(Clone)")
        {
            Tank myTank = other.GetComponent<Tank>();
            myTank.tankHealth.CurrentHealth += (myTank.tankHealth.maxHealth / 4);
            Debug.Log("Tank2 Healed");
        }
    }
}
