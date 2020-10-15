using UnityEngine;


public class OpenDoorController : MonoBehaviour
{

    #region Fields

    [SerializeField] private GameObject _toggledGameObject;

    #endregion

    #region UnityMethods

    private void OnTriggerEnter(Collider other)
    {
        var animator =_toggledGameObject.GetComponent<Animator>();
        animator.SetTrigger("Open");
    }

    #endregion

}
