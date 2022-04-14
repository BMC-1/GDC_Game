using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedChangingEvent : MonoBehaviour
{
    [SerializeField] LevelSpeedChanger levelSpeedChanger;

    [SerializeField] float speedToChangeToTo;
    [SerializeField] float distanceBetweenCityAndBoatToChangeSpeed;

    GameObject boat;
    GameObject destinationCity;



    bool wasSpeedChanged;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(boat!=null && destinationCity!=null)
        {
            print(Vector3.Distance(boat.transform.position, destinationCity.transform.position));
            CheckIfBoatIsCloseToCity();
        }
        
    }

    void CheckIfBoatIsCloseToCity()
    {
        if(wasSpeedChanged==false)
        {
            if (Vector3.Distance(boat.transform.position, destinationCity.transform.position)< distanceBetweenCityAndBoatToChangeSpeed)
            {
                levelSpeedChanger.StopTheTimerForSpeedChange();

                levelSpeedChanger.SetLevelSpeed(speedToChangeToTo);

                wasSpeedChanged = true;

            }
        }
        
    }

    public void GetBoatAndDestinationCity(GameObject boat,GameObject destinationCity)
    {
        this.boat = boat;

        this.destinationCity = destinationCity;
    }
}
