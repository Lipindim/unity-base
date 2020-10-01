using UnityEngine;


public class ObjectDeactivator : MonoBehaviour
{
    [SerializeField] private GameObject _toggledGameObject;

    private void OnTriggerEnter(Collider other)
    {
        _toggledGameObject.SetActive(false);
        print($"На меня наступил {other.gameObject.name}");
    }

    private void OnTriggerExit(Collider other)
    {
        _toggledGameObject.SetActive(true);
    }
}
