using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine;

public class NpcDialogueManager : MonoBehaviour
{
    [SerializeField] Dialogue dialogue;

    [Header("Add this only when there are choices that lead to game loss")]
    [SerializeField] DialogueChoicesHandler dialogueChoicesHandler;
    [Header("Add this only dialogues change after this npcs talk")]
    [SerializeField] DialogueChanger dialogueChanger;

    [SerializeField] Transform dialogueBox;

    [Range(0.03f,1)]
    [SerializeField] float speedOfDialogue;

    Coroutine displayDialogue;


    string buttonChoiceText="";

    bool isALineBeingShown;
    bool wasChoicesShown;
    bool isAConversationActive;


    // Start is called before the first frame update


    private void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        ContinueTheConversation();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.parent.tag=="Player")
        {
            FindObjectOfType<PlayerController>().canThePlayerMove = false;

            ResetDialogue();

            SetMainDialogue();

            ActivateOrDeactivateDialogueBox(true);

            displayDialogue = StartCoroutine("DisplayConversation");

            isAConversationActive = true;

           
        }

    }

    private void ResetDialogue()
    {
        dialogue.currentSpeakerIndex = 0;

        dialogue.currentDialogueLineIndex = 0;

        wasChoicesShown = false;

        for (int i = 0; i < dialogueBox.GetChild(3).childCount; i++)
        {
            dialogueBox.GetChild(3).GetChild(i).gameObject.SetActive(false);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        ResetDialogue();

        ActivateOrDeactivateDialogueBox(false);

        StopCoroutine(displayDialogue);

        displayDialogue = null;

        isAConversationActive = false;


    }

    void ActivateOrDeactivateDialogueBox(bool activationState)
    {
        dialogueBox.gameObject.SetActive(activationState);

        if(activationState==false)
        {
            FindObjectOfType<PlayerController>().canThePlayerMove = true;

        }

    }

    IEnumerator DisplayConversation()
    {
        dialogueBox.GetChild(1).GetComponent<TextMeshProUGUI>().text = "";
       

        dialogueBox.GetChild(2).GetComponent<TextMeshProUGUI>().text = dialogue.charactersTalking[dialogue.currentSpeakerIndex].characterName;

        isALineBeingShown = true;

        foreach (char letter in dialogue.charactersTalking[dialogue.currentSpeakerIndex].
            ActiveDialogueLines()[dialogue.currentDialogueLineIndex])
        {
            dialogueBox.GetChild(1).GetComponent<TextMeshProUGUI>().text += letter;

            yield return new WaitForSeconds(speedOfDialogue);
        }

        isALineBeingShown = false;
    }

    void ContinueTheConversation()
    {
        if(isAConversationActive==true  && isALineBeingShown==false)
        {
            if(Input.GetKeyDown(KeyCode.Return))
            {
                dialogue.currentSpeakerIndex++;

                if(dialogue.currentSpeakerIndex>=dialogue.charactersTalking.Count)
                {
                    dialogue.currentSpeakerIndex = 0;

                    dialogue.currentDialogueLineIndex++;
                }
             

                if (dialogue.currentDialogueLineIndex < dialogue.charactersTalking[dialogue.currentSpeakerIndex].
                ActiveDialogueLines().Count)
                {
                    displayDialogue= StartCoroutine("DisplayConversation");
                }
                else
                {
                    if(dialogue.choices.Count>0 && wasChoicesShown==false)
                    {
                        print("works");

                        SetChoicesToButtons(true);

                    }
                    else
                    {
                        ActivateOrDeactivateDialogueBox(false);

                        if(dialogueChoicesHandler != null)
                        {
                            dialogueChoicesHandler.CheckIfChoiceIsWrong(buttonChoiceText);

                        }
                        if(dialogueChanger!=null)
                        {
                            dialogueChanger.ChangeDialogues(this.name);
                        }



                    }


                }
            }
        }
    }

    private void SetChoicesToButtons(bool buttonsState)
    {
        

        for(int i=0; i<dialogue.choices.Count; i++)
        {
            int index = i;

            dialogueBox.GetChild(3).GetChild(i).gameObject.SetActive(buttonsState);

            dialogueBox.GetChild(3).GetChild(i).name = i.ToString();

            dialogueBox.GetChild(3).GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text = dialogue.choices[index];

            dialogueBox.GetChild(3).GetChild(i).GetComponent<Button>().onClick.RemoveAllListeners();

            dialogueBox.GetChild(3).GetChild(i).GetComponent<Button>().onClick.AddListener(delegate 
            { 
                ChangeDialogue(index,dialogue.choices[index]);
                
            });

            
        }
    }

    private void ChangeDialogue(int index,string buttonChoiceText)
    {

        dialogue.currentSpeakerIndex = 0;

        dialogue.currentDialogueLineIndex = 0;

        foreach (Dialogue.CharactersConversation charactersConversation in dialogue.charactersTalking)
        {
            charactersConversation.ChangeDialogue(index);
        }

        wasChoicesShown = true;

        for(int i=0; i< dialogueBox.GetChild(3).childCount; i++)
        {
            dialogueBox.GetChild(3).GetChild(i).gameObject.SetActive(false);
        }

        this.buttonChoiceText = buttonChoiceText;

        displayDialogue = StartCoroutine("DisplayConversation");
    }

    void SetMainDialogue()
    {
        foreach (Dialogue.CharactersConversation charactersConversation in dialogue.charactersTalking)
        {
            charactersConversation.SetActiveDialogue(charactersConversation.mainDialogueLines);
        }

    }


    public void ChangeDialogue(Dialogue newDialogue)
    {
        dialogue = newDialogue;

    }




}
