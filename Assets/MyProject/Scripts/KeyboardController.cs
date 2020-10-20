using UnityEngine;


public class KeyboardController : MonoBehaviour
{

    #region Fields

    private ObjectSpawner _mineSpawner;
    private ItemCollector _itemCollector;
    private ItemActivator _itemActivator;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _mineSpawner = GetComponent<ObjectSpawner>();
        _itemCollector = GetComponent<ItemCollector>();
        _itemActivator = GetComponent<ItemActivator>();
    }

    private void Update()
    {
        SpawnMine();
        ActivateItem();
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

    private void ActivateItem()
    {
        if (Input.GetKeyDown(KeyCode.E))
            _itemActivator.ActivateNearObject();
    }

    #endregion

}
