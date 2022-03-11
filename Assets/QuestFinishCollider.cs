using System;
using System.Collections;
using UnityEngine;

public class QuestFinishCollider : MonoBehaviour
{
    public Sprite spriteNeeded;
    public NPC_Quest questReward;

    [Header("If this quest trigger is for exchanging items hit this bool to true")]
    public bool ExchangeItems;

    public void OnTriggerEnter(Collider other)
    {
        if (InventoryManager.instance.Check_If_Button_Exist_In_Inventory(spriteNeeded))
        {
            if (ExchangeItems)
            {
                InventoryManager.instance.Check_If_Button_Exist_In_Inventory(spriteNeeded).onClick.AddListener(ChangeQuestItemToRewardItem);
            }
            else
            {
                InventoryManager.instance.ClearItem(spriteNeeded);
            }
            Debug.Log("Item exist");
        }
        else
        {
            Debug.Log("Item not exist in your inventory");
        }
    }
    
    //NOT DYNAMICALLY APPROACH BUT GIVES A REWARD
    private void ChangeQuestItemToRewardItem()
    {
        InventoryManager.instance.ExchangeReward(spriteNeeded,questReward.rewardIcon);
    }
}
