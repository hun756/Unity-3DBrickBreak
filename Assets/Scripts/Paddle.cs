using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = System.Diagnostics.Debug;

public class Paddle : MonoBehaviour
{
    public static Paddle instance;
    public float _newSize = 2.0F;
    [Space] 
    public GameObject _center;
    public GameObject _leftCap;
    public GameObject _rightCap;
    
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
        
        ResetPaddlePosition();
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

    private void Resize(float xScale)
    {
        var initScale = _center.transform.localScale;
        initScale.x = xScale;   
        _center.transform.localScale = initScale;
        
        // resize left capacity
        var positionLeft = _leftCap.transform.position;
        var centerPos = _center.transform.position;
        var leftCapacityPos = new Vector3(centerPos.x - (xScale / 2), positionLeft.y, positionLeft.z);
        _leftCap.transform.position = leftCapacityPos;
        
        // resize right capacity
        var positionRight = _rightCap.transform.position;
        var rightCapacityPos = new Vector3(centerPos.x + (xScale / 2), positionRight.y, positionRight.z);
        _rightCap.transform.position = rightCapacityPos;
        
        // collider scale
        var colScale = initScale;
        colScale.x += 0.6F * 2;
        _bCol.size = colScale;
    }

    public void ResetPaddlePosition()
    {
        var _transform = transform;
        Debug.Assert(Camera.main != null, "Camera.main != null");
        _transform.position = new Vector3(Camera.main.transform.position.x, _transform.position.y, 0);
        Resize(_newSize);
    }
}
