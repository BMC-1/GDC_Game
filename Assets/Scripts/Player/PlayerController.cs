using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
     public CharacterController controller;
     public Transform cam;
     public Animator animator;
     
     [Header("Player Speed")]
     [SerializeField]private float speed = 2.2f;

     [Header("Gravity Jumping")]
     public float gravity = -9.81f;
     public float jumpHeight = 2;
     public float lowJumpMultiplier = 4.5f;

     [Header("Ground Collisions")]
     public Transform playerCheck;
     public LayerMask groundMask;
     public float groundDistance = 0.05f;
     public bool isGrounded;
     public bool isRunning;

     [Header("Geneder Picker")] 
     [Tooltip("If male is UnTick , then female is selected")]
     public bool Male;

     private float jumpingTime;
     private Vector3 velocity;
     private float turnSmoothVelocity;
     private float turnSmoothTime = 0.05f;
     private bool freezeMove = false;
     private bool jumpOnce = false;


     public void Start()
     {
         StaticHelper.freezePlayer = false;
     }

     void Update()
     {
         if (!StaticHelper.freezePlayer)
         {
             //jump
             isGrounded = Physics.CheckSphere(playerCheck.position, groundDistance, groundMask);

             if (isGrounded && velocity.y < 0)
             {
                 velocity.y = -lowJumpMultiplier;
             }

             if (Input.GetButtonDown("Jump") && isGrounded && !isRunning && !jumpOnce)
             {
                 jumpOnce = true;
                 freezeMove = true;
                 StartCoroutine(JumpingAnimation());
             }

             if (Input.GetButton("Run") && isGrounded)
             {
                 speed = 3.8f;
                 isRunning = true;
                 animator.SetBool(StaticHelper.Running,true);
                 animator.SetBool(StaticHelper.Jumping,false);
             }
             else
             {
                 isRunning = false;
                 animator.SetBool(StaticHelper.Running,false);
                 speed = 2.2f;
             }
             //gravity
             velocity.y += gravity * Time.deltaTime;
             controller.Move(velocity * Time.deltaTime);
             //walk
             float horizontal = Input.GetAxisRaw("Horizontal");
             float vertical = Input.GetAxisRaw("Vertical");
             Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
     
             if(direction.magnitude >= 0.01f)
             {
                 animator.SetBool(StaticHelper.Forward,true);
                 float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                 float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                 transform.rotation = Quaternion.Euler(0f, angle, 0f);
                 if (!freezeMove)
                 {
                     Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
                     controller.Move(moveDir.normalized * speed * Time.deltaTime);
                 }
                
             }
             else
             {
                 animator.SetBool(StaticHelper.Forward,false);
             }
         }
     }

     IEnumerator JumpingAnimation()
     {
         animator.SetBool(StaticHelper.Jumping,true);
         if (Male)
         {
             yield return new WaitForSeconds(1f);
         }
         else
         {
             yield return new WaitForSeconds(0.5f);
         }
         SoundManager.instance.JumpEffect();
         velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
         yield return new WaitForSeconds(0.9f);
         animator.SetBool(StaticHelper.Jumping,false);
         jumpOnce = false;
         freezeMove = false;
     }
    
}
