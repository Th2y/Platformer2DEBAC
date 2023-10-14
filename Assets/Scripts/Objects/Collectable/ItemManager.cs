using Ebac.Core.Singletons;
using TMPro;
using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{
    [SerializeField] private TextMeshProUGUI coinsText;

    private int coins;

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        coins = 0;
        coinsText.text = coins.ToString();
    }

    public void AddCoins(int amount = 1)
    {
        coins += amount;
        coinsText.text = coins.ToString();
    }
}
