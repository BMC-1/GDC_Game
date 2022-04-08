using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDamageTrigger : MonoBehaviour
{
    [SerializeField] string tagOfDamagingObjects;

    BoatJumpingMotion boatJumpingMotion;
    
    HealthSystem healthSystem;


    // Start is called before the first frame update
    private void Awake()
    {
        boatJumpingMotion = FindObjectOfType<BoatJumpingMotion>();

        healthSystem = FindObjectOfType<HealthSystem>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag==tagOfDamagingObjects)
        {
            healthSystem.DecreaseHealth(1);
        }
        else if(other.tag=="WaterTerrainBlock")
        {
            if(boatJumpingMotion.isTheBoatInTheAir==true)
            {
                boatJumpingMotion.ActivateOrNotGravity(false);

            }
        }
        
    }



  
}
