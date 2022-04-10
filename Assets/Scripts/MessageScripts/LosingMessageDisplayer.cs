using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LosingMessageDisplayer : MonoBehaviour
{
    [SerializeField] Transform losingUiPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayTheLosingUiPanel(string texToDisplay)
    {
        losingUiPanel.gameObject.SetActive(true);

        losingUiPanel.GetComponentInChildren<TextMeshProUGUI>().text = texToDisplay;
    }


}
