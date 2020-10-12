using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    private const float DISTANSE_ERROR = 0.05f;

    #region Fields

    [SerializeField] private Transform[] _patrolPoints;

    [SerializeField] private LayerMask _mask;
    [SerializeField] private float _visionRange = 5.0f;
    [SerializeField] private float _visionAngle = 30.0f;
    [SerializeField] private float _attackRange = 2.0f;
    [SerializeField] private float _speed = 10.0f;

    private GameObject _player;
    private ShotController _shotController;
    private NavMeshAgent _navMeshAgent;

    private Vector3 _targetPosition;
    private float _squarVisionRange;
    private float _squarAttackRange;
    private int _currentPatrolPoint;

    #endregion


    #region Fields

    private Vector3 CurrentPatrolPosition
    {
        get
        {
            return _patrolPoints[_currentPatrolPoint].position;
        }
    }

    #endregion


    #region UnityMethods

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _shotController = GetComponent<ShotController>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _squarVisionRange = _visionRange * _visionRange;
        _squarAttackRange = _attackRange * _attackRange;
        _currentPatrolPoint = 0;
        _targetPosition = Vector3.zero;
    }

    private void Update()
    {
        EnemyAction();
    }

    #endregion


    #region Methods

    private void EnemyAction()
    {
        Vector3 directionToPlayer = _player.transform.position - transform.position;
        float squarDistanceToPlayer = directionToPlayer.sqrMagnitude;

        if (IsPlayerInVision(directionToPlayer, squarDistanceToPlayer))
        {
            LookAtPlayer();

            if (squarDistanceToPlayer < _squarAttackRange)
                Shot(directionToPlayer);
            else
                GoToPlayer();
        }
        else
        {
            Patrol();
        }
    }

    private void Shot(Vector3 directionToPlayer)
    {
        Vector3 directionToShot = new Vector3(directionToPlayer.x, directionToPlayer.y - 0.5f, directionToPlayer.z);
        _shotController.Shot(directionToShot);
    }

    private void GoToPlayer()
    {
        if (Mathf.Abs(_targetPosition.sqrMagnitude - _player.transform.position.sqrMagnitude) > DISTANSE_ERROR)
        {
            _navMeshAgent.SetDestination(_player.transform.position);
            _targetPosition = _player.transform.position;
        }
    }

    private void LookAtPlayer()
    {
        transform.LookAt(new Vector3(_player.transform.position.x, transform.position.y, _player.transform.position.z));
    }

    private void Patrol()
    {
        if (_patrolPoints == null || _patrolPoints.Length == 0)
            return;

        if (Mathf.Abs(transform.position.sqrMagnitude - CurrentPatrolPosition.sqrMagnitude) < DISTANSE_ERROR)
            _currentPatrolPoint = (_currentPatrolPoint + 1) % _patrolPoints.Length;

        if (Mathf.Abs(_targetPosition.sqrMagnitude - CurrentPatrolPosition.sqrMagnitude) > DISTANSE_ERROR)
        {
            _navMeshAgent.SetDestination(CurrentPatrolPosition);
            _targetPosition = CurrentPatrolPosition;
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

    #endregion
}
