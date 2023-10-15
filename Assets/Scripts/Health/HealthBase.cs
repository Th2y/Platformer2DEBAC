using UnityEngine;

public class HealthBase : MonoBehaviour
{
    [SerializeField] protected Animator animator;
    [SerializeField] private string deathTriggerAnim;

    [SerializeField] protected int startLife;
    [SerializeField] protected bool destroyOnKill = false;
    [SerializeField] protected float delayToKill = 1f;

    [SerializeField] private FlashColor _flashColor;

    protected int currentLife;

    private bool _isDead = false;

    private void Awake()
    {
        if(_flashColor == null) _flashColor = GetComponent<FlashColor>();

        Init();
    }

    protected virtual void Init()
    {
        _isDead = false;
        currentLife = startLife;
    }

    public virtual void Damage(int damage)
    {
        if (_isDead) return;

        currentLife -= damage;
    }

    protected virtual void Flash()
    {
        if (_flashColor == null) return;

        _flashColor.Flash();
    }

    protected void Kill()
    {
        _isDead = true;

        if(destroyOnKill)
        {
            Destroy(gameObject, delayToKill);
        }
        else
        {
            animator.SetTrigger(deathTriggerAnim);
        }
    }

    public int GetCurrentLife()
    {
        return currentLife;
    }

    public void SetCurrentLife(int amount)
    {
        currentLife += amount;
    }
}
