using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] Text dialogueText;

    [SerializeField] Text characterName;

    [SerializeField] GameObject dialogueBackround;

    [SerializeField] Image characteterImage;

    [SerializeField] float dialogueDisplaySpeed;

    Queue<string> dialogueLines = new Queue<string>();


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
        foreach (string dialogue in currentDialogue.dialogues)
        {
            dialogueLines.Enqueue(dialogue);
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
            print("works");

            StartCoroutine("DisplayNextDialogueLinesCoroutine");
        }
    

    }

    void EndTheDialogue()
    {
        dialogueBackround.SetActive(false);

        dialogueText.text = "";
    }

}
