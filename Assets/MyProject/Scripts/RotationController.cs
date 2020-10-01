using UnityEngine;


public class RotationController : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 5;

    public void Update()
    {
        transform.Rotate(transform.forward, Time.deltaTime * _rotationSpeed);
    }
}
