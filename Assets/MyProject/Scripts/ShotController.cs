using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour
{
    [SerializeField] private GameObject _spawnObject;
    [SerializeField] private Transform _spawnPoint;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject gameObject = Instantiate(_spawnObject, _spawnPoint.position, _spawnPoint.rotation);
            gameObject.GetComponent<Rigidbody>().AddForce((gameObject.transform.up + gameObject.transform.forward)* 200);
        }
    }
}
