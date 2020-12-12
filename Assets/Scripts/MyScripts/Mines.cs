using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mines : MonoBehaviour
{
    private bool triggered;
    private Rigidbody rigid;
    public GameObject explosion;
    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        
        explosion.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(triggered == false)
        {                      
            if(other.tag == "tank")//checks to see if the object in the trigger zone is tagged as tank.
            {
                TriggerMine();
                triggered = true;
                Debug.Log("Tank Has Entered the mine trigger zone");//logs out the message when the tank has entered the trigger zone.              
                other.GetComponent<Rigidbody>().AddForce(Vector3.up * 300); //gets the rigid body of the other object and adds force on the 'Y' axis 
                TankGameEvents.OnObjectTakeDamageEvent(other.transform, -20.0f); //calls the on take damage event and deals damage using the health function in nathans scripts.               
            }
            else if(other.tag != "Quicksand" && other.tag != "HealingZone" && other.tag != "UnInteractable")
            {
                Debug.LogError("something else is Activating this trigger" + " " + other.transform.name.ToString());
            }
        }
        
    }

    /// <summary>
    /// Activates the mine when tanks enter trigerzone
    /// pops up the mine & plays the particle effect
    /// </summary>
    public void TriggerMine()
    {
        explosion.SetActive(true);
        rigid.transform.position += Vector3.up;
        Destroy(gameObject, 3);
    }
   



}
