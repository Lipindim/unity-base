using UnityEngine;

public class Item : MonoBehaviour
{

    #region Properties

    public string ItemName
    {
        get
        {
            return _itemName;
        }
    }

    public ItemTypes ItemType
    {
        get
        {
            return _itemType;
        }
    }

    #endregion


    #region Fields

    [SerializeField] private string _itemName;
    [SerializeField] private ItemTypes _itemType;

    #endregion

}
