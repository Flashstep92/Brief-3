using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthZones : MonoBehaviour
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
    /// handles the AOE heal efftect of the healing zone
    /// </summary>
    /// <param name="amountToHeal"></param>
    /// <returns></returns>
    public float HealingZones(float amountToHeal)
    {
        

        return amountToHeal;
    }

}
