using UnityEngine;


public class KeyboardController : MonoBehaviour
{
    private ShotController _shotController;
    private ObjectSpawner _mineSpawner;

    private void Start()
    {
        _shotController = GetComponent<ShotController>();
        _mineSpawner = GetComponent<ObjectSpawner>();
    }

    private void Update()
    {
        Shoot();
        SpawnMine();
    }

    private void SpawnMine()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
            _mineSpawner.Spawn();
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            _shotController.Shot();
    }
}
