using System.Collections;
using System.Collections.Generic;
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

    Queue<string> dialogueLines = new Queue<string>();
    Queue<string> dialogueChoices = new Queue<string>();

    bool isTheDialogueBeingDisplayed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDilaogue(Dialogue currentDialogue)
    {
        for (int i=0; i< currentDialogue.dialogues.Length; i++)
        {
            dialogueLines.Enqueue(currentDialogue.dialogues[i]);

            dialogueChoices.Enqueue(currentDialogue.dialogueChoices[i]);

        }

        characterName.text = currentDialogue.nameOfCharacter;

        characteterImage.sprite = currentDialogue.characterImage;

         dialogueBackround.SetActive(true);

        StartCoroutine("DisplayNextDialogueLinesCoroutine");
    }

    IEnumerator DisplayNextDialogueLinesCoroutine()
    {
        string lineToDisplay;

        dialogueText.text = "";


        if (dialogueLines.Count>0)
        {
            isTheDialogueBeingDisplayed = true;

            lineToDisplay = dialogueLines.Dequeue();

            dialogueBackround.SetActive(true);

            foreach (char letter in lineToDisplay)
            {
                dialogueText.text += letter;

                yield return new WaitForSeconds(dialogueDisplaySpeed);

            }
            isTheDialogueBeingDisplayed = false;

            choicesDisplayer.SpawnTheChoices(dialogueChoices.Dequeue());
        }
        else
        {
            EndTheDialogue();
        }

   
    }

    public void DisplayNextDialogueLines()
    {
        if(isTheDialogueBeingDisplayed==false)
        {
            choicesDisplayer.ActivateOrNotTheContinueButton(false);

            StartCoroutine("DisplayNextDialogueLinesCoroutine");
        }
    

    }

    void EndTheDialogue()
    {
        dialogueBackround.SetActive(false);

        dialogueText.text = "";
    }

}
