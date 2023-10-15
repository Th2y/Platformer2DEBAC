using System.Collections;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float timeToDamage;

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
            health.Damage(damage);
        }

        yield return waitForDamage;

        damageCoroutine = null;
    }
}
