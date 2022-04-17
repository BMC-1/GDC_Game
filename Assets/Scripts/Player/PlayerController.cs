using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
     private CharacterController controller;
     private Animator animator;
     private Transform cam;

    [SerializeField] WalikingSoundEffectPlayer walikingSoundEffectPlayer;

    [SerializeField] GroundDetector groundDetector;
     
     [Header("Player Speed")]
      float speed = 2.2f;

    [SerializeField] float walkingSpeed;

    [SerializeField] float runningSpeed;

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

     public bool canThePlayerMove { get; set ; }

     public void Start()
     {
        canThePlayerMove = true;

         controller = GetComponent<CharacterController>();
         animator = GetComponent<Animator>();
         if (Camera.main is { }) cam = Camera.main.transform;
         StaticHelper.FreezePlayer = false;
         StaticHelper.CaughtBool = false;
     }

     void Update()
     {
         if (!StaticHelper.FreezePlayer && canThePlayerMove==true)
         {
             
             //Walk functionality
         


          

            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

            //Check if character Collider is OnGround
            isGrounded = Physics.CheckSphere(playerCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y < 0)
            {
                velocity.y = -lowJumpMultiplier;
            }

            //Jump functionality
            if (Input.GetButtonDown("Jump") && isGrounded && !isRunning && !jumpOnce)
            {
                jumpOnce = true;
                freezeMove = true;
                StartCoroutine(JumpingAnimation());
            }

            //Run functionality
            if (Input.GetButton("Run") && isGrounded && direction.magnitude >= 0.01f)
            {

                walikingSoundEffectPlayer.PlayWalkingSoundEffect(groundDetector.groundTag);

                speed = runningSpeed;
                isRunning = true;
                animator.SetBool(StaticHelper.Running, true);
                animator.SetBool(StaticHelper.Jumping, false);
            }
            else if(horizontal!=0 || vertical!=0)
            {
                walikingSoundEffectPlayer.PlayWalkingSoundEffect(groundDetector.groundTag);


                isRunning = false;
                animator.SetBool(StaticHelper.Running, false);
                speed = walkingSpeed;
            }

            //Gravity functionality
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);


            //Camera turning and moving character functionality
            if (direction.magnitude >= 0.01f)
            {
                animator.SetBool(StaticHelper.Forward, true);
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
                //Idle functionality -> Go to idle animation
                animator.SetBool(StaticHelper.Forward, false);
            }
            
           
            //Low jumpMultiplier functionality, smooths out jump

        }

        else
        {
            print("works");
            ////Idle functionality -> Go to idle animation
            animator.SetBool(StaticHelper.Forward, false);

            animator.SetBool(StaticHelper.Running, false);
        }
    }

     //Coroutine between male and female jumping functionality
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
         //SoundManager.instance.JumpEffect();
         velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
         yield return new WaitForSeconds(0.9f);
         animator.SetBool(StaticHelper.Jumping,false);
         jumpOnce = false;
         freezeMove = false;
     }
    
   
    
}
