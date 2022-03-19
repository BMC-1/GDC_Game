using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.UI;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] ChoicesDisplayer choicesDisplayer;

    [SerializeField] Text dialogueText;
    [SerializeField] Text characterName;

    [SerializeField] GameObject dialogueBackround;

    [SerializeField] Image characteterImage;

    [SerializeField] float dialogueDisplaySpeed;

    Dialogue currentDialogue;

    bool isTheDialogueBeingDisplayed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUpTheDialogueBox(Dialogue currentDialogue)
    {
        if(currentDialogue!=null)
        {

            this.currentDialogue = currentDialogue;

            characterName.text = currentDialogue.nameOfCharacter;

            characteterImage.sprite = currentDialogue.characterImage;

            dialogueBackround.SetActive(true);

            StartCoroutine("DisplayDialogueLineCoroutine");
        }
        else
        {
            EndTheDialogue();
        }
      
    }

    IEnumerator DisplayDialogueLineCoroutine()
    {
        string lineToDisplay="";

        dialogueText.text = "";

        isTheDialogueBeingDisplayed = true;

        choicesDisplayer.DeletePreviousChoices();


        try
        {
            lineToDisplay = currentDialogue.CurrentLine();
        }
        catch(Exception e)
        {
            throw new Exception("next line not set");
        }
           

        dialogueBackround.SetActive(true);

        foreach (char letter in lineToDisplay)
        {
            dialogueText.text += letter;

            yield return new WaitForSeconds(dialogueDisplaySpeed);

        }
        isTheDialogueBeingDisplayed = false;

        choicesDisplayer.SpawnTheChoices(currentDialogue, currentDialogue.Choices().Length);

        
      

   
    }

    public void DisplayNextDialogueLines()
    {
        if(isTheDialogueBeingDisplayed==false)
        {
            choicesDisplayer.ActivateOrNotTheContinueButton(false);

            SetUpTheDialogueBox(currentDialogue.NextDialogue());

        }


    }

    void EndTheDialogue()
    {
        dialogueBackround.SetActive(false);

        dialogueText.text = "";
    }

}
