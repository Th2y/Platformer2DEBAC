using Cinemachine;
using DG.Tweening;
using Ebac.Core.Singletons;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [Header("Characters")]
    [SerializeField] private Transform charactersParent;

    [Header("Player")]
    [SerializeField] private SOPlayers players;

    [Header("Enemies")]
    [SerializeField] private List<GameObject> enemies;

    [Header("References")]
    public Transform projectilesParent;
    public Transform particleParent;
    [SerializeField] private CinemachineVirtualCamera virtualCamera;
    [SerializeField] private Transform startPoint;

    private Player _currentPlayer;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        SpawnPlayer();

        virtualCamera.Follow = _currentPlayer.transform;
        virtualCamera.LookAt = _currentPlayer.transform;
    }

    private void SpawnPlayer()
    {
        int i = Random.Range(0, players.PlayersDic.Count);

        _currentPlayer = Instantiate(players.PlayerList[i], charactersParent);
        _currentPlayer.transform.position = startPoint.transform.position;
    }
}
