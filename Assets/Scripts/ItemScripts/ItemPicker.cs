using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemPicker : MonoBehaviour
{


    [SerializeField] TextMeshProUGUI pickUpMessage;

    [SerializeField] string messageToDisplay;


    Transform itemToPickUp;

    InventoryBehaviour inventoryBehaviour;

     BoxPickingEvent boxPickingEvent;
    // Start is called before the first frame update
    void Start()
    {
        if(FindObjectOfType<BoxPickingEvent>())
        {
            boxPickingEvent = FindObjectOfType<BoxPickingEvent>();
        }

        inventoryBehaviour = FindObjectOfType<InventoryBehaviour>();

    }

    // Update is called once per frame
    void Update()
    {
        PickUpItem();
    }

    private void OnTriggerStay(Collider other)
    {
        DisplayPickMessage(other);

        itemToPickUp = other.transform;

    }

    private void OnTriggerExit(Collider other)
    {
        ClosePickUpMessage();
    }

    void DisplayPickMessage(Collider other)
    {
        if (other.tag == "Pickable")
        {
            pickUpMessage.text = messageToDisplay + ":" + other.name;

        }
    }

    void ClosePickUpMessage()
    {
        pickUpMessage.text = "";

        itemToPickUp = null;
    }

    void PickUpItem()
    {
        if(itemToPickUp!=null && Input.GetKeyDown(KeyCode.Q))
        {
            if(inventoryBehaviour.AreThereEmptySlots()==true)
            {
                inventoryBehaviour.AddItemToInventory(itemToPickUp.GetComponent<PickableItem>().itemToPick);

                if (itemToPickUp.GetComponent<RespawnableItemBehaviour>())
                {
                    itemToPickUp.GetComponent<RespawnableItemBehaviour>().ActivateStartTheRespondTimer();

                }

                itemToPickUp.GetComponent<MeshRenderer>().enabled = false;

                itemToPickUp.GetComponent<BoxCollider>().enabled = false;

                if(boxPickingEvent!=null)
                {
                    boxPickingEvent.GenerateOutComeFromBoxPickingEvent(itemToPickUp.gameObject);

                }

                ClosePickUpMessage();
            }
          
        }
    }

}
