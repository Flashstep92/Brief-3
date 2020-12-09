using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthZones : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        TankGameEvents.OnObjectTakeDamageEvent(other.transform, 15.0f);
        Debug.Log("Has Entered the mine trigger zone Trigger");
        //checks to see if the object in the trigger zone has a rigid body.       
    }

    private void OnTriggerExit(Collider other)
    {

    }
    
   
   

}
