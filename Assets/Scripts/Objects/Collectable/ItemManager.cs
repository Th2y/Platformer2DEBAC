using Ebac.Core.Singletons;

public class ItemManager : Singleton<ItemManager>
{
    public SOInt Coins;
    public SOInt Life;
    public SOInt Projectiles;

    private HealthBase _playerHealth;

    private void Start()
    {
        Reset();
    }

    private void Reset()
    {
        Coins.Value = 0;
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
