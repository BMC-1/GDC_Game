using Cinemachine;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    /// <summary>
    /// This script is based on an empty game object that manipulates the spawn point of the player
    /// You drag and drop to your scene an empty game object and passing the
    /// Parameters : cinemachineFreeLook is the third person camera
    /// </summary>
    [Header("Cinemachine camera")]
    public CinemachineFreeLook cinemachineFreeLook;
    
    void Start()
    {
        GameManager.instance.CharacterSpawn(this.transform);

        cinemachineFreeLook.transform.position = this.transform.position;
       cinemachineFreeLook.m_Follow = GameManager.instance.InitCharacter().transform.GetChild(0); 
       cinemachineFreeLook.m_LookAt = GameManager.instance.InitCharacter().transform.GetChild(0);
       
       //TopRig : Height 4 | Radius 2
       //MidRig : Height 2.7 | Radius 5
       //BotRig : Height 0.15 | Radius 2
    }
}
