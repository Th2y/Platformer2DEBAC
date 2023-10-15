using Ebac.Core.Singletons;
using TMPro;
using UnityEngine;

public class UIGameManager : Singleton<UIGameManager>
{
    [SerializeField] private TextMeshProUGUI coinsText;
    [SerializeField] private TextMeshProUGUI lifeText;
    [SerializeField] private TextMeshProUGUI projectilesText;

    public void UpdateCoins(string text)
    {
        coinsText.text = text;
    }

    public void UpdateLife(string text)
    {
        lifeText.text = text;
    }

    public void UpdateProjectiles(string text)
    {
        projectilesText.text = text;
    }
}
