public class ItemCollectableLife : ItemCollectableBase
{
    protected override void OnCollect()
    {
        base.OnCollect();

        ItemManager.Instance.AddLife(value);
    }
}
