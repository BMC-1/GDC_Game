using System.Collections;
using TMPro;
using UnityEngine;

public class QuestReminderCollision : MonoBehaviour
{
    public GameObject questPanel;
    
    [Header("Enter the description of the quest")]
    public string questText;
    
    //MISSING : LEAN TWEEN ANIM - On Open and Close this gameobject
    public void OnTriggerEnter(Collider other)
    {
        StartCoroutine(QuestEnumerator(questText));
    }

    public void QuestInfo(string questInfo)
    {
        questPanel.transform.GetChild(0).GetChild(1).GetComponent<TextMeshProUGUI>().text = questInfo;
    }

    IEnumerator QuestEnumerator(string questInfo)
    {
        yield return new WaitForSeconds(0.1f);
        questPanel.gameObject.SetActive(true);
        QuestInfo(questInfo);
        yield return new WaitForSeconds(5f);
        questPanel.gameObject.SetActive(false);
    }
}
