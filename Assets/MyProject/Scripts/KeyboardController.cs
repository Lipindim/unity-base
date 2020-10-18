using UnityEngine;


public class KeyboardController : MonoBehaviour
{

    #region Fields

    private ObjectSpawner _mineSpawner;
    private ItemCollector _itemCollector;

    #endregion

    #region UnityMethods

    private void Start()
    {
        _mineSpawner = GetComponent<ObjectSpawner>();
        _itemCollector = GetComponent<ItemCollector>();
    }

    private void Update()
    {
        SpawnMine();
    }

    #endregion

    #region Methods

    private void SpawnMine()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1) && _itemCollector.HaveWeapon())
        {
            _mineSpawner.Spawn();
        }
    }

    #endregion

}
