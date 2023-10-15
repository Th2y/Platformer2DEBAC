public class ItemCollectableCoin : ItemCollectableBase
{
    protected override void OnCollect()
    {
        base.OnCollect();

        ItemManager.Instance.AddCoins(value);
    }
}
