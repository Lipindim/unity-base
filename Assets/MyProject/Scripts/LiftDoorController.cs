using UnityEngine;

public class LiftDoorController : MonoBehaviour
{

    #region Fields

    [SerializeField] private HealthController _boss;

    private Animator _liftDoorAnimator;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _boss.OnDie += BossOnDie;
        _liftDoorAnimator = GetComponent<Animator>();
    }

    #endregion


    #region Methods

    private void BossOnDie()
    {
        _liftDoorAnimator.SetTrigger("Open");
    }

    #endregion

}
