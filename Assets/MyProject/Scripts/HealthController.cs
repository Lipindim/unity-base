using UnityEngine;


public class HealthController : MonoBehaviour
{
    [SerializeField] private float _healthValue = 3;

    private float _currentHealthValue;

    void Start()
    {
        _currentHealthValue = _healthValue;
    }

    public void Hurt(float damage)
    {
        _currentHealthValue -= damage;
        if (_currentHealthValue <= 0)
        {
            KillsCounter.Instanse.AddKill(gameObject);
            Destroy(gameObject);
        }
    }
}
