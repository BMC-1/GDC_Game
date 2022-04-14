using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainDestroyer : MonoBehaviour
{

    [SerializeField] WaterTerrainSpawner waterTerrainSpawner;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="WaterTerrainBlock")
        {
          
            if (waterTerrainSpawner.firstTerrainBlockSpawned == other.transform)
            {
                waterTerrainSpawner.SpawnTheTerrainBlocks(waterTerrainSpawner.lastTerrainBlockSpawned.position);
            }

            Destroy(other.gameObject);

        }
    }
}
