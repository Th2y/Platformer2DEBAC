using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/SOValuesMovement")]
public class SoValuesMovement : ScriptableObject
{
    public Vector2 friction = new Vector2(.1f, 0);
    public float speedX;
    public float speedRun;
    public float forceJump;
}
