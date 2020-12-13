using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuickSand : MonoBehaviour
{
    public UnityEvent QuickSandEvent = new UnityEvent();

    private void OnEnable()
    {
        QuickSandEvent.AddListener(SlowTankSpeed);
    }

    private void OnDisable()
    {
        QuickSandEvent.RemoveListener(SlowTankSpeed);
    }
    public void SlowTankSpeed()
    {

        
    }

    



}
