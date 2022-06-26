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
        _rb.AddForce(new Vector3(0 ,_initialForce, 0));    
    }
}