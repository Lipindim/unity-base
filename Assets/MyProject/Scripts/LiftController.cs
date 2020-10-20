using UnityEngine;


public class LiftController : MonoBehaviour, IActivatedItem
{

    #region Fields

    [SerializeField] private MainMenuController _mainMenuController;

    private bool _isActivated;

    #endregion


    #region Properties

    public bool ReadyForActivation
    {
        get
        {
            return !_isActivated;
        }
    }

    #endregion


    #region Methods

    public void Activate()
    {
        _mainMenuController.LoadSecondLevel();
    }

    #endregion

}
