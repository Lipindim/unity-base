using UnityEngine;


public class AutoMoveController : MonoBehaviour
{
    [SerializeField] private float _speed = 3;

    private void Update()
    {
        transform.position += transform.forward * _speed * Time.deltaTime;
    }
}
