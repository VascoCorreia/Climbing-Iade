using System;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] public float _acceleration;
    [SerializeField] public float _slideDownSpeed;
    [SerializeField] private SpriteRenderer _building;
    [SerializeField] private Camera _camera;
    [SerializeField] private CameraMovement _cameraMovementScript;
    [SerializeField] private BoxCollider2D _collider;
    [SerializeField] private Animator _animator;
    [SerializeField] private CharacterDeath _deathScript;

    private Dictionary<string, float> _buildingBounds;
    private Vector3 _velocity;

    public bool _isSliding;
    public bool _isSlidingTrigger;
    public event Action isSlidingEvent;

    void Start()
    {
        _isSliding = false;
        _cameraMovementScript = _camera.GetComponent<CameraMovement>();

        _buildingBounds = new Dictionary<string, float>();

        //Building
        _buildingBounds.Add("left", _building.transform.position.x - _building.size.x / 2);
        _buildingBounds.Add("right", _building.transform.position.x + _building.size.x / 2);

    }

    void FixedUpdate()
    {
        characterMovement();
        setMovementBoundaries();
    }

    void characterMovement()
    {
        float xAxis = Input.GetAxis("Horizontal") * _acceleration;
        float yAxis = Input.GetAxis("Vertical") * _acceleration;

        _velocity = new Vector3(xAxis, yAxis, 0);

        //if stopped slide down
        if (xAxis == 0 && yAxis == 0)
        {
            //if(!_isSlidingTrigger)
            //{
            //    isSlidingEvent?.Invoke();
            //}
            _isSliding = true;
           
            //_isSlidingTrigger = true;

            transform.position -= new Vector3(0, _slideDownSpeed, 0) * Time.fixedDeltaTime;
        }
        else
        {
            _isSliding = false;
            transform.position += _velocity * Time.fixedDeltaTime;
        }

        if(_animator != null)
        {
            _animator.SetFloat("speed", _velocity.magnitude);
        }
    }

    void setMovementBoundaries()
    {
        //Set movement left right up and down Boundaries
        if (_building != null && _camera != null && _collider != null)
        {
            //Left
            if (transform.position.x - _collider.bounds.extents.x <= _buildingBounds["left"])
            {
                transform.position = new Vector3((_buildingBounds["left"] + _collider.bounds.extents.x), transform.position.y, transform.position.z);
            }

            //Right
            if (transform.position.x + _collider.bounds.extents.x >= _buildingBounds["right"])
            {
                transform.position = new Vector3((_buildingBounds["right"] - _collider.bounds.extents.x), transform.position.y, transform.position.z);
            }

            //Up
            if (transform.position.y /*+ _collider.bounds.extents.y*/ >= _cameraMovementScript._cameraBounds.y)
            {
                transform.position = new Vector3(transform.position.x, _cameraMovementScript._cameraBounds.y /*- _collider.bounds.extents.y*/, transform.position.z);
            }
        }
    }
}

