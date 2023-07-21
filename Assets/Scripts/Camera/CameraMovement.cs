using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Camera _cameraComponent;

    public Vector3 _cameraBounds;
    void Update()
    {
        _cameraBounds = _cameraComponent.ScreenToWorldPoint(new Vector3(Screen.width, _cameraComponent.transform.position.y + Screen.height, _cameraComponent.transform.position.z));
    }
    void FixedUpdate()
    {
        transform.position += new Vector3(0, _speed, 0) * Time.fixedDeltaTime;
    }
}
