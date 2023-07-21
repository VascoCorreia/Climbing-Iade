using Unity.Mathematics;
using UnityEngine;

public class Pigeon : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _frequency;
    [SerializeField] private float _magnitude;
    [SerializeField] private Vector3 _localScale;
    [SerializeField] private Vector3 _position;
    [SerializeField] private Vector3[] _startPos;
    [SerializeField] private CameraMovement _camera;
    [SerializeField] private BoxCollider2D _collider;
    [SerializeField] private bool _facingRight;
    [SerializeField] private AudioClip _pigeonSoundEffect;

    private void OnEnable()
    {
        AudioManager.instance.playEffect(_pigeonSoundEffect);
    }

    void Start()
    {
        _camera = Camera.main.GetComponent<CameraMovement>();
        _localScale = transform.localScale;
        _speed = UnityEngine.Random.Range(0.7f, 1.5f);
        _frequency = UnityEngine.Random.Range(3f, 7f);
        _magnitude = UnityEngine.Random.Range(0.2f, 0.5f);

        _startPos[0] = new Vector3(-_camera._cameraBounds.x, _camera._cameraBounds.y, transform.position.z);
        _startPos[1] = new Vector3(_camera._cameraBounds.x, _camera._cameraBounds.y, transform.position.z);

        _position = _startPos[UnityEngine.Random.Range(0, 2)];

        if (_position == _startPos[0])
        {
            _facingRight = true;

            //flip sprite to face right direction
            _localScale.x *= -1;
            transform.localScale = _localScale;
        }
        else
        {
            _facingRight = false;
        }
    }

    void Update()
    {

        deleteIfOutsideView();

        if (_facingRight)
        {
            _position += transform.right * Time.deltaTime * _speed;
            transform.position = _position + transform.up * math.sin(Time.time * _frequency) * _magnitude;
        }
        else
        {
            _position -= transform.right * Time.deltaTime * _speed;
            transform.position = _position + transform.up * math.sin(Time.time * _frequency) * _magnitude;
        }
    }
    void deleteIfOutsideView()
    {
        if (_facingRight && transform.position.x - _collider.size.x / 2 > _camera._cameraBounds.x)
        {
            Destroy(gameObject);
        }
        if (!_facingRight && transform.position.x + _collider.size.x / 2 < 0 - _camera._cameraBounds.x)
        {
            Destroy(gameObject);
        }
    }
    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawLine(new Vector3(0 - _camera._cameraBounds.x, -100, 0), new Vector3(0 - _camera._cameraBounds.x , 100, 0));
    //}
}
