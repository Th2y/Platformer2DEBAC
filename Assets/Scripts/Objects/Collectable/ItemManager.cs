using Ebac.Core.Singletons;

public class ItemManager : Singleton<ItemManager>
{
    private HealthBase _playerHealth;

    private int coins;

    private void Start()
    {
        _playerHealth = FindObjectOfType<HealthPlayer>();

        Reset();
    }

    private void Reset()
    {
        coins = 0;
        UIGameManager.Instance.UpdateCoins(coins.ToString());
    }

    public void AddCoins(int amount = 1)
    {
        coins += amount;
        UIGameManager.Instance.UpdateCoins(coins.ToString());
    }

    public void AddLife(int amount = 1)
    {
        if(_playerHealth == null) _playerHealth = FindObjectOfType<HealthPlayer>();

        _playerHealth.SetCurrentLife(amount);
        UIGameManager.Instance.UpdateLife(_playerHealth.GetCurrentLife().ToString());
    }
}
