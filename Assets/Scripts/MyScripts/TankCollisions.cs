﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCollisions : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
      
        
         TankGameEvents.OnObjectTakeDamageEvent?.Invoke(transform, -5.0f);
         Debug.LogWarning("Tank has crashed into " + transform.name.ToString());
        
    }



    
    

}
