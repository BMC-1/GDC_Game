using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawmer : MonoBehaviour
{
    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void SpawnPlayer()
    {
        GameObject playerClone = Instantiate(player, this.transform.position, Quaternion.identity);
    }
}
