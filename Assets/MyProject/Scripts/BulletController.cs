using Cinemachine;
using UnityEngine;


public class BulletController : MonoBehaviour
{
    [SerializeField] private int _damage = 1;
    [SerializeField] private AudioClip _hitSound;

    private GameObject _player;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Player"))
        {
            
            var enemy = collision.gameObject.GetComponent<HealthController>();
            enemy.Hurt(_damage);
            Destroy(gameObject);
            if (_hitSound != null && _player != null)
                _player.GetComponent<AudioSource>().PlayOneShot(_hitSound);
        }
    }

}
