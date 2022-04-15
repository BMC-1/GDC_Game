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
    
    void AddBehaviour()
    {
        toggles[0].onValueChanged.AddListener(delegate
        {
            GameManager.instance.characterGender = "male";
        });

        toggles[1].onValueChanged.AddListener(delegate {
            GameManager.instance.characterGender = "female";
        });
    }

}
