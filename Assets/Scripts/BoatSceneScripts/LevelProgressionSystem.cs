using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelProgressionSystem : MonoBehaviour
{
    [Header("Time in seconds")]
    [SerializeField] float timeNeededForLevelCompletion;

    [Header("Rate in seconds")]
    [SerializeField] float progressionBarUpdatingRate;


    [SerializeField] Image uiProgressionBar;

   
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("StartProgressionTimer");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartProgressionTimer()
    {
        float currentTimePassed=0;

        while (currentTimePassed < timeNeededForLevelCompletion) 
        {
            currentTimePassed+= 1;

            IncreaseTheProgressionBar(currentTimePassed);

            yield return new WaitForSeconds(progressionBarUpdatingRate);
        }

        print("Arrived at destination");
    }

    void IncreaseTheProgressionBar(float currentTimePassed)
    {
        float progressionBarProgress = currentTimePassed / timeNeededForLevelCompletion;

        uiProgressionBar.fillAmount = progressionBarProgress;
    }

    public void StopTheProgressionTimer()
    {
        StopCoroutine("StartProgressionTimer");
    }
}
