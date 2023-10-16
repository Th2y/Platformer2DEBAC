public class ItemCollectableCoin : ItemCollectableBase
{
    protected override void OnCollect()
    {
        base.OnCollect();

        ItemManager.Instance.AddCoins(value);

        if (particle != null) particle.Play();

        Invoke(nameof(DisabeleParticle), timeToDisableParticle);
    }
}
