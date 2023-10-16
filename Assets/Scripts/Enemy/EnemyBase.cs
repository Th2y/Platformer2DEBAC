using System.Collections;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [Header("Damage")]
    [SerializeField] private int damage;
    [SerializeField] private float timeToDamage;
    [SerializeField] private HealthEnemy health;
    [SerializeField] private bool isEnemyType1 = true;

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
        DoDamage(collision);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        DoDamage(collision);
    }

    private void DoDamage(Collision2D collision)
    {
        if (_damageCoroutine == null)
        {
            if (collision.gameObject.TryGetComponent<HealthPlayer>(out var player))
            {
                _damageCoroutine = StartCoroutine(DoDamageCoroutine(player));
            }
        }
    }

    private IEnumerator DoDamageCoroutine(HealthPlayer player)
    {
        OnAttack();
        player.Damage(damage);

        yield return _waitForDamage;

        StopCoroutine(_damageCoroutine);
        _damageCoroutine = null;
    }

    private void OnAttack()
    {
        animator.SetTrigger(stringAnimations.Attack);
        AudioController.Instance.PlaySFXByName(isEnemyType1 ? SFXNames.Enemy1Attack : SFXNames.Enemy2Attack);
    }

    private void OnKill()
    {
        health.OnKill -= OnKill;
    }
}
