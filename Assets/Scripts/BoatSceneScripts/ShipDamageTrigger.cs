using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipDamageTrigger : MonoBehaviour
{
    [SerializeField] string tagOfDamagingObjects;

    [Header("counted in seconds")]
    [SerializeField] float timeForDamageImmunityAfterDamage;

    bool isThePlayerimmuneToDamage;

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
            if(isThePlayerimmuneToDamage==false)
            {
                healthSystem.DecreaseHealth(1);

                StartCoroutine("StartDamageImmunityTimer");

            }
        }
        else if(other.tag=="WaterTerrainBlock")
        {
            if(boatJumpingMotion.isTheBoatInTheAir==true)
            {
                boatJumpingMotion.ActivateOrNotGravity(false);

            }
        }
        
    }

    
    IEnumerator StartDamageImmunityTimer()
    {
        isThePlayerimmuneToDamage = true;

        yield return new WaitForSeconds(timeForDamageImmunityAfterDamage);

        isThePlayerimmuneToDamage = false;
    }


  
}
