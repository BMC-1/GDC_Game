using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] LevelProgressionSystem levelProgressionSystem;
    [SerializeField] LosingMessageDisplayer losingMessageDisplayer;

    [SerializeField] Transform uiPanel;

    LevelSpeedChanger levelSpeedChanger;

    int numberOfActiveUiIcon;
    // Start is called before the first frame update
    void Start()
    {
        

        levelSpeedChanger = FindObjectOfType<LevelSpeedChanger>();

        SpawnTheHealthUi(uiPanel.childCount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnTheHealthUi(int numberOfHealthIconToSpawn)
    {
        for(int i=0; i< numberOfHealthIconToSpawn; i++)
        {

            if(i<uiPanel.childCount)
            {
                if(uiPanel.GetChild(i).gameObject.activeInHierarchy==false)
                {
                    uiPanel.GetChild(i).gameObject.SetActive(true);

                    numberOfActiveUiIcon++;
                }
            }
            else
            {
                break;
            }

        }
    }

    public void DecreaseHealth(int numberOfUiIconsToRemove)
    {

        for(int i=0; i<numberOfUiIconsToRemove; i++)
        {
            if(numberOfActiveUiIcon>0)
            {
                uiPanel.GetChild(numberOfActiveUiIcon - 1).gameObject.SetActive(false);

                print(numberOfActiveUiIcon - 1);

                numberOfActiveUiIcon--;

                if(numberOfActiveUiIcon<=0)
                {
                    levelSpeedChanger.SetLevelSpeed(0);

                    levelSpeedChanger.StopTheTimerForSpeedChange();

                    levelProgressionSystem.StopTheProgressionTimer();

                    FindObjectOfType<ShipMovement>().DisableShipSideWaysMovement();

                    losingMessageDisplayer.DisplayTheLosingUiPanel("The ship shank");
                }


            }
          
        }
    }
}
