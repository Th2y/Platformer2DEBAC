public class HealthPlayer : HealthBase
{
    protected override void Init()
    {
        base.Init();

        UIGameManager.Instance.UpdateLife(currentLife.ToString());
    }

    public override void Damage(int damage)
    {
        base.Damage(damage);

        UIGameManager.Instance.UpdateLife(currentLife.ToString());

        if (currentLife <= 0)
        {
            Kill();
        }
    }
}
