using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InstructionMessageDisplayer : MonoBehaviour
{

    [SerializeField] Transform instructionUiPanel;

    [SerializeField] Transform tabUiMessage;

    [SerializeField] string startingInstructionMessage;
    // Start is called before the first frame update
    void Start()
    {
        SetIntructionMessage(startingInstructionMessage);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            DisplayOrNotTheInstructionPanel();
        }
    }

    public void DisplayOrNotTheInstructionPanel()
    {
        instructionUiPanel.gameObject.SetActive(!instructionUiPanel.gameObject.activeInHierarchy);

        tabUiMessage.gameObject.SetActive(!instructionUiPanel.gameObject.activeInHierarchy);
    }

    public void SetIntructionMessage(string instunctionMessage)
    {
        instructionUiPanel.GetComponentInChildren<TextMeshProUGUI>().text = instunctionMessage;
    }

    
}
