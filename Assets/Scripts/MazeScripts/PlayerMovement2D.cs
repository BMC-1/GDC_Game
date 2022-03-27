using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    [SerializeField] float playerSpeed;

    [SerializeField] PlayerAnimationPlayer playerAnimationPlayer;

    [SerializeField] int[] roationY;
    
    void FixedUpdate()
    {
        MoveThePlayer();
    }

    void MoveThePlayer()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) 
            || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.W))
            {
                this.transform.position += (Vector3)Vector2.up * Time.deltaTime * playerSpeed;
                RotateThePlayerZ(90);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                this.transform.position += (Vector3)Vector2.down * Time.deltaTime * playerSpeed;
                RotateThePlayerZ(-90);
            }
            if (Input.GetKey(KeyCode.A))
            {
                this.transform.position += (Vector3)Vector2.left * Time.deltaTime * playerSpeed;

                RotateThePlayerY(roationY[0]);

            }
            else if (Input.GetKey(KeyCode.D))
            {
                this.transform.position += (Vector3)Vector2.right * Time.deltaTime * playerSpeed;

                RotateThePlayerY(roationY[1]);
            }

            playerAnimationPlayer.SetTheMovingAnimation();

        }
        else
        {
            playerAnimationPlayer.SetTheIdleAnimation();
        }
      
    }

    public void SetPlayerSpeedToZero()
    {
        playerSpeed = 0;
    }

    void RotateThePlayerY(int yRotation)
    {
        this.transform.rotation = Quaternion.Euler(0, yRotation, 0);
    }
    void RotateThePlayerZ(int zRotation)
    {
        this.transform.rotation = Quaternion.Euler(0, 0,zRotation);
    }
}
