using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody _rb;
    
    [SerializeField]
    public static float _initialForce = 600.0F;

    private bool _ballStarted;
        
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        
        // debugging   
    }

    private void OnCollisionEnter(Collision collision)
    {
        var brick = collision.gameObject.GetComponent<Brick>();
        if (brick != null)
        {
            brick.TakeDamage();
        }
    }

    public void StartBall()
    {
        if (_ballStarted) return;
        _rb.isKinematic = false;
        _rb.AddForce(new Vector3(_initialForce ,_initialForce, 0));
        _ballStarted = true;
        
        // parent back to the world...!
        transform.SetParent(transform.parent.parent);
    }

    public bool BallStarted()
    {
        return _ballStarted;
    }
}