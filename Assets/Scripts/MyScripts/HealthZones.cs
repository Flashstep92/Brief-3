using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthZones : MonoBehaviour
{
    public List<Transform> tanks = new List<Transform>();
    /// <summary>
    /// check to see if the object entering has the tag "tank".
    /// if it dose, heal it for five health
    /// if it is not log out any other object that is interacting with this trigger.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "tank")
        {
            tanks.Add(other.transform);          
            Debug.Log("Has Entered the mine trigger zone Trigger");               
        }
        else if (other.tag != "Quicksand" || other.tag != "Mine" || other.tag != "UnInteractable")
        {
            Debug.LogWarning("something else is Activating this trigger" + other.transform.name.ToString());
        }
    }

    private void Update()
    {
        for (int i = 0; i < tanks.Count; i++)
        {
            TankGameEvents.OnObjectTakeDamageEvent?.Invoke(tanks[i], 5.0f*Time.deltaTime);
        }
    }

    /// <summary>
    /// logs out that the tank has left the trigger zone.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        tanks.Remove(other.transform);
        Debug.LogWarning("The Tank has left the healing zone!");//logs out the message upon trigger exit.
    }    
}
