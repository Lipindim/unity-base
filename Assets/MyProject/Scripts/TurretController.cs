using System;
using UnityEngine;


public class TurretController : MonoBehaviour
{
    [SerializeField] private float _attackRange = 2;

    private GameObject _player;
    private ShotController _shotController;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _shotController = GetComponent<ShotController>();
    }

    private void Update()
    {
        if ((_player.transform.position - transform.position).sqrMagnitude < _attackRange * _attackRange)
        {
            transform.LookAt(new Vector3(_player.transform.position.x, transform.position.y, _player.transform.position.z));
            _shotController.Shot();
        }
    }
}
