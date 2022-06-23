using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class EnemyPatroller : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform _wayPoints;

    private SpriteRenderer _renderer;
    private Transform[] _points;
    private int _currentPoint;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();

        _points = new Transform[_wayPoints.childCount];

        for (int i = 0; i < _wayPoints.childCount; i++)
        {
            _points[i] = _wayPoints.GetChild(i);
        }

        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        while (true)
        {
            Transform targetPoint = _points[_currentPoint];


            transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, _speed * Time.deltaTime);

            if(transform.position == targetPoint.position)
            {
                _currentPoint++;
                
                if(_currentPoint == _points.Length)
                {
                    _currentPoint = 0;
                }
            }
           
            yield return null;
        }
    }
}