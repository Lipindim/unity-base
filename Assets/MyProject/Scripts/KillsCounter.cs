using UnityEngine;


public class KillsCounter : MonoBehaviour
{
    [SerializeField] private int _maxKillsCount = 5;

    private int _currentKillCount = 0;

    public static KillsCounter Instanse { get; private set; }

    private void Start()
    {
        if (Instanse == null)
            Instanse = this;
    }

    public void AddKill(GameObject killObject)
    {
        if (killObject.CompareTag("Enemy"))
        {
            _currentKillCount++;
            if (_currentKillCount >= _maxKillsCount)
                GetComponent<MyGameEnding>().EndGame();
        }
    }

}
