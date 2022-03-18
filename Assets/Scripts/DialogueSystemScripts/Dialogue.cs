using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public  string nameOfCharacter;
    [TextArea]
    public string[] dialogues;

    [TextArea]
    [Tooltip("apply choices for each dialog if there are no choices leave it empty,seperate multiple choices with ,")]
    public string[] dialogueChoices;

    public Sprite characterImage;

    DialogueManager dialogueManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



 

}
