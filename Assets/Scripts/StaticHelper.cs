using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticHelper
{
    public static readonly int Forward = Animator.StringToHash("Forward");
    public static readonly int Jumping = Animator.StringToHash("Jumping");
    public static readonly int Caught = Animator.StringToHash("Caught");

    public static bool freezePlayer = false;

}
