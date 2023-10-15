using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/SOPlayerValues")]
public class SOPlayerValues : ScriptableObject
{
    [Header("Moviment")]
    public Vector2 friction = new Vector2(.1f, 0);
    public float speedX;
    public float speedRun;
    public float forceJump;

    [Header("Animation")]
    public float playerSwipDuration = .1f;
}
