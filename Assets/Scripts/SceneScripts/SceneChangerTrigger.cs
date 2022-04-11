using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneChangerTrigger : MonoBehaviour
{
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
            FindObjectOfType<SceneChanger>().LoadNextScene();
        }
    }
}
