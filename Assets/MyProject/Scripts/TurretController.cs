using System;
using UnityEngine;


public class TurretController : MonoBehaviour
{
    [SerializeField] private float _attackRange = 2;
    [SerializeField] private float _attackSpeed = 1;

    private DateTime? _lastShotTime;
    private GameObject _player;
    private float _attackIntervalTime;

    private void Start()
    {
        _attackIntervalTime = 1 / _attackSpeed;
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if ((_player.transform.position - transform.position).sqrMagnitude < _attackRange * _attackRange)
        {
            print("Ты в зоне атаки!");
            transform.LookAt(new Vector3(_player.transform.position.x, transform.position.y, _player.transform.position.z));
            if (!_lastShotTime.HasValue || (DateTime.UtcNow - _lastShotTime.Value).TotalSeconds >= _attackIntervalTime)
            {
                GetComponent<ShotController>().Shot();
                _lastShotTime = DateTime.UtcNow;
            }
        }
    }
}
