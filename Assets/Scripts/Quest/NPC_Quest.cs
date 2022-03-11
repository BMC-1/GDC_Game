using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "QuestNo.", menuName = "Quest/QuestInfo", order = 1)]
public class NPC_Quest : ScriptableObject
{
    public string questName;
    public string questDescription;

    public string rewardInfo;
    public Sprite rewardIcon;
    
    public Sprite questGivingObject;
}
