using System.Collections;
using TMPro;
using UnityEngine;

public class QuestReminderCollision : MonoBehaviour
{
    public GameObject questPanel;
    
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
            LeanTween.scale(questPanel, Vector3.one * 2, 1f).setEasePunch();
            questPanel.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = questInfo;
        }
        questPanel.SetActive(value);
    }

    private IEnumerator QuestEnumerator(string questInfo)
    {
        yield return new WaitForSeconds(0.1f);
        OpenQuestInfo(questInfo, true);
        yield return new WaitForSeconds(5f);
        OpenQuestInfo(questInfo, false);
    }
}
