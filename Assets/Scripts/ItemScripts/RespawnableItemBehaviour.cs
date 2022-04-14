using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnableItemBehaviour : MonoBehaviour
{
    [SerializeField] float respawnTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateStartTheRespondTimer()
    {
        StartCoroutine("StartRespondTimer");
    }

    IEnumerator StartRespondTimer()
    {
        float currentTimer = 0;

        while(currentTimer<respawnTime)
        {
            currentTimer++;

            yield return new WaitForSeconds(1);
        }

        RespawnItem();
    }

    void RespawnItem()
    {
        this.GetComponent<MeshRenderer>().enabled = true;

        this.GetComponent<BoxCollider>().enabled = true;
    }


}
