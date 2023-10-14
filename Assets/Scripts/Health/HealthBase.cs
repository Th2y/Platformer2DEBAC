using System.Collections;
using UnityEngine;

public class HealthBase : MonoBehaviour
{
    [SerializeField] protected Animator animator;
    [SerializeField] private string deathTriggerAnim;

    [SerializeField] protected int startLife;
    [SerializeField] protected bool destroyOnKill = false;
    [SerializeField] protected float delayToKill = 1f;

    private int _currentLife;
    private bool _isDead = false;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _isDead = false;
        _currentLife = startLife;
    }

    public void Damage(int damage)
    {
        if (_isDead) return;

        _currentLife -= damage;
        if(_currentLife <= 0 )
        {
            Kill();
        }
    }

    private void Kill()
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
}
