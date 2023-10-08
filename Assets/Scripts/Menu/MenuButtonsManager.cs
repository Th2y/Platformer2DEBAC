using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuButtonsManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> buttonsList = new List<GameObject>();

    [Header("Animation")]
    [SerializeField] private float duration = .2f;
    [SerializeField] private float delay = .05f;
    [SerializeField] private Ease ease = Ease.OutBack;

    private void Awake()
    {
        HideAllButtons();
        ShowButtons();
    }

    private void HideAllButtons()
    {
        foreach (GameObject button in buttonsList)
        {
            button.transform.localScale = Vector3.zero;
            button.SetActive(false);
        }
    }

    private void ShowButtons()
    {
        for (int i = 0; i < buttonsList.Count; i++)
        {
            GameObject button = buttonsList[i];
            button.SetActive(true);
            button.transform.DOScale(1, duration).SetDelay(i *  delay).SetEase(ease);
        }
    }
}
