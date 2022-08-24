using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceField : MonoBehaviour
{
    public Tank




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

        if (other.tag == "Player" && other.name == "Player_01")
        {
            
        }
        else if (other.tag == "Player" && other.name == "Player_02")
        {

        }
    }
}
