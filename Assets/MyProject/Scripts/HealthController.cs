using System;
using UnityEngine;


public class HealthController : MonoBehaviour
{
    public float HealthValue
    {
        get
        {
            return _healthValue;
        }
    }

    public event Action<float> OnChangeHealth;
    public event Action OnDie;

    [SerializeField] private float _healthValue = 3.0f;

    private float _currentHealthValue;

    void Start()
    {
        _currentHealthValue = _healthValue;
    }

    public void Hurt(float damage)
    {
        _currentHealthValue -= damage;
        OnChangeHealth?.Invoke(_currentHealthValue);
        if (_currentHealthValue <= 0)
        {
            KillsCounter.Instanse.AddKill(gameObject);
            OnDie?.Invoke();
            Destroy(gameObject);
        }
    }
}
