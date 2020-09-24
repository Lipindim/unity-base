using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private int _damage = 1;
    [SerializeField] private AudioClip _hitSound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            var enemy = other.GetComponent<Enemy>();
            enemy.Hurt(_damage);
            Destroy(gameObject);
            var player = GameObject.FindGameObjectWithTag("Player");
            if (_hitSound != null && player != null)
                player.GetComponent<AudioSource>().PlayOneShot(_hitSound);
        }
    }
}
