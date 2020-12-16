using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuickSand : MonoBehaviour
{
    // a new QuickSand event
    public static UnityIntEvent QuickSandEvent = new UnityIntEvent();

    /// <summary>
    /// called upon another object entering any objects trigger attached with an instance of this script
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        //checks to see if the object in the trigger zone is tagged as "tank"
        if (other.tag == "tank")
        {
            Debug.LogWarning("the Tank is in the Quicksand!");//logs out the message in the parentheses
            //invokes the QuickSandEvent with a short hand if statement 
            //then passes in the new speed and the instance of the tanks transform
            QuickSandEvent?.Invoke(6,other.transform);
        }      
    }

    /// <summary>
    /// called when the other object leave the trigger zone of any collider with an instance of this script
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerExit(Collider other)
    {
        //checks to see if the object in the trigger zone is tagged as "tank"
        if (other.tag == "tank")
        {
            Debug.LogWarning("the Tank has left the Quicksand!");//logs out the message in the parentheses
            //invokes the QuickSandEvent with a short hand if statement 
            //then passes in the new speed and the instance of the tanks transform
            QuickSandEvent?.Invoke(12,other.transform);
        }
    }

    /// <summary>
    /// a custom unity event.
    /// holds the parameters for speed and the transform of an object
    /// in this instance the object will be the tanks.
    /// </summary>
    [System.Serializable]
    public class UnityIntEvent : UnityEvent<int, Transform>
    {

    }



}
