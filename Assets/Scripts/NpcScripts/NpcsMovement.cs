using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcsMovement : MonoBehaviour
{
    [SerializeField] Transform[] positionsToMoveTo;

    [SerializeField] float distanceFromPointToMoveToOtherPoint;

    [SerializeField] float speedOfNpc;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("MoveTheNpc");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void RotateOfNpcToPointOfMovement(Transform pointToLookAt)
    {
        this.transform.LookAt(pointToLookAt);
    }

    IEnumerator MoveTheNpc()
    {
        while(true)
        {

            for (int i = 0; i < positionsToMoveTo.Length; i++)
            {
                RotateOfNpcToPointOfMovement(positionsToMoveTo[i]);


                while (Vector3.Distance(this.transform.position,
              positionsToMoveTo[i].position) < distanceFromPointToMoveToOtherPoint)
                {

                    this.transform.position += transform.forward * speedOfNpc*Time.deltaTime;

                    yield return new WaitForEndOfFrame();

                }
            }



            yield return new WaitForEndOfFrame();
        }
       
    }

    
}
