using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float incrementalSpeed = 1.0f;
    
    private Rigidbody2D _rigidbody2D;
    private Vector3 _direction;
    private float _initialSpeed;

    private const float DEVIATION = 10.0f;
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _initialSpeed = speed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        _direction = Quaternion.Euler(0, 0, RandomDeviation()) * _rigidbody2D.velocity.normalized;
        _rigidbody2D.velocity = _direction * speed;
        
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Obstacle"))
        {
            speed += incrementalSpeed;
            _rigidbody2D.velocity = _rigidbody2D.velocity.normalized * speed;
        }
    }
    public void Initiate(Transform direction)
    {
        transform.position = direction.position;
        speed = _initialSpeed;
        _direction = direction.up;
        _rigidbody2D.velocity = new Vector2(_direction.x, _direction.y) * speed;
    }
    private float RandomDeviation()
    {
        return Random.Range(-DEVIATION, DEVIATION);
    }
}
