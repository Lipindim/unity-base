using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class ItemCollector : MonoBehaviour
{

    #region Fields

    [SerializeField] private string _collectWeaponMessage;

    [SerializeField] private float _messageDisplayTime = 5.0f;
    [SerializeField] private float _collectItemRadius = 3.0f;

    private GameObject[] _items;
    private UIOutputController _uiOutputController;
    private List<Item> _collectedItems;

    private float _squareCollectedRadius;

    #endregion


    #region Properties

    public IEnumerable<Item> CollectedItems
    {
        get
        {
            return _collectedItems;
        }
    }

    #endregion


    #region UnityMethods

    private void Start()
    {
        _items = GameObject.FindGameObjectsWithTag("Item");
        _squareCollectedRadius = _collectItemRadius * _collectItemRadius;
        _collectedItems = new List<Item>();
        _uiOutputController = GetComponent<UIOutputController>();
    }

    private void Update()
    {
        PickUpItems();
    }

    #endregion


    #region Methods

    private void PickUpItems()
    {
        foreach (var gameObject in _items)
        { 
            if (gameObject.activeSelf && InCollectaeRange(gameObject))
            {
                Item item = gameObject.GetComponent<Item>();
                _collectedItems.Add(item);
                gameObject.SetActive(false);
                _uiOutputController.DisplayInventory(_collectedItems);
                if (item.ItemType == ItemTypes.Weapon)
                    _uiOutputController.DisplayCheckPointMessage(_collectWeaponMessage, _messageDisplayTime);
            }
        }
    }

    private bool InCollectaeRange(GameObject item)
    {
        var vectorFromPlayerToItem = item.transform.position - transform.position;
        return vectorFromPlayerToItem.sqrMagnitude < _squareCollectedRadius;
    }

    public bool HaveWeapon()
    {
        return _collectedItems.Any(x => x.ItemType == ItemTypes.Weapon);
    }

    #endregion

}
