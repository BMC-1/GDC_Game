using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Dialogue : MonoBehaviour
{

    public string nameOfCharacter;

    public Sprite characterImage;


    [TextArea]
    [SerializeField] string[] dialogues;

    [Header("Apply a next dialogue for every dialogue if there is no dialogue to go to leave it empty")]
    [SerializeField] Dialogue[] nextDialogue;

    [TextArea]

    [Header("The Choices will apply only at the last dialogue")]
    [SerializeField] string[] choices;

    [SerializeField] Dialogue[] choicesOutComeDialogues;


    int currentDialogueLine = -1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string CurrentLine()
    {
        currentDialogueLine++;

        return dialogues[currentDialogueLine];
    }

    public Dialogue NextDialogue()
    {
        return nextDialogue[currentDialogueLine];
    }

    public string [] Choices()
    {
        return choices;
    }

    public Dialogue[] ChoicesOutComeDialogue()
    {
        return choicesOutComeDialogues;
    }






}
