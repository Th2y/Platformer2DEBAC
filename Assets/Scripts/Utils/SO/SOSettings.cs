using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/SOSettings")]
public class SOSettings : ScriptableObject
{
    [Header("Key Codes")]
    public KeyCode leftCode = KeyCode.A;
    public KeyCode rigthCode = KeyCode.D;
    public KeyCode jumpCode = KeyCode.Space;
    public KeyCode runCode = KeyCode.LeftControl;
}
