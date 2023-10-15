using System;
using TMPro;
using UnityEngine;

public class SOIntUpdate : MonoBehaviour
{
    public Action UpdateValue;

    [SerializeField] private SOInt so;
    [SerializeField] private TextMeshProUGUI valueText;

    private void Start()
    {
        OnUpdateValue();
        UpdateValue += OnUpdateValue;
    }

    private void OnUpdateValue()
    {
        valueText.text = so.Value.ToString();
    }

    private void OnDestroy()
    {
        UpdateValue -= OnUpdateValue;
    }
}
