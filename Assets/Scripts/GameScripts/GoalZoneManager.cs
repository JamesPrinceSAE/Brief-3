using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalZoneManager : MonoBehaviour
{

    public float MaxCaptureAmount = 10;
    public float ZoneCaptureAmountPerSecond = 1;
    public float TimeBetweenCaptureTicks = 1;
    public float currentCaptureScore;

    private bool isControlPointInConflict = false;
    private bool hasZoneBeenClaimed = false;
    private bool isZoneBeingCaptured = false;


    private List<Tank> TanksCurrentlyInZone = new List<Tank>();
    private Tank currentlyZoneControllingTank;

    private MeshRenderer myRenderer => GetComponent<MeshRenderer>();
   
    public delegate void ControlZoneStatus(PlayerNumber tankPlayerNumberID,  float controlPointToIncrementBy);
    public event ControlZoneStatus TankCapturingControlZone;


    private IEnumerator ControlPointCaptureTimer()
    {
        while(isZoneBeingCaptured == true)
        {
            if (isControlPointInConflict) yield return null; // ignore corrotine if zone is being contested

            if (!hasZoneBeenClaimed) // ignore if the zone's colour has already been set
            {
                var TankRenderers = TanksCurrentlyInZone[0].GetComponentsInChildren<MeshRenderer>();
                var TankChassisRenderer = TankRenderers[0];
                myRenderer.material.color = TankChassisRenderer.material.color;
                hasZoneBeenClaimed = true;
            }

            // Finally update our UI using an event
            TankCapturingControlZone?.Invoke(TanksCurrentlyInZone[0].playerNumber, ZoneCaptureAmountPerSecond);
            
            yield return new WaitForSeconds(TimeBetweenCaptureTicks);
        }
    }

    private IEnumerator ControlPointReductionTimer()
    {
        while (isZoneBeingCaptured == false)
        {
            // Finally update our UI using an event
            TankCapturingControlZone?.Invoke(TanksCurrentlyInZone[0].playerNumber, -1);

            yield return new WaitForSeconds(TimeBetweenCaptureTicks);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        Tank tankComponent = other.gameObject.GetComponent<Tank>();

        if (tankComponent == true)
        {

            TanksCurrentlyInZone.Add(tankComponent);

            // CHeck if tank is in the zone, if so, store the reference
            if (TanksCurrentlyInZone.Count == 1) 
            {
                isControlPointInConflict = false;
                isZoneBeingCaptured = true;
                currentlyZoneControllingTank = TanksCurrentlyInZone[0];
                StartCoroutine(ControlPointCaptureTimer());
                StopCoroutine(ControlPointReductionTimer());
            }

            
            if (TanksCurrentlyInZone.Count > 1)
            {
                isControlPointInConflict = true;
            }
        }

       
    }

    private void OnTriggerExit(Collider other)
    {

        Tank tankComponent = other.gameObject.GetComponent<Tank>();

        if (tankComponent == true)
        {
            TanksCurrentlyInZone.Remove(tankComponent);
            currentlyZoneControllingTank = null;

            if (TanksCurrentlyInZone.Count == 0)
            {
                isZoneBeingCaptured = false;
                StopCoroutine(ControlPointCaptureTimer());
                StartCoroutine(ControlPointReductionTimer());
            }
        }
        myRenderer.material.color = Color.white;
    }

}


