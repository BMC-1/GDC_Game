using UnityEngine;

public static class StaticHelper
{
    /// <summary>
    /// This is a static class, It not using any game object to instantiate this code.
    /// You grab the static variables or functions from here.
    /// </summary>
    public static readonly int Forward = Animator.StringToHash("Forward");
    public static readonly int Running = Animator.StringToHash("Running");
    public static readonly int Jumping = Animator.StringToHash("Jumping");
    public static readonly int Caught = Animator.StringToHash("Caught");

    public static bool PoliceOnCall = true;
    public static bool CaughtBool = false;
    public static bool FreezePlayer = false;

}
