using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class Settings : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SettingsData settingsData;

    private void Awake()
    {
        listJumpCodes = jumpDropdown.options.Select(option => option.text).ToList();
        listRunCodes = runDropdown.options.Select(option => option.text).ToList();
        listLeftCodes = leftDropdown.options.Select(option => option.text).ToList();
        listRightCodes = rightDropdown.options.Select(option => option.text).ToList();

        jumpDropdown.value = listJumpCodes.IndexOf(settingsData.jumpCode.ToString());
        runDropdown.value = listRunCodes.IndexOf(settingsData.runCode.ToString());
        leftDropdown.value = listLeftCodes.IndexOf(settingsData.leftCode.ToString());
        rightDropdown.value = listRightCodes.IndexOf(settingsData.rigthCode.ToString());
    }

    #region Key Codes
    [Header("Key Codes")]
    [SerializeField] private TMP_Dropdown jumpDropdown;
    [SerializeField] private TMP_Dropdown runDropdown;
    [SerializeField] private TMP_Dropdown leftDropdown;
    [SerializeField] private TMP_Dropdown rightDropdown;

    private List<string> listJumpCodes;
    private List<string> listRunCodes;
    private List<string> listLeftCodes;
    private List<string> listRightCodes;

    private Dictionary<string, KeyCode> keyCodesJumpDic = new Dictionary<string, KeyCode>()
    {
        { "Space", KeyCode.Space },
        { "UpArrow", KeyCode.UpArrow },
        { "W", KeyCode.W }
    };

    private Dictionary<string, KeyCode> keyCodesRunDic = new Dictionary<string, KeyCode>()
    {
        { "LeftControl", KeyCode.LeftControl },
        { "RightControl", KeyCode.RightControl },
        { "Z", KeyCode.Z }
    };

    private Dictionary<string, KeyCode> keyCodesLeftDic = new Dictionary<string, KeyCode>()
    {
        { "LeftArrow", KeyCode.LeftArrow },
        { "A", KeyCode.A }
    };

    private Dictionary<string, KeyCode> keyCodesRightDic = new Dictionary<string, KeyCode>()
    {
        { "RightArrow", KeyCode.RightArrow },
        { "D", KeyCode.D }
    };

    public void SetJumpKeyCode(TMP_Dropdown dropdown)
    {
        settingsData.jumpCode = keyCodesJumpDic[listJumpCodes[dropdown.value]];
    }

    public void SetRunKeyCode(TMP_Dropdown dropdown)
    {
        settingsData.runCode = keyCodesRunDic[listRunCodes[dropdown.value]];
    }

    public void SetRightKeyCode(TMP_Dropdown dropdown)
    {
        settingsData.rigthCode = keyCodesRightDic[listRightCodes[dropdown.value]];
    }

    public void SetLeftKeyCode(TMP_Dropdown dropdown)
    {
        settingsData.leftCode = keyCodesLeftDic[listLeftCodes[dropdown.value]];
    }
    #endregion
}
