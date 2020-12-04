using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mines : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        
    }

    /// <summary>
    /// Activates the mine when tanks enter trigerzone
    /// 
    /// </summary>
    public void ActivateMineOnTrigger()
    {
       // mine should shoot up and deal damage.
    }


    /// <summary>
    /// handles the amount of damage 
    /// </summary>
    /// <param name="amountOfDamage"></param>
    /// <returns></returns>
    public float DealMineDamage(float amountOfDamage)
    {
        return amountOfDamage;
    }




}
