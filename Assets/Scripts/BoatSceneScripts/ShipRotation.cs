using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipRotation : MonoBehaviour
{
    [SerializeField] float rotationSpeed;

    [SerializeField] float[] minAndMaxRotation;



    float previousRotation;

    float currentRotation = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RotateTheShip(int directionOfYRotation)
    {
        currentRotation += directionOfYRotation * Time.deltaTime * rotationSpeed;

        currentRotation = CorrectShipsRotation(currentRotation);

        this.transform.rotation = Quaternion.Euler(0, currentRotation, 0);
    }

    float CorrectShipsRotation(float currentRotation)
    {
        if(currentRotation<minAndMaxRotation[0])
        {
            currentRotation = minAndMaxRotation[0];
        }
        else if(currentRotation > minAndMaxRotation[1])
        {
            currentRotation = minAndMaxRotation[1];

        }

        return currentRotation;
    }

    public void ResetShipsRotation()
    {
        if(currentRotation!=0)
        {
            if(currentRotation<0)
            {
                RotateTheShip(1);

                if (currentRotation>0)
                {
                    currentRotation = 0;

                    this.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
            }
            else
            {
                RotateTheShip(-1);

                if (currentRotation < 0)
                {
                    currentRotation = 0;

                    this.transform.rotation = Quaternion.Euler(0, 0, 0);
                }
            }
        }
    }

    public float CurrentRotation()
    {
        return currentRotation;
    }
}
