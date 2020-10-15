using UnityEngine;
using UnityEngine.UI;

public class TurretController : MonoBehaviour
{

    #region Fields

    [SerializeField] private LayerMask _mask;
    [SerializeField] private float _attackRange = 2;

    private GameObject _player;
    private ShotController _shotController;

    #endregion

    #region UnityMethods

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _shotController = GetComponent<ShotController>();
    }

    private void Update()
    {
        Attack();
    }

    #endregion

    #region Methods

    private void Attack()
    {
        Vector3 directionToPlayer = _player.transform.position - transform.position;
        if (IsPlayerInAttackRange(directionToPlayer))
        {
            Vector3 vectorToAttack = new Vector3(_player.transform.position.x, transform.position.y, _player.transform.position.z);
            transform.LookAt(vectorToAttack);
            _shotController.Shot();
        }
    }

    private bool IsPlayerInAttackRange(Vector3 directionToPlayer)
    {
        RaycastHit hit;
        var rayCast = Physics.Raycast(transform.position, directionToPlayer, out hit, _attackRange, _mask);
        if (!rayCast)
            return false;
        if (!hit.collider.gameObject.CompareTag("Player"))
            return false;

        print(directionToPlayer);
        return true;
    }

    #endregion

}
