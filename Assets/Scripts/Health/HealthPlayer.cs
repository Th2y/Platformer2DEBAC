using UnityEngine;

public class HealthPlayer : HealthBase
{
    [SerializeField] private SOInt life;

    protected override void Init()
    {
        base.Init();

        life.Value = life.DefaultValue;
        UIGameManager.Instance.UpdateLife();
    }

    public override void Damage(int damage)
    {
        base.Damage(damage);

        life.Value -= damage;
        UIGameManager.Instance.UpdateLife();

        if (life.Value <= 0)
        {
            Kill();
        }
    }

    public override int GetCurrentLife()
    {
        return life.Value;
    }

    public override void SetCurrentLife(int amount)
    {
        life.Value += amount;
        UIGameManager.Instance.UpdateLife();
    }
}
