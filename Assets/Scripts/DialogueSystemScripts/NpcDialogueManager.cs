using System.Collections;
using System.Collections.Generic;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine;

public class NpcDialogueManager : MonoBehaviour
{
    [SerializeField] Dialogue dialogue;

    [SerializeField] Transform dialogueBox;

    [SerializeField] Transform buttonsParent;

    [SerializeField] TMP_Text dialogueText;
    [SerializeField] TMP_Text dialogueNameText;

    [SerializeField] float speedOfDialogue;

    Coroutine displayDialogue;

    bool isALineBeingShown;
    bool wasChoicesShown;
    bool isAConversationActive;
    // Start is called before the first frame update
  

    // Update is called once per frame
    void LateUpdate()
    {
        ContinueTheConversation();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.parent.tag=="Player")
        {
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

        for (int i = 0; i < buttonsParent.childCount; i++)
        {
            buttonsParent.GetChild(i).gameObject.SetActive(false);
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

    }

    IEnumerator DisplayConversation()
    {
        print(dialogue.name);

        dialogueText.text = "";

        dialogueNameText.text = dialogue.charactersConversation[dialogue.currentSpeakerIndex].characterName;

        isALineBeingShown = true;

        foreach (char letter in dialogue.charactersConversation[dialogue.currentSpeakerIndex].
            activeDialogueLines[dialogue.currentDialogueLineIndex])
        {
            dialogueText.text += letter;

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

                if(dialogue.currentSpeakerIndex>=dialogue.charactersConversation.Count)
                {
                    dialogue.currentSpeakerIndex = 0;

                    dialogue.currentDialogueLineIndex++;
                }
             

                if (dialogue.currentDialogueLineIndex < dialogue.charactersConversation[dialogue.currentSpeakerIndex].
                activeDialogueLines.Count)
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

            buttonsParent.GetChild(i).gameObject.SetActive(buttonsState);

            buttonsParent.GetChild(i).name = i.ToString();

            buttonsParent.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text = dialogue.choices[i];

            buttonsParent.GetChild(i).GetComponent<Button>().onClick.RemoveAllListeners();

            buttonsParent.GetChild(i).GetComponent<Button>().onClick.AddListener(delegate 
            { 
                ChangeDialogue(index);
                
            });

            
        }
    }

    private void ChangeDialogue(int index)
    {

        dialogue.currentSpeakerIndex = 0;

        dialogue.currentDialogueLineIndex = 0;

        foreach (Dialogue.CharactersConversation charactersConversation in dialogue.charactersConversation)
        {
            charactersConversation.ChangeDialogue(index);
        }

        wasChoicesShown = true;

        for(int i=0; i<buttonsParent.childCount; i++)
        {
            buttonsParent.GetChild(i).gameObject.SetActive(false);
        }

        displayDialogue = StartCoroutine("DisplayConversation");
    }

    private void SetMainDialogue()
    {
        foreach (Dialogue.CharactersConversation charactersConversation in dialogue.charactersConversation)
        {
            charactersConversation.SetActiveDialogue(charactersConversation.dialogueLines);
        }

    }







}
