using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTerrainMovement : MonoBehaviour
{
    [SerializeField] float defaultSpeed;

    float currentSpeed;
    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = defaultSpeed;

        
    }

    // Update is called once per frame
    void Update()
    {
        MoveTheTerrain();
    }

    void MoveTheTerrain()
    {
        this.transform.position += Vector3.back*currentSpeed*Time.deltaTime;
    }
}
