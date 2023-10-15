public class HealthEnemy : HealthBase
{
    public override void Damage(int damage)
    {
        base.Damage(damage);

        if (currentLife <= 0)
        {
            Kill();
        }
    }
}
