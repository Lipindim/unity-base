using UnityEngine;


public class AutoDestroyer : MonoBehaviour
{
    [SerializeField] private int _liveTimeSec = 5;

    private void Start()
    {
        Destroy(gameObject, _liveTimeSec);
    }
}
