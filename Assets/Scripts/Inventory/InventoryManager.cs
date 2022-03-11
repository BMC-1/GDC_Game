using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public static Action OnFinishMissionTrigger;
    private void Awake()
    {
        instance = this;
    }
    public GameObject item1;
    public GameObject item2;
    public GameObject item3;

    public Sprite Check_If_Exist_In_Inventory(Sprite item)
    {
        if (item == item1.GetComponent<Image>().sprite)
        {
            //item1.GetComponent<Button>().onClick.AddListener();
            //add listener
            Debug.Log("Slot1 item exist");
            return item;
        }
        if (item == item2.GetComponent<Image>().sprite)
        {
            Debug.Log("Slot2 item exist");
            return item;
        }

        if (item == item3.GetComponent<Image>().sprite)
        {
            Debug.Log("Slot3 item exist");
            return item;
        }
        return null;
    }

    public void ClearItem(Sprite item)
    {
        if (item == item1.GetComponent<Image>().sprite)
        {
            Debug.Log("Slot1 item exist");
            item1.GetComponent<Image>().color = new Color(1,1,1,0);
            item1.GetComponent<Image>().sprite = null;
            return;
        }
        if (item == item2.GetComponent<Image>().sprite)
        {
            Debug.Log("Slot2 item exist");
            item2.GetComponent<Image>().color = new Color(1,1,1,0);
            item2.GetComponent<Image>().sprite = null;
            return;
        }

        if (item == item3.GetComponent<Image>().sprite)
        {
            Debug.Log("Slot3 item exist");
            item3.GetComponent<Image>().color = new Color(1,1,1,0);
            item3.GetComponent<Image>().sprite = null;
            return;
        }
    }
    public Button Check_If_Button_Exist_In_Inventory(Sprite item)
    {
        if (item == item1.GetComponent<Image>().sprite)
        {
            Debug.Log("Slot1 button return");
            return item1.GetComponent<Button>();
        }
        if (item == item2.GetComponent<Image>().sprite)
        {
            Debug.Log("Slot2 button return");
            return item2.GetComponent<Button>();
        }

        if (item == item3.GetComponent<Image>().sprite)
        {
            Debug.Log("Slot3 button return");
            return item3.GetComponent<Button>();
        }
        return null;
    }
    public Sprite ExchangeReward(Sprite item,Sprite rewardSprite)
    {
        if (item == item1.GetComponent<Image>().sprite)
        {
            Debug.Log("Item1 exchange icon");
            return item1.GetComponent<Image>().sprite = rewardSprite;
        }
        if (item == item2.GetComponent<Image>().sprite)
        {
            Debug.Log("Item2 exchange icon");
            return item2.GetComponent<Image>().sprite = rewardSprite;
        }
        if (item == item3.GetComponent<Image>().sprite)
        {
            Debug.Log("Item3 exchange icon");
            return item3.GetComponent<Image>().sprite = rewardSprite;;
        }
        return null;
    }
    
    public void FillItem(Sprite rewardSprite,[CanBeNull] GameObject _item1,[CanBeNull] GameObject _item2, [CanBeNull] GameObject _item3)
    {
        _item1.GetComponent<Image>().sprite = rewardSprite;
        _item2.GetComponent<Image>().sprite = rewardSprite;
        _item3.GetComponent<Image>().sprite = rewardSprite;
    }

}

