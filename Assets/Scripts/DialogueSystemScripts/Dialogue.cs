using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    [SerializeField] string nameOfCharacter;
    [TextArea]
    [SerializeField] string[] dialogues;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent.gameObject.tag == "Player")
        {
            print("triggered dialogue");

        }

    }

}
