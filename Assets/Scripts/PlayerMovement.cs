using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private SpriteRenderer _renderer;
    private float _currentSpeed;
    private const string _playerSpeed = "speed";

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
        _rigidbody2D.freezeRotation = true;
    }

    private void Update()
    {
     
        if (Input.GetKey(KeyCode.D))
        {
            _currentSpeed = _speed * Time.deltaTime;
            transform.Translate(_currentSpeed, 0, 0);
            _animator.SetFloat(_playerSpeed, _currentSpeed);
            _renderer.flipX = false;
        }

        if(Input.GetKey(KeyCode.A))
        {
            _currentSpeed = _speed * Time.deltaTime;
            transform.Translate(_currentSpeed * -1, 0, 0);
            _animator.SetFloat(_playerSpeed, _currentSpeed);
            _renderer.flipX = true;
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(0, 2, 0);
        }
    }
}
