using TMPro.EditorUtilities;
using UnityEngine;


public class MoveController : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _jumpPower = 2000000;
    [SerializeField] private float _turnSpeed = 180;

    private Rigidbody _rigidbody;
    private Animator _animator;

    private bool _isWalk;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        Rotation();
        Jump();
        ChangeAnimation();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _rigidbody.AddForce((gameObject.transform.up) * _jumpPower);
    }

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
}
