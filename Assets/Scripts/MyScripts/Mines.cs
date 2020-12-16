using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mines : MonoBehaviour
{
    private bool triggered; // a bool for the status of the mines
    private Rigidbody rigid; //a reference to the rigidbody of objects in the scene
    public GameObject explosion;// a reference to the particle effects of the mine.
    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        
        explosion.SetActive(false);//sets the particle effects of the mine to be inactive
    }

    /// <summary>
    /// called upon another object entering any objects trigger attached with an instance of this script
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if(triggered == false)//if the mine has not yet been triggered.
        {                      
            if(other.tag == "tank")//checks to see if the object in the trigger zone is tagged as tank, if it is the run the below code 
            {
                TriggerMine();//call the TriggerMine function.
                triggered = true;// sets the status of weather the mine is triggered to true
                Debug.Log("Tank Has Entered the mine trigger zone");//logs out the message when the tank has entered the trigger zone.              
                other.GetComponent<Rigidbody>().AddForce(Vector3.up * 300); //gets the rigid body of the other object and adds force on the 'Y' axis 
                TankGameEvents.OnObjectTakeDamageEvent(other.transform, -20.0f); //calls the on take damage event and deals damage using the health function in nathans scripts.               
            }
            // i have left Quicksand out on purpose in this statement to show that below code works.
            //checks to see if the object colliding with ther mines trigger zone has one of these tags
            else if(other.tag != "Quicksand" && other.tag != "HealingZone" && other.tag != "UnInteractable")
            {
                //if the object does not have one of the above tags then debug log the below 
                Debug.LogWarning("something else is Activating this trigger" + " " + other.transform.name.ToString());
            }
        }
        
    }

    /// <summary>
    /// Activates the mine when tanks enter trigerzone
    /// pops up the mine & plays the particle effect
    /// removes the mine from the scene 
    /// </summary>
    public void TriggerMine()
    {
        explosion.SetActive(true); // sets the particle effects of the mine to active 
        rigid.transform.position += Vector3.up;//uses the rigid body to move the mine up out of the ground
        Destroy(gameObject, 3);//destroys the mine and removes it from the scene after 3 seconds 
    }
   



}
