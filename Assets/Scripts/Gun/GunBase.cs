using Ebac.Core.Singletons;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GunBase : Singleton<GunBase>
{
    public Transform playerSideReference;

    [SerializeField] private Animator animator;
    [SerializeField] private SOStringAnimations stringAnimations;
    [SerializeField] private ProjectileBase projectilePrefab;
    [SerializeField] private Transform positionToShoot;
    [SerializeField] private int maxOfProjectiles = 5;
    [SerializeField] private float timeBetweenShoot = .2f;

    [SerializeField] private int damage = 1;

    [SerializeField] private SOInt _projectile;

    private readonly List<ProjectileBase> _projectiles = new List<ProjectileBase>();
    private int _actualNumberOfProjectiles = 0;

    private Coroutine _currentCoroutine;
    private WaitForSeconds _waitForSeconds => new WaitForSeconds(timeBetweenShoot);

    private void Start()
    {
        _projectile.Value = _projectile.DefaultValue;
        UIGameManager.Instance.UpdateProjectiles();

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
        if (Input.GetButton("Fire1") && !EventSystem.current.IsPointerOverGameObject())
        {
            _currentCoroutine ??= StartCoroutine(StartShoot());
        }
    }

    private IEnumerator StartShoot()
    {
        Shoot();
        yield return _waitForSeconds;

        StopCoroutine(_currentCoroutine);
        _currentCoroutine = null;
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

            animator.SetBool(stringAnimations.Attack, true);
            AudioController.Instance.PlaySFXByName(SFXNames.PlayerAttack);

            _actualNumberOfProjectiles++;

            _projectile.Value = maxOfProjectiles - _actualNumberOfProjectiles;
            UIGameManager.Instance.UpdateProjectiles();
        }
    }

    public void DesactiveProjectile()
    {
        _actualNumberOfProjectiles--;

        _projectile.Value = maxOfProjectiles - _actualNumberOfProjectiles;
        UIGameManager.Instance.UpdateProjectiles();
    }
}
