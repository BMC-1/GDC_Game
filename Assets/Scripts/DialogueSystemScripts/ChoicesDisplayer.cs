using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;

public class ChoicesDisplayer : MonoBehaviour
{

    [SerializeField] Button choiceButton;
    [SerializeField] Button continueButton;

    [SerializeField] Transform choicesParent;
    [SerializeField] Transform choicesOnPanelPosition;

    [SerializeField] float distanceBetweenButtonsX;

    List<Button> choiceButtonsSpawned = new List<Button>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnTheChoices(string choices)
    {
        if(CheckIfChoicesShouldAppear(choices))
        {
            string[] seperatedChoices = choices.Split(',');

            Vector2 spawningButtonPos = Vector2.zero;

            DeletePreviousChoices();

            for (int i = 0; i < seperatedChoices.Length; i++)
            {
                Button choiceButtonClone = Instantiate(choiceButton, spawningButtonPos, Quaternion.identity);

                choiceButtonClone.transform.GetComponentInChildren<Text>().text = seperatedChoices[i];

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

    void DeletePreviousChoices()
    {
        for(int i=0; i<choicesParent.childCount; i++)
        {
            
            Destroy(choicesParent.GetChild(i).gameObject);
        }
    }

    bool CheckIfChoicesShouldAppear(string choices)
    {
        if(choices!="")
        {

            return true;
        }
        else
        {
            return false;
        }
    }

    public void ActivateOrNotTheContinueButton(bool shouldItBeActive)
    {
        continueButton.gameObject.SetActive(shouldItBeActive);
    }
}
