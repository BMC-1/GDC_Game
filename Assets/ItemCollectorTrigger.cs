using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollectorTrigger : MonoBehaviour
{
    ItemCollector itemCollector;
    // Start is called before the first frame update
    void Start()
    {
        itemCollector = FindObjectOfType<ItemCollector>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.parent.tag =="Player")
        {
            itemCollector.CollectItems();

        }
        
    }
}
