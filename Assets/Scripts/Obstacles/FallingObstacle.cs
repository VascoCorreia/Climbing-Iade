using UnityEngine;

public class FallingObstacle : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private SpriteRenderer _building;
    [SerializeField] private Rigidbody2D _rb;

    private float _rotationDirection;
    void Start()
    {
        _rotationDirection = Random.Range(-200f, 200f);
        _camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        _building = GameObject.FindGameObjectWithTag("Building").GetComponent<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();

        transform.position = new Vector3(Random.Range((_building.size.x / 2 * -1) + transform.localScale.x, (_building.size.x / 2) - transform.localScale.x),
                                                       _camera.transform.position.y + _camera.orthographicSize + transform.localScale.y, transform.position.z);


        _rb.gravityScale = Random.Range(0.05f, 0.4f);
    }

    void Update()
    {
        Rotation();
        if (transform.position.y + transform.localScale.y / 2 <= _camera.transform.position.y - _camera.orthographicSize)
        {
            Destroy(gameObject);
        }
    }

    void Rotation()
    {
        transform.Rotate(0, 0, _rotationDirection * Time.deltaTime);
    }
}
