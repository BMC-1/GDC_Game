using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatSpawner : MonoBehaviour
{
    [SerializeField] Transform ship;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnTheShip(Vector3 shipPos)
    {
        Transform shipClone = Instantiate(ship, shipPos, Quaternion.identity);
    }
}
