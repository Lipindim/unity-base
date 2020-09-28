using UnityEngine;


public class KeyboardController : MonoBehaviour
{
    private ShotController _shotController;

    private void Start()
    {
        _shotController = GetComponent<ShotController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _shotController.Shot();
        }
    }
}
