using System;
using UnityEngine;

public class CharacterDeath : MonoBehaviour
{
    [SerializeField] private CharacterMovement _movementScript;
    [SerializeField] private LevelManager _levelManager;
    [SerializeField] private BoxCollider2D _collider;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _cameraDeathMargin;

    public event Action deathEvent;

    public bool isDead;

    private void Awake()
    {
        isDead = false;
    }

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        //Down (dies)
        if (transform.position.y + _collider.bounds.extents.y + _cameraDeathMargin <= _camera.transform.position.y - _camera.orthographicSize && !isDead)
        {
            Death();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Obstacle" && !isDead)
        {
            Death();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle" && !isDead)
        {
            Death();
        }
    }

    public void Death()
    {
        isDead = true;

        deathEvent?.Invoke();

        if (_movementScript != null)
        {
            _movementScript._slideDownSpeed = 1.5f;
            _movementScript._acceleration = 0;
        }

        if (_levelManager != null)
        {
            _levelManager.fadeOutToLevel(1);
        }
    }

}
