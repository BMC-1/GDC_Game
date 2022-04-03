using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class InventoryBehaviour : MonoBehaviour
{

    [SerializeField] Transform itemFramesParent;


    int numberOfEmptyInventorySpaces;
    // Start is called before the first frame update
    void Start()
    {
        numberOfEmptyInventorySpaces = itemFramesParent.childCount;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddItemToInventory(Sprite itemImage)
    {
        Transform itemFrame;

        print("works");

        for (int i = 0; i < itemFramesParent.childCount; i++)
        {
            itemFrame = itemFramesParent.GetChild(i).GetChild(0);


            if (itemFrame.GetComponent<Image>().sprite == null)
            {
                print(itemFrame.GetComponent<Image>().sprite);

                itemFrame.GetComponent<Image>().sprite = itemImage;

                itemFrame.gameObject.SetActive(true);

                numberOfEmptyInventorySpaces--;


                break;
            }
        }
    }

    public void RemoveItemFromInventory(Sprite itemImage)
    {

        print("works");
        Transform itemFrame;

        for (int i = 0; i < itemFramesParent.childCount; i++)
        {
            itemFrame = itemFramesParent.GetChild(i).GetChild(0);

            if (itemFrame.GetComponent<Image>().sprite == itemImage)
            {
                itemFrame.GetComponent<Image>().sprite = null;

                itemFrame.gameObject.SetActive(false);


                numberOfEmptyInventorySpaces++;

                break;
            }
        }
    }

    public bool AreThereEmptySlots()
    {
        if (numberOfEmptyInventorySpaces > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool DoesItemExistInInvenotry(Sprite item)
    {
        for (int i = 0; i < itemFramesParent.childCount; i++)
        {
            if(itemFramesParent.GetChild(i).GetChild(0).GetComponent<Image>().sprite==item)
            {
                return true;
            }

        }
        return false;
    }
}
