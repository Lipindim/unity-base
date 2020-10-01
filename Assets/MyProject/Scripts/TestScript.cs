using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TestScript : MonoBehaviour
{
    [SerializeField] private GameObject _emptyObject;
    [SerializeField] private int _objectsCount = 10000;
    [SerializeField] private float _rotationSpeed = 5;

    private GameObject[] _gameObjects;

    public void Start()
    {
        _gameObjects = new GameObject[_objectsCount];
        for (int i = 0; i < _objectsCount; i++)
        {
            _gameObjects[i] = Instantiate(_emptyObject, transform.position, transform.rotation);
        }
    }

    public void Update()
    {
        for (int i = 0; i < _objectsCount; i++)
        {
            _gameObjects[i].transform.Rotate(transform.forward, Time.deltaTime * _rotationSpeed);
        }
        
    }
}
