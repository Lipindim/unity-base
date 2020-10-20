using UnityEngine;

public class ItemActivator : MonoBehaviour
{

    #region Fields

    [SerializeField] private float _activatedRadius = 2.0f;
    // Start is called before the first frame update

    private GameObject[] _activatedObjects;
    private float _squareActivatedRadius;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _activatedObjects = GameObject.FindGameObjectsWithTag("ActivatedItem");
        _squareActivatedRadius = _activatedRadius * _activatedRadius;
    }

    #endregion


    #region Methods

    public void ActivateNearObject()
    {
        foreach (GameObject activatedObject in _activatedObjects)
        {
            if (IsObjectInActivatedRadius(activatedObject.transform.position))
            {
                IActivatedItem activatedItem = activatedObject.GetComponent<IActivatedItem>();
                if (activatedItem.ReadyForActivation)
                    activatedItem.Activate();
            }
        }
    }

    private bool IsObjectInActivatedRadius(Vector3 objectPosition)
    {
        return (objectPosition - transform.position).sqrMagnitude < _squareActivatedRadius;
    }

    #endregion

}
