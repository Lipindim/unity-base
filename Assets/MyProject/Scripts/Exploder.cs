using UnityEngine;


public class Exploder : MonoBehaviour
{
    [SerializeField] private AudioClip _exploseSound;
    [SerializeField] private float _explosePower = 3000;
    [SerializeField] private float _exploseDamage = 3;

    private GameObject _player;

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Player"))
        {
            if (_exploseSound != null && _player != null)
                _player.GetComponent<AudioSource>().PlayOneShot(_exploseSound);
            collision.gameObject.GetComponent<Rigidbody>().AddExplosionForce(_explosePower, transform.position, 10);
            var healthController = collision.gameObject.GetComponent<HealthController>();
            if (healthController != null)
                healthController.Hurt(_exploseDamage);
            Destroy(gameObject);

        }
    }
}
