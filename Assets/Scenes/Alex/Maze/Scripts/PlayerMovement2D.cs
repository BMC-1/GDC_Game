using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    [SerializeField] float playerSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveThePlayer();
    }

    void MoveThePlayer()
    {
        if(Input.GetKey(KeyCode.W))
        {
            this.transform.position += (Vector3)Vector2.up * Time.deltaTime * playerSpeed;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            this.transform.position -= (Vector3)Vector2.up * Time.deltaTime * playerSpeed;

        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position -= (Vector3)Vector2.right * Time.deltaTime * playerSpeed;

        }
        else if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += (Vector3)Vector2.right * Time.deltaTime * playerSpeed;

        }
    }

    public void SetPlayerSpeedToZero()
    {
        playerSpeed = 0;
    }
}
