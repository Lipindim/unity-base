using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private LayerMask _mask;
    [SerializeField] private float _visionRange = 5;
    [SerializeField] private float _visionAngle = 30;
    [SerializeField] private float _attackRange = 2;
    [SerializeField] private float _speed = 10;

    private GameObject _player;
    private ShotController _shotController;
    private Rigidbody _rigidbody;
    private float _squarVisionRange;
    private float _squarAttackRange;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _shotController = GetComponent<ShotController>();
        _rigidbody = GetComponent<Rigidbody>();
        _squarVisionRange = _visionRange * _visionRange;
        _squarAttackRange = _attackRange * _attackRange;
        
        
    }

    private void Update()
    {
        Vector3 directionToPlayer = _player.transform.position - transform.position;
        float squarDistanceToPlayer = directionToPlayer.sqrMagnitude;
        if (IsPlayerInVision(directionToPlayer, squarDistanceToPlayer))
        {
            transform.LookAt(new Vector3(_player.transform.position.x, transform.position.y, _player.transform.position.z));
            if (squarDistanceToPlayer < _squarAttackRange)
                _shotController.Shot(directionToPlayer);
            else
                _rigidbody.AddForce(directionToPlayer.normalized * _speed * Time.deltaTime);
        }
        else
        {
            _rigidbody.AddForce(transform.forward * _speed * Time.deltaTime);
        }
    }

    private bool IsPlayerInVision(Vector3 directionToPlayer, float squarDistanceToPlayer)
    {
        if (_squarVisionRange < squarDistanceToPlayer)
            return false;
        if (_visionAngle < Vector3.Angle(directionToPlayer, transform.forward))
            return false;

        RaycastHit hit;
        var rayCast = Physics.Raycast(transform.position, directionToPlayer, out hit, Mathf.Infinity,
        _mask);
        if (!rayCast)
            return false;
        if (!hit.collider.gameObject.CompareTag("Player"))
            return false;

        return true;
    }
}
