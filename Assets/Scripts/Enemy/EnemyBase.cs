using System.Collections;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [Header("Damage")]
    [SerializeField] private int damage;
    [SerializeField] private float timeToDamage;

    [Header("Animation")]
    [SerializeField] private Animator animator;
    [SerializeField] private string attackTrigger;

    private Coroutine damageCoroutine = null;
    private readonly WaitForSeconds waitForDamage = new WaitForSeconds(1);

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (damageCoroutine == null)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                StartCoroutine(DoDamage(collision.gameObject));
            }
        }
    }

    private IEnumerator DoDamage(GameObject player)
    {
        HealthBase health = player.GetComponent<HealthBase>();
        if (health != null)
        {
            PlayAttackAnimation();
            health.Damage(damage);
        }

        yield return waitForDamage;

        damageCoroutine = null;
    }

    private void PlayAttackAnimation()
    {
        animator.SetTrigger(attackTrigger);
    }
}
