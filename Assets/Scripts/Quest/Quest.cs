using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Quest : MonoBehaviour
{
    [Header("Create a new scriptableObject with the quest information")]
    public NPC_Quest questInfo;
    [Header("Enter Canvas quest dialogue gameobject")]
    public GameObject questDialogue;

    private bool questOpened = false;
    private bool questItemReceived = false;

    //Manage the gameobject for reward is not used here.
    public void Start()
    {
        ControllingQuestDialogue(questInfo.questName, questInfo.questDescription, questInfo.rewardInfo,
            questInfo.rewardIcon);
    }

    private void ControllingQuestDialogue(string questName,string questDescription,string rewardInfo,[CanBeNull] Sprite rewardIcon)
    {
        questDialogue.transform.GetChild(0).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = questName;
        questDialogue.transform.GetChild(0).GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = questDescription;
        questDialogue.transform.GetChild(0).GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = rewardInfo;
        questDialogue.transform.GetChild(0).GetChild(2).GetChild(1).GetComponent<Image>().sprite = rewardIcon;
        questDialogue.transform.GetChild(0).GetChild(3).GetComponent<Button>().onClick.RemoveAllListeners();
        questDialogue.transform.GetChild(0).GetChild(3).GetComponent<Button>().onClick.AddListener(CloseQuestPanel);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!questOpened)
        {
            questDialogue.SetActive(true);
            LeanTween.scale(questDialogue, Vector3.one * 2, 1f).setEasePunch();
            questOpened = true;
        }

        if (questInfo.questGivingObject != null && !questItemReceived)
        {
            if(InventoryManager.instance.item1.GetComponent<Image>().sprite == null)
            {
                InventoryManager.instance.item1.GetComponent<Image>().color = new Color(1, 1, 1, 0.8f);
                InventoryManager.instance.item1.GetComponent<Image>().sprite = questInfo.questGivingObject;
                questItemReceived = true;
                return;
            }
            if(InventoryManager.instance.item2.GetComponent<Image>().sprite == null)
            {
                InventoryManager.instance.item2.GetComponent<Image>().color = new Color(1, 1, 1, 0.8f);
                InventoryManager.instance.item2.GetComponent<Image>().sprite = questInfo.questGivingObject;
                questItemReceived = true;
                return;
            }
            if(InventoryManager.instance.item3.GetComponent<Image>().sprite == null)
            {
                InventoryManager.instance.item3.GetComponent<Image>().color = new Color(1, 1, 1, 0.8f);
                InventoryManager.instance.item3.GetComponent<Image>().sprite = questInfo.questGivingObject;
                questItemReceived = true;
                return;
            }
        }
    }

    private void CloseQuestPanel()
    {
        questOpened = false;
    }
}
