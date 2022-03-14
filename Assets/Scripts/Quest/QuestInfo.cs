using UnityEngine;

[CreateAssetMenu(fileName = "QuestNo.", menuName = "Quest/QuestInfo", order = 1)]
public class QuestInfo : ScriptableObject
{
    /// <summary>
    /// Saving the quest Information
    /// To enter this script -> Click right click on project window
    /// -> Create -> Quest -> QuestInfo -> Fill the details and pass it on any Quest script you made.
    /// </summary>
    public string questName;
    public string questDescription;

    public string rewardInfo;
    public Sprite rewardIcon;
    
    public Sprite questGivingObject;
}
