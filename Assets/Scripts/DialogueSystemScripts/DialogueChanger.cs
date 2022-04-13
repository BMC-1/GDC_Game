using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class DialogueChanger : MonoBehaviour
{
    [Header("each time you talk to a person whose name in on top of list dialogues change")]
    [SerializeField] List<string> peopleToTalkToChangeDialogueSet;

    [SerializeField] List<DialogueChanges> dialogueSetChanges;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeDialogues(string nameOfPersonWhoTalked)
    {
        if(peopleToTalkToChangeDialogueSet.Count>0)
        {
            if (nameOfPersonWhoTalked == peopleToTalkToChangeDialogueSet[0] || nameOfPersonWhoTalked == "Event")
            {
                for (int i = 0; i < dialogueSetChanges[0].npcsToChangeDialogue.Length; i++)
                {
                    dialogueSetChanges[0].npcsToChangeDialogue[i].ChangeDialogue(dialogueSetChanges[0].dialoguesToAdd[i]);
                }

                dialogueSetChanges.Remove(dialogueSetChanges[0]);

                peopleToTalkToChangeDialogueSet.Remove(peopleToTalkToChangeDialogueSet[0]);
            }
        }
      
     
    }

    [Serializable]
    public class DialogueChanges
    {
        public NpcDialogueManager[] npcsToChangeDialogue;

        public Dialogue[] dialoguesToAdd;


    }

}
