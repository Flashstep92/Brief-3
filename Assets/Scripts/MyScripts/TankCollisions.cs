using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCollisions : MonoBehaviour
{

    /// <summary>
    /// called when another objects transform collides 
    /// with any object's mesh/box collider 
    /// that has an instance of this script.
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {   
        //check to see that it is not colliding with itself and or the grounds colliders/transforms
        if(collision.transform != transform && collision.transform.tag != "Ground")
        {
            //gets the name of the ingame object that the tank has collided with and logs out the below message
            Debug.LogWarning("Tank has crashed into " + collision.transform.name.ToString());
            //invokes the on object takes damage event with a short hand if statement
            //passes in a negative number to deal damage to tank.
            TankGameEvents.OnObjectTakeDamageEvent?.Invoke(transform, -5.0f);
        }             
    }
}
