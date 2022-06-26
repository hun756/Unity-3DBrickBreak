using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Boundaries : MonoBehaviour
{
    public GameObject _leftWall, _rightWall, _topWall, _bottomWall;
    public  GameObject _lCorner, _rCorner;
    private float _distanceToCamera;
    private Vector3 _secondBoundaries;
    private Vector3 _screenPoint;
    
    private void Start()
    {
        _distanceToCamera = Camera.main.transform.position.z;
        CalculateBoundaries();
    }

    void CalculateBoundaries()
    {
        if (Camera.main != null)
        {
            var frustumHeight = 2 * _distanceToCamera * Mathf.Tan(Camera.main.fieldOfView * 0.5F * Mathf.Deg2Rad);
            var main = Camera.main;
            var frustumWidth = frustumHeight * main.aspect;

            _secondBoundaries = new Vector3(frustumWidth, frustumHeight, 0);
            var position = main.transform.position;
            _screenPoint = new Vector3(position.x, position.y, 0);
            
            // left wall..!
            var leftPoint = new Vector3(_screenPoint.x - Mathf.Abs(frustumWidth) / 2, _screenPoint.y, 0);
            _leftWall.transform.position = leftPoint;
            _leftWall.transform.localScale = new Vector3(1, Mathf.Abs(_secondBoundaries.y), 1);
            
            // right wall..!
            var rightPoint = new Vector3(_screenPoint.x + Mathf.Abs(frustumWidth) / 2, _screenPoint.y, 0);
            _rightWall.transform.position = rightPoint;
            _rightWall.transform.localScale = new Vector3(1, Mathf.Abs(_secondBoundaries.y), 1);
            
            // top wall..!
            var topPoint = new Vector3(_screenPoint.x, _screenPoint.y + Mathf.Abs(frustumHeight) / 2, 0);
            _topWall.transform.position = topPoint;
            _topWall.transform.localScale = new Vector3(Mathf.Abs(_secondBoundaries.x),1, 1);
            
            // bottom wall..!
            var backPoint = new Vector3(_screenPoint.x, _screenPoint.y - Mathf.Abs(frustumHeight) / 2, 0);
            _bottomWall.transform.position = backPoint;
            _bottomWall.transform.localScale = new Vector3(Mathf.Abs(_secondBoundaries.x),1, 1);
            
            // r corner
            _rCorner.transform.position = new Vector3(rightPoint.x, topPoint.y, 0);
            
            // l Corner
            _lCorner.transform.position = new Vector3(leftPoint.x, topPoint.y, 0); 
        }
    }
}
