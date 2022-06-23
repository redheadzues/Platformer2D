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
    private static int _playerSpeed = Animator.StringToHash("Speed");
    
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
        _rigidbody2D.freezeRotation = true;
    }

    private void SetPlayerMoveParametrs(float speed, bool isFlip)
    {
        _currentSpeed = speed * Time.deltaTime;
        _renderer.flipX = isFlip;
        _animator.SetFloat(_playerSpeed, _currentSpeed);        
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.D))
        {
            SetPlayerMoveParametrs(_speed, false);
        }

        if (Input.GetKey(KeyCode.D))
        {                       
           transform.Translate(_currentSpeed, 0, 0);
        }

        if(Input.GetKey(KeyCode.A))
        {
            SetPlayerMoveParametrs(_speed, true);
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(_currentSpeed * -1, 0, 0);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(0, 2, 0);
        }

        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            SetPlayerMoveParametrs(0, false);
        }
    }
}
