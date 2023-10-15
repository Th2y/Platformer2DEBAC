public class HealthEnemy : HealthBase
{
    public override void Damage(int damage)
    {
        base.Damage(damage);

        Flash();

        if (currentLife <= 0)
        {
            Kill();
        }
    }
}
