using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpeedChanger : MonoBehaviour
{
    [SerializeField] WaterTerrainMovement waterTerrainMovement;

    [SerializeField] float speedToAdd;
    [SerializeField] float secondsToPassForSpeedChange;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("TimerForSpeedChange");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TimerForSpeedChange()
    {
        while(true)
        {
            waterTerrainMovement.currentSpeed += speedToAdd;

            yield return new WaitForSeconds(secondsToPassForSpeedChange);
        }
    }

    public void SetLevelSpeed(float speed)
    {
        waterTerrainMovement.currentSpeed = speed;
    }

    public void StopTheTimerForSpeedChange()
    {
        StopCoroutine("TimerForSpeedChange");
    }
}
