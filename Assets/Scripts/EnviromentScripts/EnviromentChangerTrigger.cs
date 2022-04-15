using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentChangerTrigger : MonoBehaviour
{
    [SerializeField] EnviromentManager enviromentManager;

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
            enviromentManager.SpawnObjects();

            enviromentManager.DestroyObjects();

            Invoke("DestoryObject",1f);
        }
    }

    public void ActivateTrigger()
    {

        print("works");

        this.GetComponent<BoxCollider>().enabled = true;
    }

    void DestoryObject()
    {
        Destroy(this.gameObject);

    }

}
