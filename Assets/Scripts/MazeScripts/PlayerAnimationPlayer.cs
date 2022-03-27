using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationPlayer : MonoBehaviour
{
    [SerializeField] Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTheMovingAnimation()
    {
        animator.SetBool("IsThePlayerMoving", true);
    }


    public void SetTheIdleAnimation()
    {

        animator.SetBool("IsThePlayerMoving", false);

    }
}
