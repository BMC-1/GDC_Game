using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTerrainSpawner : MonoBehaviour
{
    [SerializeField] Transform terrainBlock;
    [SerializeField] Transform terrainBlockParent;
    [SerializeField] Transform startingTerrainSpawnPosition;

    [SerializeField] int numberOfTerrainBlocksToSpawn;

    //[SerializeField] float distanceBetweenTerrainBlocks;

    public Transform firstTerrainBlockSpawned { get; set; }
    public Transform lastTerrainBlockSpawned { get; set; }
    // Start is called before the first frame update
    void Start()
    {
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
            Transform terrainBlockClone = Instantiate(terrainBlock, terrainBlockPos, Quaternion.Euler(90, 0, 0));

            GetTheFirstOrLastSpawnedTerrainBlock(i, terrainBlockClone);

            terrainBlockClone.parent = terrainBlockParent;

            terrainBlockPos.z += terrainBlock.localScale.y;

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
