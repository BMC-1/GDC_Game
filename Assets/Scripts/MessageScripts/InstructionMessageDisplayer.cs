using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InstructionMessageDisplayer : MonoBehaviour
{

    [SerializeField] Transform instructionUiPanel;

    [SerializeField] Transform instructionInfoBox;

    // Start is called before the first frame update
    void Start()
    {
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

        instructionInfoBox.gameObject.SetActive(!instructionUiPanel.gameObject.activeInHierarchy);
    }

    public void SetIntructionMessage(string instunctionMessage)
    {
        instructionInfoBox.GetComponentInChildren<TextMeshProUGUI>().text = instunctionMessage;

        
    }

    
}
