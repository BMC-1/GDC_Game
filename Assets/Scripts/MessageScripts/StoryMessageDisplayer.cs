using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StoryMessageDisplayer : MonoBehaviour
{
    [SerializeField] Transform storyTellingUi; 

    [SerializeField] float speedOfLettersToAppear;

    [TextArea]
    [SerializeField] string storyToDisplay;

    bool isTheStoryBeingDisplayed;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("DisplayTheStory");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator DisplayTheStory()
    {
        storyTellingUi.gameObject.SetActive(true);

        isTheStoryBeingDisplayed = true;

        foreach (char letter in storyToDisplay)
        {
            storyTellingUi.GetComponent<TextMeshProUGUI>().text += letter;

            yield return new WaitForSeconds(speedOfLettersToAppear);
        }

    }

    void CloseTheStoryBox()
    {
        if(isTheStoryBeingDisplayed==true && Input.GetKeyDown(KeyCode.Mouse0))
        {
            isTheStoryBeingDisplayed = false;

            storyTellingUi.gameObject.SetActive(false);


        }
    }

}
