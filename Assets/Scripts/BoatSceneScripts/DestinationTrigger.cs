using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationTrigger : MonoBehaviour
{
    WinningScreenDisplayer winningScreenDisplayer;

    LevelSpeedChanger levelSpeedChanger;
    // Start is called before the first frame update
    void Start()
    {
        levelSpeedChanger = FindObjectOfType<LevelSpeedChanger>();

        winningScreenDisplayer = FindObjectOfType<WinningScreenDisplayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            levelSpeedChanger.SetLevelSpeed(0);
        }
        
    }
}
