using UnityEngine;


public class CheckPointController : MonoBehaviour
{

    #region Fields

    [SerializeField] private UIOutputController _uiOutputController;
    [SerializeField] private string _message;

    [SerializeField] private float _checkPointDisplayTime = 5.0f;

    private bool _isMessageDispleyd = false;

    #endregion

    #region UnityMethods

    private void OnTriggerEnter(Collider other)
    {
        if (!_isMessageDispleyd && other.gameObject.CompareTag("Player"))
        {
            _uiOutputController.DisplayCheckPointMessage(_message, _checkPointDisplayTime);
            _isMessageDispleyd = true;
        }
    }

    #endregion

}
