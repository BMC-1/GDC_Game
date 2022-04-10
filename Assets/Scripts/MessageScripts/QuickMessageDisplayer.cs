using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class QuickMessageDisplayer : MonoBehaviour
{

    [SerializeField] Transform quickMessageUi;

    [SerializeField] float timeForMessageToDisappear;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateTheDisplayTheQuickMessage(string messageToDisplay)
    {
        StartCoroutine(DisplayTheQuickMessage(messageToDisplay));
    }

    IEnumerator DisplayTheQuickMessage(string messageToDisplay)
    {

        quickMessageUi.gameObject.SetActive(true);

        quickMessageUi.GetComponentInChildren<TextMeshProUGUI>().text = messageToDisplay;

        yield return new WaitForSeconds(timeForMessageToDisappear);

        quickMessageUi.gameObject.SetActive(false);

    }
}
