using System;
using DefaultNamespace;
using DefaultNamespace.Core.Services.InputServices;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(CollisionHandler))]
public class Player : MonoBehaviour
{
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private ScoreModel _scoreModel;
    [SerializeField] private Transform _bulletSpawnPoint;
    
    private PlayerMover _playerMover;
    private CollisionHandler _handler;
    private IInputService _inputService;


    public event Action GameFinished;

    private void Awake()
    {
        _handler = GetComponent<CollisionHandler>();
        _playerMover = GetComponent<PlayerMover>();
        _inputService = new StandaloneInputService();
    }

    private void OnEnable()
    {
        _handler.CollisionDetected += ProcessCollision;
    }

    private void OnDisable()
    {
        _handler.CollisionDetected -= ProcessCollision;
    }

    private void Update()
    {
        if (_inputService.IsAttacking)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        _bulletSpawner.Spawn(_bulletSpawnPoint.position);
    }

    private void ProcessCollision(IInteractable interactable)
    {
        GameFinished?.Invoke();
    }

    public void Reset()
    {
        _scoreModel.Reset();
        _playerMover.Reset();
    }
}