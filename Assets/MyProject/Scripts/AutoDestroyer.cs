using UnityEngine;


public class AutoDestroyer : MonoBehaviour
{

    #region Fields

    [SerializeField] private int _liveTimeSec = 5;

    #endregion

    #region UnityMethods

    private void Start()
    {
        Destroy(gameObject, _liveTimeSec);
    }

    #endregion

}
