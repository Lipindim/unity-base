using UnityEngine;


public class PlayerObserver : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("Я нашёл тебя!");
        }
    }
}
