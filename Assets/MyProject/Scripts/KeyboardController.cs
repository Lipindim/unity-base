using UnityEngine;


public class KeyboardController : MonoBehaviour
{
    private ObjectSpawner _mineSpawner;

    private void Start()
    {
        _mineSpawner = GetComponent<ObjectSpawner>();
    }

    private void Update()
    {
        SpawnMine();
    }

    private void SpawnMine()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
            _mineSpawner.Spawn();
    }
}
