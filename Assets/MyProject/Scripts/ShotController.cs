using UnityEngine;


public class ShotController : MonoBehaviour
{

    #region Fields

    [SerializeField] private GameObject _spawnObject;
    [SerializeField] private Transform _spawnPoint;

    [SerializeField] private float _reloadTime = 1.0f;
    [SerializeField] private float _shotPower = 50.0f;

    private bool _isReload;

    #endregion

    #region Methods

    public void Shot()
    {
        if (!_isReload)
        {
            _isReload = true;
            GameObject gameObject = Instantiate(_spawnObject, _spawnPoint.position, _spawnPoint.rotation);
            gameObject.GetComponent<Rigidbody>().AddForce((gameObject.transform.up + 10 * gameObject.transform.forward) * _shotPower);
            Invoke(nameof(Reload), _reloadTime);
        }
    }

    public void Shot(Vector3 directionToShot)
    {
        if (!_isReload)
        {
            _isReload = true;
            GameObject gameObject = Instantiate(_spawnObject, _spawnPoint.position, _spawnPoint.rotation);
            gameObject.GetComponent<Rigidbody>().AddForce(directionToShot.normalized * _shotPower);
            Invoke(nameof(Reload), _reloadTime);
        }
    }

    private void Reload()
    {
        _isReload = false;
    }

    #endregion

}
