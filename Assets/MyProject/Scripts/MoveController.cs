using UnityEngine;


public class MoveController : MonoBehaviour
{

    #region Fields

    [SerializeField] private float _speed = 5.0f;

    private Rigidbody _rigidbody;
    private Animator _animator;

    private bool _isWalk;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        Rotation();
        ChangeAnimation();
    }

    #endregion


    #region Methods

    private void Rotation()
    {
        if (IsCharacterMoving())
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
    }

    private void Move()
    {
        float z = Input.GetAxisRaw("Horizontal");
        float x = Input.GetAxisRaw("Vertical");

        _rigidbody.velocity = (new Vector3(-x, transform.position.y, z)) * _speed;
    }

    private void ChangeAnimation()
    {
        if (IsCharacterMoving() && !_isWalk)
        {
            _isWalk = true;
            _animator.SetTrigger("Walk");
        }
        else if (!IsCharacterMoving() && _isWalk)
        {
            _isWalk = false;
            _animator.ResetTrigger("Walk");
        }
    }

    private bool IsCharacterMoving()
    {
        return _rigidbody.velocity.sqrMagnitude != 0;
    }

    #endregion

}
