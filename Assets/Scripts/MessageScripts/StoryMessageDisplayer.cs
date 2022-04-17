using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StoryMessageDisplayer : MonoBehaviour
{
    [SerializeField] Transform storyTellingUi;

    [SerializeField] Transform continueButtonMessage;

    [SerializeField] float speedOfLettersToAppear;

    [TextArea]
    [SerializeField] string storyToDisplay;

    bool isTheStoryBeingDisplayed;


    PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();

        print(playerController);

        StartCoroutine("DisplayTheStory");
    }

    // Update is called once per frame
    void Update()
    {
        CloseTheStoryBox();
    }

    IEnumerator DisplayTheStory()
    {
        storyTellingUi.gameObject.SetActive(true);

        isTheStoryBeingDisplayed = true;

        if(playerController!=null)
        {
            playerController.canThePlayerMove = false;

        }

        foreach (char letter in storyToDisplay)
        {
            storyTellingUi.GetComponentInChildren<TextMeshProUGUI>().text += letter;

            yield return new WaitForSeconds(speedOfLettersToAppear);
        }

        isTheStoryBeingDisplayed = false;

        continueButtonMessage.gameObject.SetActive(true);
    }

    void CloseTheStoryBox()
    {
        if(isTheStoryBeingDisplayed==false && Input.GetKeyDown(KeyCode.Mouse0) && storyTellingUi.gameObject.activeInHierarchy==true)
        {

            if (playerController != null)
            {
                playerController.canThePlayerMove = true;

            }

            storyTellingUi.gameObject.SetActive(false);

            

        }
    }

}
