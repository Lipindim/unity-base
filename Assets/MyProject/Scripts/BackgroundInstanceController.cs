using UnityEngine;

public class BackgroundInstanceController : MonoBehaviour
{

    #region Fields

    private static bool _isInitialized;

    #endregion


    #region UnityMethods

    private void Start()
    {
        if (!_isInitialized)
        {
            DontDestroyOnLoad(gameObject);
            GetComponent<AudioSource>().Play();
            _isInitialized = true;
        }
    }

    #endregion

}
