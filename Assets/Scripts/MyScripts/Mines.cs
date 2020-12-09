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
            TriggerMine();
            triggered = true;
           
            Debug.Log("Has Entered the mine trigger zone Trigger");
            //checks to see if the object in the trigger zone has a rigid body.
            if (other.GetComponent<Rigidbody>())
            {
                //if it does, add force on the y axis to move the object up 
                other.GetComponent<Rigidbody>().AddForce(Vector3.up * 300);
                TankGameEvents.OnObjectTakeDamageEvent(other.transform, -20.0f);
            }
        }
        Destroy(gameObject);
    }

    /// <summary>
    /// Activates the mine when tanks enter trigerzone
    /// 
    /// </summary>
    public void TriggerMine()
    {
        explosion.SetActive(true);
        rigid.transform.position += Vector3.up;
        //mine should shoot up and deal damage.
    }
   



}
