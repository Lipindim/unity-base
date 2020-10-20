using UnityEngine;


public class ShotController : MonoBehaviour
{

    #region Fields

    [SerializeField] private GameObject _spawnBullet;
    [SerializeField] private Transform[] _bulletSpawnPoints;

    [SerializeField] private float _reloadTime = 1.0f;
    [SerializeField] private float _shotPower = 50.0f;

    private bool _isReload;
    private int _currentAmmoSpawnPointIndex;

    #endregion


    #region Properties

    public Transform CurrentAmmoSpawnPoint
    {
        get
        {
            return _bulletSpawnPoints[_currentAmmoSpawnPointIndex];
        }
    }

    public bool IsReload
    {
        get
        {
            return _isReload;
        }
    }

    #endregion


    #region Methods

    public void ShotToPint(Vector3 pointToShot)
    {
        Vector3 directionToShot = pointToShot - CurrentAmmoSpawnPoint.position;
        ShotToDirection(directionToShot);
    }

    public void ShotToDirection(Vector3 directionToShot)
    {
        if (!_isReload)
        {
            _isReload = true;
            GameObject gameObject = Instantiate(_spawnBullet, CurrentAmmoSpawnPoint.position, CurrentAmmoSpawnPoint.rotation);
            gameObject.GetComponent<Rigidbody>().AddForce(directionToShot.normalized * _shotPower);
            Invoke(nameof(Reload), _reloadTime);
            NextAmmoSpawnPoint();
        }
    }

    private void NextAmmoSpawnPoint()
    {
        _currentAmmoSpawnPointIndex = (_currentAmmoSpawnPointIndex + 1) % _bulletSpawnPoints.Length;
    }

    private void Reload()
    {
        _isReload = false;
    }

    #endregion

}
