using UnityEngine;


public class MoveController : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _jumpPower = 2000000;
    [SerializeField] private float _turnSpeed = 180;
    
    private void Update()
    {
        float vectorX = Input.GetAxis("Horizontal");
        float vectorZ = Input.GetAxisRaw("Vertical");

        GetComponent<Rigidbody>().AddForce(transform.forward * vectorZ * _speed);
        //transform.position += transform.forward * vectorZ * _speed * Time.deltaTime;
        var rotateVector = new Vector3(0, vectorX * _turnSpeed * Time.deltaTime, 0);
        transform.Rotate(rotateVector);

        if (Input.GetKeyDown(KeyCode.Space))
            GetComponent<Rigidbody>().AddForce((gameObject.transform.up) * _jumpPower);
    }
}
