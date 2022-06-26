using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public static Paddle instance;
    private Rigidbody _rb;
    private BoxCollider _bCol;
    
    [SerializeField]
    private float _speed = 10.0F;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _bCol = GetComponent<BoxCollider>();
        
    }
    
    private void FixedUpdate()
    {
        float h = Input.GetAxis("Horizontal");
        if ((int)h == 0 && _rb.velocity != Vector3.zero)
        {
            _rb.velocity = Vector3.zero;
        }
        
        _rb.MovePosition(transform.position + new Vector3(h, 0, 0) * (_speed * Time.fixedDeltaTime));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody ballRb = collision.gameObject.GetComponent<Rigidbody>();
            float vel = Ball._initialForce;
            var hitPoint = collision.contacts[0].point;
            float difference = transform.position.x - hitPoint.x;

            if (hitPoint.x < transform.position.x)
            {
                ballRb.AddForce(new Vector3(-(Mathf.Abs(difference * 200)), vel, 0));
            }
            else
            {
                ballRb.AddForce(new Vector3((Mathf.Abs(difference * 200)), vel, 0));
            }
        }
    }
}
