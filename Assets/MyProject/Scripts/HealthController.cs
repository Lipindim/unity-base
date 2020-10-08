using System;
using UnityEngine;


public class HealthController : MonoBehaviour
{
    public event Action<float> OnChangeHealth;
    public float HealthValue
    {
        get
        {
            return _healthValue;
        }
    }

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
            Destroy(gameObject);
        }
    }
}
