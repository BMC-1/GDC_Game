using UnityEngine;

[CreateAssetMenu(fileName = "QuestNo.", menuName = "Quest/QuestInfo", order = 1)]
public class QuestInfo : ScriptableObject
{
    public string questName;
    public string questDescription;

    public string rewardInfo;
    public Sprite rewardIcon;
    
    public Sprite questGivingObject;
}
