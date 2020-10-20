using UnityEngine;

public class TurretController : MonoBehaviour, IActivatedItem
{

    #region Fields

    private ShotController _shotController;

    #endregion


    #region Properties

    public bool ReadyForActivation
    {
        get
        {
            return !_shotController.IsReload;
        }
    }

    #endregion


    #region UnityMethods

    private void Start()
    {
        _shotController = GetComponent<ShotController>();
    }

    #endregion


    #region Methods

    public void Activate()
    {
        _shotController.ShotToDirection(transform.forward);
    }

    #endregion

}
