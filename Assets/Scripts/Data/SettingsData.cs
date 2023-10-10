using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Settings Data")]
public class SettingsData : ScriptableObject
{
    [Header("Key Codes")]
    public KeyCode leftCode = KeyCode.A;
    public KeyCode rigthCode = KeyCode.D;
    public KeyCode jumpCode = KeyCode.Space;
    public KeyCode runCode = KeyCode.LeftControl;
}
