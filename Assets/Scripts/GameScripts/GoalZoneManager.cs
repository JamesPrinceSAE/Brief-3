using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalZoneManager : MonoBehaviour
{

    public Color player1Colour = Color.green;
    public Color player2Colour = Color.red;
    public GameObject GoalZone;
    public bool isP1Controlling = false;
    public bool isP2Controlling = false;
    public bool isP1ControlFull = false;
    public bool isP2ControlFull = false;

    public void OnEnable()
    {
        //OnPlayerOneControlEvent +=
    }

    public void OnDisable()
    {
        
    }

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
            
        }
        else if (other.tag == "Player" && other.name == "Player_02(Clone)")
        {
            
        }
    }

}
