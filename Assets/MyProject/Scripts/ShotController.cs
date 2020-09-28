using UnityEngine;


public class ShotController : MonoBehaviour
{
    [SerializeField] private GameObject _spawnObject;
    [SerializeField] private Transform _spawnPoint;

    public void Shot()
    {
        GameObject gameObject = Instantiate(_spawnObject, _spawnPoint.position, _spawnPoint.rotation);
        gameObject.GetComponent<Rigidbody>().AddForce((gameObject.transform.up + 10 * gameObject.transform.forward) * 50);
    }
}
