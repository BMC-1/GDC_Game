using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;


[CreateAssetMenu(fileName = "DialogueNo", menuName = "Dialogue/DialogueInfo", order = 2)]
public class Dialogue : ScriptableObject
{
    public List<CharactersConversation> charactersConversation = new List<CharactersConversation>();

    public int currentSpeakerIndex{ get; set; }

    public int currentDialogueLineIndex { get; set; }

    [Header("Choices(optional)")]
    public List<string> choices = new List<string>();

    [Serializable]
    public class CharactersConversation
    {
        public string characterName;

        [TextArea]
        public List<string> dialogueLines=new List<string>();

  
        [Header("optional")]
        [TextArea]
        public List<string> choiceOneDialogues = new List<string>();

        [Header("optional")]
        [TextArea]
        public List<string> choiceTwoDialogues = new List<string>();

        public List<string> activeDialogueLines = new List<string>();

        

        public void ChangeDialogue(int buttonIndex)
        {
            if(buttonIndex==0)
            {
                SetActiveDialogue(choiceOneDialogues);

            }
            else
            {
                SetActiveDialogue(choiceTwoDialogues);

            }
        }

        public void SetActiveDialogue(List<string> dialogueList)
        {
            activeDialogueLines.Clear();

            foreach(string dialogue in dialogueList)
            {
                activeDialogueLines.Add(dialogue);

                Debug.Log(dialogue);

            }
        }



    }
}





