using System.IO;
using UnityEngine;


public class Exploder : MonoBehaviour
{
    [SerializeField] private AudioClip _exploseSound;
    [SerializeField] private float _explosePower = 3000;
    [SerializeField] private float _exploseDamage = 3;
    [SerializeField] private float _exploseRadius = 5;

    private GameObject _player;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Player"))
        {
            PlayExploseSound();

            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var enemy in enemies)
                ContactWithMine(enemy);
            ContactWithMine(_player);
            Destroy(gameObject);

        }
    }


    private void ContactWithMine(GameObject contactingObject)
    {
        Vector3 directionToGameObject = contactingObject.transform.position - transform.position;
        if (directionToGameObject.sqrMagnitude < _exploseRadius * _exploseRadius)
        {
            contactingObject.GetComponent<Rigidbody>().AddForce(directionToGameObject * _explosePower);
            var healthController = contactingObject.GetComponent<HealthController>();
            if (healthController != null)
                healthController.Hurt(_exploseDamage);
        }
    }

    private void PlayExploseSound()
    {
        if (_exploseSound != null && _player != null)
            _player.GetComponent<AudioSource>().PlayOneShot(_exploseSound);
    }
}
