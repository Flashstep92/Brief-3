using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthZones : MonoBehaviour
{
    public List<Transform> tanks = new List<Transform>();// list of the tank transforms 

    /// <summary>
    /// check to see if the object entering has the tag "tank".
    /// if it dose, heal it for five health
    /// if it is not log out any other object that is interacting with this trigger.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        //checks to see if the object in the trigger zone is tagged as "tank"
        if(other.tag == "tank")
        {
            tanks.Add(other.transform); //adds this instance of the tank to the list of tank tranforms         
            Debug.LogWarning("the tank has Entered the healing zone"); //logs out the message in the parenthese               
        }
        //check to see if the tag attached to the objec is not one of these 
        else if(other.tag != "Quicksand" && other.tag != "Mine" && other.tag != "UnInteractable")
        {
            //if it isn't then log out the following.
            Debug.LogWarning("something else is Activating this trigger" + other.transform.name.ToString());
        }
    }

    private void Update()
    {
        //goes through the list of tanks then iterates i, this will happen every fram as its inside the update function.
        for (int i = 0; i < tanks.Count; i++)
        {
            /*at the position of i in the list of tank transforms
             * Invokes the on object take damage event with a short hand if statement
             * passes in positive float and multiplies this by the Delta time
             * as this is in the update functions and called every frame it creates a heal over time effect.
             */
            TankGameEvents.OnObjectTakeDamageEvent?.Invoke(tanks[i], 5.0f*Time.deltaTime);
        }
    }

    /// <summary>
    /// logs out that the tank has left the trigger zone.
    /// removes this instance of the tank from the list of tank transforms
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        tanks.Remove(other.transform);//removes the tank from the list of tanks 
        Debug.LogWarning("The Tank has left the healing zone!");//logs out the message upon trigger exit.
    }    
}
