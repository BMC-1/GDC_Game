using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    private void Awake()
    {
        instance = this;
    }

    public List<GameObject> inventoryItems = new List<GameObject>();

    public Sprite Check_If_Sprite_Exist_In_Inventory(Sprite item)
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (item == inventoryItems[i].GetComponent<Image>().sprite)
            {
                Debug.Log("Slot " + i + " item exist");
                return item;
            }
        }
        return null;
    }

    public void ClearItem(Sprite item)
    {
        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (item == inventoryItems[i].GetComponent<Image>().sprite)
            {
                Debug.Log("Slot "+i+" item exist");
                inventoryItems[i].GetComponent<Image>().color = new Color(1,1,1,0);
                inventoryItems[i].GetComponent<Image>().sprite = null;
                return;
            }
        }
    }
    public Button Check_If_Button_Exist_In_Inventory(Sprite item)
    {

        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (item == inventoryItems[i].GetComponent<Image>().sprite)
            {
                Debug.Log("Slot " +i + " button return");
                return inventoryItems[i].GetComponent<Button>();
            }
        }
        return null;
    }
    
    public Sprite ExchangeReward(Sprite item,Sprite rewardSprite)
    {

        for (int i = 0; i < inventoryItems.Count; i++)
        {
            if (item == inventoryItems[i].GetComponent<Image>().sprite)
            {
                Debug.Log("Item "+i+" exchange icon");
                return inventoryItems[i].GetComponent<Image>().sprite = rewardSprite;
            }
        }
        return null;
    }
}

