using System;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    [NonSerialized] public Action OnKill;

    [SerializeField] protected Animator animator;
    [SerializeField] private SOStringAnimations stringAnimations;

    [SerializeField] protected bool destroyOnKill = false;
    [SerializeField] protected float delayToKill = 1f;

    [SerializeField] private FlashColor _flashColor;

    private bool _isDead = false;

    private void Awake()
    {
        if(_flashColor == null) _flashColor = GetComponent<FlashColor>();

        Init();
    }

    protected virtual void Init()
    {
        _isDead = false;
    }

    public virtual void Damage(int damage)
    {
        if (_isDead) return;

        Flash();
    }

    private void Flash()
    {
        if (_flashColor == null) return;

        _flashColor.DamageFlash();
    }

    protected void Kill()
    {
        _isDead = true;

        OnKill?.Invoke();

        if (destroyOnKill)
        {
            Destroy(gameObject, delayToKill);
        }
        else
        {
            animator.SetTrigger(stringAnimations.Death);
        }
    }

    public virtual int GetCurrentLife()
    {
        return 0;
    }

    public virtual void SetCurrentLife(int amount) {}
}
