using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
     public CharacterController controller;
     public Transform cam;
     public Animator animator;
     
     [Header("Player Speed")]
     private float speed = 2.2f;

     [Header("Gravity Jumping")]
     public float gravity = -9.81f;
     public float jumpHeight = 2;
     public float lowJumpMultiplier = 4.5f;

     [Header("Ground Collisions")]
     public Transform playerCheck;
     public LayerMask groundMask;
     public float groundDistance = 0.05f;
     public bool isGrounded;
     public bool groundedBool;

     private float jumpingTime;
     private Vector3 velocity;
     private float turnSmoothVelocity;
     private float turnSmoothTime = 0.1f;
     private static readonly int Forward = Animator.StringToHash("Forward");
     private static readonly int Jumping = Animator.StringToHash("Jumping");

     void Update()
     {
         //jump
         isGrounded = Physics.CheckSphere(playerCheck.position, groundDistance, groundMask);

         if (isGrounded && velocity.y < 0)
         {
             velocity.y = -lowJumpMultiplier;
         }

         if (Input.GetButtonDown("Jump") && isGrounded && !groundedBool)
         {
             StartCoroutine(JumpingAnimationTime());
         }
         //gravity
         velocity.y += gravity * Time.deltaTime;
         controller.Move(velocity * Time.deltaTime);
         //walk
         float horizontal = Input.GetAxisRaw("Horizontal");
         float vertical = Input.GetAxisRaw("Vertical");
         Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
 
         if(direction.magnitude >= 0.1f)
         {
             animator.SetBool(Forward,true);
             float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
             float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
             transform.rotation = Quaternion.Euler(0f, angle, 0f);
 
             Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
             controller.Move(moveDir.normalized * speed * Time.deltaTime);
         }
         else
         {
             animator.SetBool(Forward,false);
         }
     }

     IEnumerator JumpingAnimationTime()
     {
         animator.SetBool(Jumping,true);
         groundedBool = true;
         speed = 0.1f;
         yield return new WaitForSeconds(0.5f);
         speed = 1f;
         SoundManager.instance.JumpEffect();
         velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
         yield return new WaitForSeconds(1.3f);
         speed = 2.2f;
         animator.SetBool(Jumping,false);
         groundedBool = false;
     }
}
