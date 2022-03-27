using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationPlayer : MonoBehaviour
{
    [SerializeField] Animator animator;
    private static readonly int IsThePlayerMoving = Animator.StringToHash("IsThePlayerMoving");

    public void SetTheMovingAnimation()
    {
        animator.SetBool(IsThePlayerMoving, true);
    }
    
    public void SetTheIdleAnimation()
    {
        animator.SetBool(IsThePlayerMoving, false);
    }
}
