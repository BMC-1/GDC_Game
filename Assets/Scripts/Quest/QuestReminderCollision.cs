using System.Collections;
using TMPro;
using UnityEngine;

public class QuestReminderCollision : MonoBehaviour
{
    /// <summary>
    /// This script pops up a notification of a quest.
    /// Parameters : questNotification -> Ready-made canvas panel for the questNotification, drag it from your scene,
    /// if for any reason you don't have this panel on your scene, drag it from prefabs folder to your scene, Unpack it completely
    /// and drag it to the questNotification object.
    /// Parameters : questText -> Pass the text you like when the popup notification comes into the screen.
    /// </summary>
    public GameObject questNotification;
    
    [Header("Enter the description of the quest")]
    public string questText;
    
    public void OnTriggerEnter(Collider other)
    {
        StartCoroutine(QuestEnumerator(questText));
    }

    private void OpenQuestInfo(string questInfo,bool value)
    {
        if (value)
        {
            LeanTween.scale(questNotification, Vector3.one * 2, 1f).setEasePunch();
            questNotification.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = questInfo;
        }
        questNotification.SetActive(value);
    }

    private IEnumerator QuestEnumerator(string questInfo)
    {
        yield return new WaitForSeconds(0.1f);
        OpenQuestInfo(questInfo, true);
        yield return new WaitForSeconds(5f);
        OpenQuestInfo(questInfo, false);
    }
}
