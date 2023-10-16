public class ItemCollectableLife : ItemCollectableBase
{
    protected override void OnCollect()
    {
        base.OnCollect();

        ItemManager.Instance.AddLife(value);

        if (particle != null) particle.Play();

        Invoke(nameof(DisabeleParticle), timeToDisableParticle);
    }
}
