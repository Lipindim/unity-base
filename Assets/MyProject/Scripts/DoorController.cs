using System.Linq;
using UnityEngine;

public class DoorController : MonoBehaviour, IActivatedItem
{

    #region Fields

    [SerializeField] private Item[] _keys;
    [SerializeField] private ItemCollector _itemCollector;

    private Animator _doorAnimator;
    private bool _isActivated;

    #endregion


    #region Properties

    public bool ReadyForActivation
    {
        get
        {
            if (_isActivated)
                return false;

            var intersectCollection = _itemCollector.CollectedItems.Intersect(_keys);
            return intersectCollection.Count() == _keys.Length;
        }
    }

    #endregion


    #region UnityMethods

    private void Start()
    {
        _doorAnimator = GetComponent<Animator>();
    }

    #endregion


    #region Methods

    public void Activate()
    {
        _isActivated = true;
        _doorAnimator.SetTrigger("Open");
    }

    #endregion

}
