using UnityEngine;


public class KeyboardController : MonoBehaviour
{
    private ObjectSpawner _mineSpawner;
    private ItemCollector _itemCollector;

    private void Start()
    {
        _mineSpawner = GetComponent<ObjectSpawner>();
        _itemCollector = GetComponent<ItemCollector>();
    }

    private void Update()
    {
        SpawnMine();
    }

    private void SpawnMine()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && _itemCollector.HaveWeapon())
        {
            _mineSpawner.Spawn();
        }
    }
}
