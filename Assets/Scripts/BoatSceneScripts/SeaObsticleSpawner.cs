using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaObsticleSpawner : MonoBehaviour
{
    [SerializeField] Transform seaObsticle;

    [SerializeField] float distanceBetweenObsticles;

    [SerializeField] int[] minAndMaxNumberOfObsticlesPerSeaBlock;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnObsticles(Transform seaBlock)
    {
        int numberOfObsticlesToSpawn = Random.Range(minAndMaxNumberOfObsticlesPerSeaBlock[0], 
            minAndMaxNumberOfObsticlesPerSeaBlock[1]);

        for(int i=0; i<numberOfObsticlesToSpawn; i++)
        {
            GameObject obsticleClone = Instantiate(seaObsticle.gameObject, GenerateRandomPosition(seaBlock), Quaternion.identity);

            obsticleClone.transform.parent = seaBlock;
        }
    }

    Vector3 GenerateRandomPosition(Transform seaBlock)
    {
        
        Vector3 randomPos=Vector3.zero;

        do
        {

            randomPos.x = Random.Range(seaBlock.GetChild(0).position.x, seaBlock.GetChild(1).position.x);

            randomPos.z = Random.Range(seaBlock.GetChild(0).position.z, seaBlock.GetChild(1).position.z);

        } while (IsTheDistanceBetweenObsticlesSuitable(randomPos) == false);

        return randomPos;

    }

    bool IsTheDistanceBetweenObsticlesSuitable(Vector3 generatedPos)
    {
        GameObject[] obsticlesOnScene = GameObject.FindGameObjectsWithTag("SeaObsticle");

        if(obsticlesOnScene.Length>0)
        {
            foreach (GameObject obsticle in obsticlesOnScene)
            {
                if (Vector3.Distance(obsticle.transform.position, generatedPos) < distanceBetweenObsticles)
                {
                    return false;
                }
            }
        }
       

        return true;
    }    
}
