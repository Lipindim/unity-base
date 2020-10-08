using TMPro.EditorUtilities;
using UnityEngine;


public class MoveController : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _jumpPower = 2000000;
    [SerializeField] private float _turnSpeed = 180;

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float vectorX = Input.GetAxisRaw("Horizontal");
        float vectorZ = Input.GetAxisRaw("Vertical");

        if (_rigidbody.velocity.sqrMagnitude < _speed * _speed)
            _rigidbody.AddForce(transform.forward * vectorZ * _speed, ForceMode.Impulse);
        var rotateVector = new Vector3(0, vectorX * _turnSpeed * Time.deltaTime, 0);
        transform.Rotate(rotateVector);

        if (Input.GetKeyDown(KeyCode.Space))
            _rigidbody.AddForce((gameObject.transform.up) * _jumpPower);
    }
}
