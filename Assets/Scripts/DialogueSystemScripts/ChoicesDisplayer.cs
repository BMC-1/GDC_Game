using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;

public class ChoicesDisplayer : MonoBehaviour
{
    static int number = 0;

    [SerializeField] Button choiceButtonToSpawn;
    [SerializeField] Button continueButton;

    [SerializeField] Transform choicesParent;
    [SerializeField] Transform choicesOnPanelPosition;

    [SerializeField] float distanceBetweenButtonsX;

    [SerializeField] DialogueManager dialogueManager;


    List<Button> choiceButtonsSpawned = new List<Button>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnTheChoices(Dialogue currentDialogue,int numberOfChoices)
    {
        

        if (currentDialogue.NextDialogue()==null && numberOfChoices>0)
        {
           
            Vector2 spawningButtonPos = Vector2.zero;


            for (int i = 0; i < currentDialogue.Choices().Length; i++)
            {

                Button choiceButtonClone = Instantiate(choiceButtonToSpawn, spawningButtonPos, Quaternion.identity);

                ChoiceButton choiceButton = choiceButtonClone.GetComponent<ChoiceButton>();

                choiceButton.buttonId = i;

                choiceButtonClone.name = i.ToString();

                choiceButtonClone.onClick.AddListener(delegate { dialogueManager.SetUpTheDialogueBox(currentDialogue.ChoicesOutComeDialogue()[choiceButton.buttonId]); });

                choiceButtonClone.transform.GetComponentInChildren<Text>().text = currentDialogue.Choices()[i];

                choiceButtonClone.name = "Choice:" + i;

                spawningButtonPos.x += distanceBetweenButtonsX;

                choiceButtonsSpawned.Add(choiceButtonClone);

            }

            SetTheChoicesMiddlePositionToParent();
        }
        else
        {
            ActivateOrNotTheContinueButton(true);
        }
   

    }

    

    void SetTheChoicesMiddlePositionToParent()
    {
        Vector2 middlePositionOfChoices=new Vector2(0, choiceButtonsSpawned[0].transform.position.y);

        foreach(Button choiceButton in choiceButtonsSpawned)
        {
            middlePositionOfChoices.x += choiceButton.transform.position.x;
        }

        middlePositionOfChoices.x /= choiceButtonsSpawned.Count;

        choicesParent.transform.position = middlePositionOfChoices;

        SetTheParentForChoices();

        MoveTheChoiceToDialogueBox();
    }

    void MoveTheChoiceToDialogueBox()
    {
        choicesParent.transform.position = choicesOnPanelPosition.position;
    }

    void SetTheParentForChoices()
    {
        foreach (Button choiceButton in choiceButtonsSpawned)
        {
            choiceButton.transform.parent = choicesParent;
        }

        choiceButtonsSpawned.Clear();
    }

    public void DeletePreviousChoices()
    {
        for(int i=0; i<choicesParent.childCount; i++)
        {
            
            Destroy(choicesParent.GetChild(i).gameObject);
        }
    }


    public void ActivateOrNotTheContinueButton(bool shouldItBeActive)
    {
        continueButton.gameObject.SetActive(shouldItBeActive);
    }
}
