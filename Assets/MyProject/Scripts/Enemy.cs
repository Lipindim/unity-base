using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _healthValue = 3;
    private int _currentHealthValue;
    void Start()
    {
        _currentHealthValue = _healthValue;
    }

    public void Hurt(int damage)
    {
        _currentHealthValue -= damage;
        if (_currentHealthValue <= 0)
            Destroy(gameObject);
    }
}
