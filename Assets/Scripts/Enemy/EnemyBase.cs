using System.Collections;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [Header("Damage")]
    [SerializeField] private int damage;
    [SerializeField] private float timeToDamage;
    [SerializeField] private HealthEnemy health;

    [Header("Animation")]
    [SerializeField] private Animator animator;
    [SerializeField] private SOStringAnimations stringAnimations;

    private Coroutine _damageCoroutine = null;
    private readonly WaitForSeconds _waitForDamage = new WaitForSeconds(1);

    private void Awake()
    {
        if(health != null)
        {
            health.OnKill += OnKill;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_damageCoroutine == null)
        {
            if (collision.gameObject.TryGetComponent<HealthPlayer>(out var player))
            {
                _damageCoroutine = StartCoroutine(DoDamage(player));
            }
        }
    }

    private IEnumerator DoDamage(HealthPlayer player)
    {
        while (true)
        {
            PlayAttackAnimation();
            player.Damage(damage);

            yield return _waitForDamage;

            StopCoroutine(_damageCoroutine);
        }
    }

    private void PlayAttackAnimation()
    {
        animator.SetTrigger(stringAnimations.Attack);
    }

    private void OnKill()
    {
        health.OnKill -= OnKill;
    }
}
