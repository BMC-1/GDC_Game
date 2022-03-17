using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] Text dialogueText;

    Queue<string> dialogueLines = new Queue<string>();

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
        foreach (string dialogue in currentDialogue.Dialogues())
        {
            dialogueLines.Enqueue(dialogue);
            dialogueLines.Enqueue(dialogue);
        }
    }
}
