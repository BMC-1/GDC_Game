using System;
using UnityEngine;

public class QuestFinishCollider : MonoBehaviour
{
    /// <summary>
    /// This script is made for a quest when you want to finish it.
    /// Parameters : spriteNeeded -> Sprite needed to enter || exit this quest.
    /// Parameters : questInfoReward -> questInfo you set on the Quest -> It knows the quest it must finished.
    /// Parameters : ExchangeItems boolean value [IF ON -> You take the reward from questInfo scriptable object]
    ///                                          [IF OFF -> You finishing the quest and it's taking the inventory item with no exchange]
    /// When you finish the quest this script invoking the Action onQuestFinished.
    /// </summary>
    public Sprite spriteNeeded;
    public QuestInfo questInfoReward;

    [Header("If this quest trigger is for exchanging items hit this bool to true")]
    public bool ExchangeItems;

    public static Action OnQuestFinished;
    
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
            OnQuestFinished?.Invoke();
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
        InventoryManager.instance.ExchangeReward(spriteNeeded,questInfoReward.rewardIcon);
    }
}
