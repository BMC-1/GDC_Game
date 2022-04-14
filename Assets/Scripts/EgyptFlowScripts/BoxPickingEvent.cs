using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPickingEvent : MonoBehaviour
{

    [SerializeField] EnviromentManager enviromentManager;

    [SerializeField] GameObject boxToPick;

    [SerializeField] List<GameObject> boxesNotToPick = new List<GameObject>();

    [SerializeField] string messageToDisplayForPickingWrongBox;

    

    DialogueChanger dialogueChanger;
    LosingMessageDisplayer losingMessageDisplayer;
    // Start is called before the first frame update
    void Start()
    {
        dialogueChanger = FindObjectOfType<DialogueChanger>();

        losingMessageDisplayer = FindObjectOfType<LosingMessageDisplayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateOutComeFromBoxPickingEvent(GameObject pickedItem)
    {
        if(boxToPick==pickedItem)
        {
            dialogueChanger.ChangeDialogues("Event");

            MakeTheBoxesNotToPickUnpickable();

            enviromentManager.SpawnObjects();

            FindObjectOfType<InventoryBehaviour>().RemoveItemFromInventory(null);

            FindObjectOfType<InstructionMessageDisplayer>().SetIntructionMessage("" +
                "Go back to Assim");

        }
        else if(boxesNotToPick.Contains(pickedItem))
        {
           losingMessageDisplayer.DisplayTheLosingUiPanel(messageToDisplayForPickingWrongBox);

        }
    }

    void MakeTheBoxesNotToPickUnpickable()
    {
        foreach(GameObject box in boxesNotToPick)
        {
            box.tag = "Untagged";
        }
    }
}
