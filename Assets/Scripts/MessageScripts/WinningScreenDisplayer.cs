using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningScreenDisplayer : MonoBehaviour
{
    [SerializeField] Transform winningScreenUi;

    public bool isTheWinningScreenShown { get; set; }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayWinningScreen()
    {
        isTheWinningScreenShown = true;

        winningScreenUi.gameObject.SetActive(true);
    }
}
