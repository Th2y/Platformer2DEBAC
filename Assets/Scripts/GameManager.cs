using DG.Tweening;
using Ebac.Core.Singletons;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("Characters")]
    [SerializeField] private Transform charactersParent;

    [Header("Player")]
    [SerializeField] private GameObject playerPrefab;

    [Header("Enemies")]
    [SerializeField] private List<GameObject> enemies;

    [Header("References")]
    [SerializeField] private Transform startPoint;

    [Header("Animation")]
    [SerializeField] private float duration = .2f;
    [SerializeField] private float delay = .05f;
    [SerializeField] private Ease ease = Ease.OutBack;

    private GameObject _currentPlayer;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        SpawnPlayer();
    }

    private void SpawnPlayer()
    {
        _currentPlayer = Instantiate(playerPrefab, charactersParent);
        _currentPlayer.transform.position = startPoint.transform.position;
        _currentPlayer.transform.DOScale(0, duration).SetEase(ease).From().SetDelay(delay);
    }
}
