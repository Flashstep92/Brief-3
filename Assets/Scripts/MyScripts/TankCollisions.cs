using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCollisions : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
       // if (other) 
        {
            //if it does, add force on the y axis to move the object up 
            TankGameEvents.OnObjectTakeDamageEvent(transform, -20.0f);
            TankGameEvents.OnObjectTakeDamageEvent(other.transform, -20.0f);
        }
    }

   
    /// <summary>
    /// checks to see if a collision has occured 
    /// </summary>
    public void CheckCollision()
    {

    }

    

}
