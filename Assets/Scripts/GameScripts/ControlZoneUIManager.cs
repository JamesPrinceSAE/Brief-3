using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ControlZoneUIManager : MonoBehaviour
{

    [SerializeField] private Slider SliderP1, SliderP2;

    [SerializeField] private GoalZoneManager myGoalManager;

    private void Start()
    {
        myGoalManager = FindObjectOfType<GoalZoneManager>();
    }

    private void OnEnable()
    {
        myGoalManager.TankCapturingControlZone += AddScoreUI;
        myGoalManager.TankCapturingControlZone -= RemoveScoreUI;
    }


    private void OnDisable()
    {
        myGoalManager.TankCapturingControlZone -= AddScoreUI;
        myGoalManager.TankCapturingControlZone -= RemoveScoreUI;
    }


    private void AddScoreUI(PlayerNumber playerControlingZone, float controlPointsToAdd )
    {

        switch(playerControlingZone)
        {
            case PlayerNumber.One : SliderP1.value += controlPointsToAdd;
                break;
            case PlayerNumber.Two: SliderP2.value += controlPointsToAdd;
                break;
        }



    }
    private void RemoveScoreUI(PlayerNumber playerControlingZone, float controlPointsToRemove)
    {

        switch (playerControlingZone)
        {
            case PlayerNumber.One:
                SliderP1.value -= controlPointsToRemove;
                break;
            case PlayerNumber.Two:
                SliderP2.value -= controlPointsToRemove;
                break;
        }


        // ? How would I derement this when no tanks are in the zone

    }





}
