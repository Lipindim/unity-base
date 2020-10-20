using UnityEngine;


public class BulletController : MonoBehaviour
{

    #region Fields

    [SerializeField] private AudioClip _hitSound;

    [SerializeField] private int _damage = 1;

    private GameObject _player;

    #endregion


    #region UnityMethods

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Player"))
        {
            var healthController = collision.gameObject.GetComponent<HealthController>();
            healthController.Hurt(_damage);
            Destroy(gameObject);
            if (_hitSound != null && _player != null)
                _player.GetComponent<AudioSource>().PlayOneShot(_hitSound);
        }
    }

    #endregion

}
