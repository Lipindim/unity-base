using System;
using UnityEngine;


public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _spawnObject;
    [SerializeField] private Transform _spawnPoint;
    
    public GameObject Spawn()
    {
        if (_spawnObject == null)
            throw new ArgumentNullException("Spawn object isn't set.");
        if (_spawnPoint == null)
            throw new ArgumentNullException("Spawn point isn't set.");

        return Instantiate(_spawnObject, _spawnPoint.position, _spawnPoint.rotation);
    }
}
