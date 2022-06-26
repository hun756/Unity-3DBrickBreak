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
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        
        // debugging
        _rb.AddForce(new Vector3(0 ,_initialForce, 0));    
    }

    private void OnCollisionEnter(Collision collision)
    {
        var brick = collision.gameObject.GetComponent<Brick>();
        if (brick != null)
        {
            brick.TakeDamage();
        }
        else
        {
            Debug.Log("Brick is null..!");
        }
    }
}