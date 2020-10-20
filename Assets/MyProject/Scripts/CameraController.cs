using UnityEngine;


public class CameraController : MonoBehaviour
{

    #region Fields

    [SerializeField] private GameObject _trackingObject;

    private float xOffset;
    private float zOffset;

    #endregion


    #region UnityMethods

    private void Start()
    {
        xOffset = _trackingObject.transform.position.x - transform.position.x;
        zOffset = _trackingObject.transform.position.z - transform.position.z;
    }

    private void Update()
    {
        MoveCamera();
    }

    #endregion


    #region Methods

    private void MoveCamera()
    {
        float x = _trackingObject.transform.position.x - xOffset;
        float z = _trackingObject.transform.position.z - zOffset;
        transform.position = new Vector3(x, transform.position.y, z);
    }

    #endregion

}
