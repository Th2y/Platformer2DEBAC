public class HealthEnemy : HealthBase
{
    private int currentLife;

    protected override void Init()
    {
        base.Init();

        currentLife = startLife;
    }

    public override void Damage(int damage)
    {
        base.Damage(damage);

        currentLife -= damage;

        if (currentLife <= 0)
        {
            Kill();
        }
    }

    public override int GetCurrentLife()
    {
        return currentLife;
    }

    public override void SetCurrentLife(int amount)
    {
        currentLife += amount;
    }
}
