using Ebac.Core.Singletons;
using TMPro;
using UnityEngine;

public class UIGameManager : Singleton<UIGameManager>
{
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private TextMeshProUGUI lifeText;

    public void UpdateCoins(string text)
    {
        coinsText.text = text;
    }

    public void UpdateLife(string text)
    {
        lifeText.text = text;
    }
}
