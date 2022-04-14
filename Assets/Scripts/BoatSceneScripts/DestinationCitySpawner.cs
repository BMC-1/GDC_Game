using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationCitySpawner : MonoBehaviour
{
    [SerializeField] Transform destinationCity;

    [SerializeField] SpeedChangingEvent speedChangingEvent;

    bool wasTheDestinationCitySpawned { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnTheDestinationCity(Transform positionToSpawn)
    {
        if(wasTheDestinationCitySpawned==false)
        {
            Transform destinationCityClone = Instantiate(
          destinationCity, positionToSpawn.position, Quaternion.identity);

            destinationCityClone.parent = positionToSpawn;

            speedChangingEvent.GetBoatAndDestinationCity(GameObject.FindGameObjectWithTag("Player"), destinationCityClone.gameObject);

            wasTheDestinationCitySpawned = true;
        }
      
    }
}
