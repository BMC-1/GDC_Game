using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionSetterTrigger : MonoBehaviour
{
    [TextArea]
    [SerializeField] string instructionMessage;

    bool wasTheInstructionUpdated;
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
            Invoke("UpdateTheMessageBox", 0.5f);
        }
    }

    void UpdateTheMessageBox()
    {
        if(wasTheInstructionUpdated==false)
        {
            FindObjectOfType<InstructionMessageDisplayer>().SetIntructionMessage(instructionMessage);

            print(instructionMessage);

            wasTheInstructionUpdated = true;
        }
       
    }
}
