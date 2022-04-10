using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueChoicesHandler : MonoBehaviour
{
    [Header("Choices that lead to loss of the game if any")]
    [SerializeField] string[] wrongChoices;

    [SerializeField] string[] losingMessageForWrongChoices;

    [SerializeField] LosingMessageDisplayer losingMessageDisplayer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckIfChoiceIsWrong(string choiceText)
    {
        for(int i=0; i<wrongChoices.Length; i++)
        {
            print(choiceText);

            if(choiceText==wrongChoices[i])
            {
                print("works");

                losingMessageDisplayer.DisplayTheLosingUiPanel(losingMessageForWrongChoices[i]);

                return;
            }
        }
    }
}
