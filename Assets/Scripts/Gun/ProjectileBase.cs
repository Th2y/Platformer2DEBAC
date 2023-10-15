using System;
using System.Collections;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    [SerializeField] private Vector3 direction;
    [SerializeField] private float timeToDisable = 5f;

    [NonSerialized] public Transform initialPosition;
    [NonSerialized] public int damage;
    [NonSerialized] public float side = 1;

    private bool _canMove = false;

    private WaitForSeconds _waitForSeconds => new WaitForSeconds(timeToDisable);

    private void Update()
    {
        if(_canMove) transform.Translate(side * Time.deltaTime * direction);
    }

    private void OnEnable()
    {
        transform.position = initialPosition.position;
        _canMove = true;

        StartCoroutine(Disable());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DoOnDisable();
        
        if (collision.gameObject.TryGetComponent<HealthEnemy>(out var healthBase))
        {
            healthBase.Damage(damage);
        }
    }

    private void DoOnDisable()
    {
        _canMove = false;
        gameObject.SetActive(false);

        GunBase.Instance.DesactiveProjectile();
    }

    IEnumerator Disable()
    {
        yield return _waitForSeconds;

        DoOnDisable();
    }
}
