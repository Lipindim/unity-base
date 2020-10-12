using UnityEngine;


public class ObjectDeactivator : MonoBehaviour
{
    [SerializeField] private GameObject _toggledGameObject;

    private void OnTriggerEnter(Collider other)
    {
        //_toggledGameObject.SetActive(false);
        print($"На меня наступил {other.gameObject.name}");
        var animator =_toggledGameObject.GetComponent<Animator>();
        animator.SetTrigger("Open");
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Backspace))
    //    {
    //        var animator = _toggledGameObject.GetComponent<Animator>();
    //        animator.SetTrigger("Open");
    //    }
    //}

    private void OnTriggerExit(Collider other)
    {
        //_toggledGameObject.SetActive(true);
    }
}
