using UnityEngine;


public class BossActivator : MonoBehaviour
{

    #region Fielsd

    [SerializeField] private GameObject _boss;
    [SerializeField] private UIOutputController _uiOutputController;
    [SerializeField] private Animator _bossDoorAnimator;
    [SerializeField] private string _message;

    [SerializeField] private float _messageDisplayTime;

    private bool _isActivated = false;

    #endregion

    #region UnityMethods

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !_isActivated)
        {
            _uiOutputController.DisplayCheckPointMessage(_message, _messageDisplayTime);
            _boss.SetActive(true);
            _bossDoorAnimator.SetTrigger("Close");
            _isActivated = true;
        }
    }

    #endregion

}
