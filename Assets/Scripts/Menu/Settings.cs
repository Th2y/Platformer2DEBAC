using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [Header("Key Codes")]
    [SerializeField] private TMP_Dropdown jumpDropdown;
    [SerializeField] private TMP_Dropdown runDropdown;
    [SerializeField] private TMP_Dropdown leftDropdown;
    [SerializeField] private TMP_Dropdown rightDropdown;

    [Header("References")]
    [SerializeField] private SettingsData settingsData;

    private List<string> listJumpCodes;
    private List<string> listRunCodes;
    private List<string> listLeftCodes;
    private List<string> listRightCodes;

    #region Dictionaries Key Codes

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

    private Dictionary<KeyCode, string> keysJumpDic = new Dictionary<KeyCode, string>()
    {
        { KeyCode.Space, "Space" },
        { KeyCode.UpArrow, "UpArrow" },
        { KeyCode.W, "W" }
    };

    private Dictionary<KeyCode, string> keysRunDic = new Dictionary<KeyCode, string>()
    {
        { KeyCode.LeftControl, "LeftControl" },
        { KeyCode.RightControl, "RightControl" },
        { KeyCode.Z, "Z" }
    };

    private Dictionary<KeyCode, string> keysLeftDic = new Dictionary<KeyCode, string>()
    {
        { KeyCode.LeftArrow, "LeftArrow" },
        { KeyCode.A, "A" }
    };

    private Dictionary<KeyCode, string> keysRightDic = new Dictionary<KeyCode, string>()
    {
        { KeyCode.RightArrow, "RightArrow" },
        { KeyCode.D, "D" }
    };
    #endregion

    private void Awake()
    {
        listJumpCodes = jumpDropdown.options.Select(option => option.text).ToList();
        listRunCodes = runDropdown.options.Select(option => option.text).ToList();
        listLeftCodes = leftDropdown.options.Select(option => option.text).ToList();
        listRightCodes = rightDropdown.options.Select(option => option.text).ToList();

        string jump = keysJumpDic[settingsData.jumpCode];
        string run = keysRunDic[settingsData.runCode];
        string left = keysLeftDic[settingsData.leftCode];
        string rigth = keysRightDic[settingsData.rigthCode];

        jumpDropdown.value = listJumpCodes.IndexOf(jump);
        runDropdown.value = listRunCodes.IndexOf(run);
        leftDropdown.value = listLeftCodes.IndexOf(left);
        rightDropdown.value = listRightCodes.IndexOf(rigth);
    }

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
        settingsData.jumpCode = keyCodesRightDic[listRightCodes[dropdown.value]];
    }

    public void SetLeftKeyCode(TMP_Dropdown dropdown)
    {
        settingsData.jumpCode = keyCodesLeftDic[listLeftCodes[dropdown.value]];
    }
}
