using UnityEngine;


public class AutoDestroyer : MonoBehaviour
{

    #region Fields

    [SerializeField] private float _liveTimeSec = 5.0f;

    #endregion


    #region UnityMethods

    private void Start()
    {
        Destroy(gameObject, _liveTimeSec);
    }

    #endregion

}
