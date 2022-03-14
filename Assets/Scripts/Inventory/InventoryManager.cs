using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    private void Awake()
    {
        instance = this;
    }

    /// <summary>
    /// Inventory Items -> If you open this list from the inspector
    /// You must see the 3 items on the inventoryPanel you have- Looks like [item1/item2/item3]
    /// </summary>
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

