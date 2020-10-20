using UnityEngine;


public class HandleController : MonoBehaviour, IActivatedItem
{

    #region Properties

    public bool ReadyForActivation { get; private set; }

    #endregion


    #region Fields

    [SerializeField] private float _activatedTimeSec = 5.0f;

    private Animator _handleAnimator;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _handleAnimator = GetComponent<Animator>();
        ReadyForActivation = true;
    }

    #endregion


    #region Methods

    public void Activate()
    {
        ReadyForActivation = false;
        RenderSettings.ambientLight = Color.black;
        GameSettings.IsDark = true;
        _handleAnimator.SetTrigger("Activated");
        Invoke(nameof(Deactivate), _activatedTimeSec);
    }

    private void Deactivate()
    {
        RenderSettings.ambientLight = Color.white;
        GameSettings.IsDark = false;
        _handleAnimator.ResetTrigger("Activated");
        ReadyForActivation = true;
    }

    #endregion

}
