using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    [SerializeField] float boatSpeed;

    [SerializeField] float[] minAndMaxXConstrain;

    bool canTheboatMove=true;

    ShipRotation shipRotation;
    BoatJumpingMotion boatJumpingMotion;
    // Start is called before the first frame update
    void Start()
    {
        shipRotation = FindObjectOfType<ShipRotation>();

        boatJumpingMotion = FindObjectOfType<BoatJumpingMotion>();
    }

    // Update is called once per frame
    void Update()
    {
        if(boatJumpingMotion.isTheBoatInTheAir==false && canTheboatMove==true)
        {
            MoveThePlayer();

        }
    }
    private void MoveThePlayer()
    {
        Vector3 futurePos;

        if (Input.GetKey(KeyCode.A))
        {
            futurePos=this.transform.position- transform.right * boatSpeed * Time.deltaTime;

            if (CanTheBoatMoveToPos(futurePos))
            {
                shipRotation.RotateTheShip(-1);

                if(shipRotation.CurrentRotation()<0)
                {
                    this.transform.position -= Vector3.right * boatSpeed * Time.deltaTime;

                }

            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            futurePos =this.transform.position+ transform.right * boatSpeed * Time.deltaTime;

            if(CanTheBoatMoveToPos(futurePos))
            {
                shipRotation.RotateTheShip(1);

                if (shipRotation.CurrentRotation() > 0)
                {
                    this.transform.position += Vector3.right * boatSpeed * Time.deltaTime;

                }
            }

        }
        else
        {
            shipRotation.ResetShipsRotation();
        }
    }

    bool CanTheBoatMoveToPos(Vector3 currentPos)
    {
        if(currentPos.x>minAndMaxXConstrain[1] || currentPos.x < minAndMaxXConstrain[0])
        {
            return false;
        }
    

        return true;
    }

    public void DisableShipSideWaysMovement()
    {
        canTheboatMove = false;
    }
}
