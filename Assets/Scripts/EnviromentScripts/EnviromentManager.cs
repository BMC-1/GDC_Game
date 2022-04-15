using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentManager : MonoBehaviour
{
    [SerializeField] GameObject[] objectsToSpawn;
    [SerializeField] Transform[] positionToSpawnObjects;

    [SerializeField] GameObject[] objectsToDestroy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void SpawnObjects()
    {
        for(int i=0; i< objectsToSpawn.Length; i++)
        {
            GameObject objectToSpawnClone = Instantiate(objectsToSpawn[i],
                positionToSpawnObjects[i].position, Quaternion.identity);

            objectToSpawnClone.transform.parent = positionToSpawnObjects[i];

            if(positionToSpawnObjects[i].GetComponent<EnviromentChangerTrigger>())
            {
                positionToSpawnObjects[i].GetComponent<EnviromentChangerTrigger>().ActivateTrigger();
            }
        }
    }

    public void DestroyObjects()
    {
        foreach(GameObject objectToDestroy in objectsToDestroy)
        {
            Destroy(objectToDestroy);
        }
    }
}
