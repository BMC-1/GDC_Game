using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTerrainSpawner : MonoBehaviour
{
    [SerializeField] BoatSpawner boatSpawner;
    [SerializeField] SeaObsticleSpawner seaObsticleSpawner;

    [SerializeField] Transform terrainBlock;
    [SerializeField] Transform terrainBlockParent;
    [SerializeField] Transform startingTerrainSpawnPosition;

    [SerializeField] int numberOfTerrainBlocksToSpawn;


    [SerializeField] float distanceBetweenTerrainBlocks;

    bool wasTheFirstTerrainBlockSpawned;

    public Transform firstTerrainBlockSpawned { get; set; }
    public Transform lastTerrainBlockSpawned { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        boatSpawner.SpawnTheShip(startingTerrainSpawnPosition.position);

        SpawnTheTerrainBlocks(startingTerrainSpawnPosition.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnTheTerrainBlocks(Vector3 spawningPos)
    {
        Vector3 terrainBlockPos = spawningPos;

        for(int i=0; i<numberOfTerrainBlocksToSpawn; i++)
        {
            Transform terrainBlockClone = Instantiate(terrainBlock, terrainBlockPos, Quaternion.identity);

            if(wasTheFirstTerrainBlockSpawned==true)
            {
                seaObsticleSpawner.SpawnObsticles(terrainBlockClone);


            }
            else
            {
                wasTheFirstTerrainBlockSpawned = true;
            }

            GetTheFirstOrLastSpawnedTerrainBlock(i, terrainBlockClone);

            terrainBlockClone.parent = terrainBlockParent;

            terrainBlockPos.z += distanceBetweenTerrainBlocks;

        }
    }

    void GetTheFirstOrLastSpawnedTerrainBlock(int spawnedBlockIndex,Transform spawnedBlock)
    {
        if(spawnedBlockIndex==0)
        {
            firstTerrainBlockSpawned = spawnedBlock;
        }
        else if(spawnedBlockIndex==numberOfTerrainBlocksToSpawn-1)
        {
            lastTerrainBlockSpawned = spawnedBlock;
        }
    }

    
}
