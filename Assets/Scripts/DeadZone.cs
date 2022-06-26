using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // triggered
        // Debug.Log("Trigger");
        // Debug.Log(other.gameObject);
        
        if (other.CompareTag("Ball"))
        {
            GameManager._instance.LostBall(other.gameObject);
        }
    }
}
