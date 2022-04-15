using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CharacterToggleButtons : MonoBehaviour
{

    [SerializeField] Toggle[] toggles; 
    // Start is called before the first frame update
    void Start()
    {
        AddBehaviour();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void AddBehaviour()
    {

        toggles[0].onValueChanged.AddListener(delegate {
            FindObjectOfType<GameManager>().OnValueChangeCharacters("male");
        });

        toggles[1].onValueChanged.AddListener(delegate {
            FindObjectOfType<GameManager>().OnValueChangeCharacters("female");
        });
    }

}
