using Thayane.Core.Singletons;
using UnityEngine;

public class ItemManager : Singleton<ItemManager>
{
    [SerializeField] private SOInt Coins;

    private HealthBase _playerHealth;

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        Coins.Value = Coins.DefaultValue;
        UIGameManager.Instance.UpdateCoins();
    }

    public void AddCoins(int amount = 1)
    {
        Coins.Value += amount;
        UIGameManager.Instance.UpdateCoins();
    }

    public void AddLife(int amount = 1)
    {
        if(_playerHealth == null) _playerHealth = FindObjectOfType<HealthPlayer>();

        _playerHealth.SetCurrentLife(amount);
    }
}
