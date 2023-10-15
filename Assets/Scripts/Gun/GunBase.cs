using Ebac.Core.Singletons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : Singleton<GunBase>
{
    public Transform playerSideReference;

    [SerializeField] private ProjectileBase projectilePrefab;
    [SerializeField] private Transform positionToShoot;
    [SerializeField] private int maxOfProjectiles = 5;
    [SerializeField] private float timeBetweenShoot = .2f;

    [SerializeField] private int damage = 1;

    private readonly List<ProjectileBase> _projectiles = new List<ProjectileBase>();
    private int _actualNumberOfProjectiles = 0;

    private Coroutine _currentCoroutine;
    private WaitForSeconds _waitForSeconds => new WaitForSeconds(timeBetweenShoot);

    private void Start()
    {
        UIGameManager.Instance.UpdateProjectiles(maxOfProjectiles.ToString());

        projectilePrefab.gameObject.SetActive(false);

        Transform projectilesParent = GameManager.Instance.projectilesParent;

        for (int i = 0; i < maxOfProjectiles; i++)
        {
            ProjectileBase newProjectile = Instantiate(projectilePrefab, projectilesParent);
            newProjectile.initialPosition = positionToShoot;
            newProjectile.damage = damage;
            _projectiles.Add(newProjectile);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _currentCoroutine ??= StartCoroutine(StartShoot());
        }
        else if(Input.GetMouseButtonUp(0))
        {
            if (_currentCoroutine != null)
            {
                StopCoroutine(_currentCoroutine);
                _currentCoroutine = null;
            }
        }
    }

    private IEnumerator StartShoot()
    {
        while (true)
        {
            Shoot();
            yield return _waitForSeconds;
        }
    }

    public void Shoot()
    {
        if(_actualNumberOfProjectiles < maxOfProjectiles)
        {
            foreach(ProjectileBase projectile in _projectiles)
            {
                if (!projectile.gameObject.activeInHierarchy)
                {
                    projectile.gameObject.SetActive(true);
                    projectile.side = playerSideReference.transform.localScale.x;
                    break;
                }
            }
            _actualNumberOfProjectiles++;

            UIGameManager.Instance.UpdateProjectiles((maxOfProjectiles - _actualNumberOfProjectiles).ToString());
        }
    }

    public void DesactiveProjectile()
    {
        _actualNumberOfProjectiles--;
    }
}