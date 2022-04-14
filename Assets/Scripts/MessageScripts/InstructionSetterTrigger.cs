using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionSetterTrigger : MonoBehaviour
{
    [TextArea]
    [SerializeField] string instructionMessage;


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
        if(other.transform.parent.tag=="Player")
        {
            Invoke("UpdateTheMessageBox", 1f);
        }
    }

    void UpdateTheMessageBox()
    {
        FindObjectOfType<InstructionMessageDisplayer>().SetIntructionMessage(instructionMessage);

    }
}
