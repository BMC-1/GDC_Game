using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatJumpingMotion : MonoBehaviour
{

    [SerializeField] float jumpingForce;

    public bool isTheBoatInTheAir { get; set; }

    Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = FindObjectOfType<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MakeTheBoatJump();


    }

    void MakeTheBoatJump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isTheBoatInTheAir==false)
        {
            rigidbody.AddForce(Vector3.up*jumpingForce);

            ActivateOrNotGravity(true);
        }
    }

    public void ActivateOrNotGravity(bool shouldItBeActive)
    {

        rigidbody.useGravity = shouldItBeActive;

        isTheBoatInTheAir = shouldItBeActive;

        if(shouldItBeActive==true)
        {
            rigidbody.constraints = RigidbodyConstraints.None;

        }
        else
        {
            rigidbody.constraints = RigidbodyConstraints.FreezeAll;

        }
    }




}
