using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] GameObject player;
 
    public void SpawnPlayer(Vector2 positionToSpawn)
    {
        player.transform.position = positionToSpawn;
    }
}
