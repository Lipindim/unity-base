using System.Timers;
using UnityEngine;


public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private uint _enemyCount = 5;
    [SerializeField] private float _spawnIntervalSec = 1;

    private Timer _timer;
    private int _enemySpawned = 0;

    private void Start()
    {
        InvokeRepeating(nameof(CreateEnemy), 1, _spawnIntervalSec);
    }

    private void CreateEnemy()
    {
        if (_enemyCount <= _enemySpawned)
        {
            CancelInvoke(nameof(CreateEnemy));
            return;
        }

        Instantiate(_enemy, _spawnPoint.position, _spawnPoint.rotation);
        _enemySpawned++;
    }
}
