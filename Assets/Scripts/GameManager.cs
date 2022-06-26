using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public GameObject _ballPrefab;
    private List<GameObject> _ballList = new List<GameObject>();
    private List<GameObject> _brickList = new List<GameObject>();
    private int lifes;

    private void Awake()
    {
        _instance = this;
    }

    private void ResetGame()
    {
        lifes = 3;
        CreateBall();
        
        // ui update operations
    }

    private void Start()
    {
        ResetGame();
    }
    
    // life operations..
    void RemoveLife()
    {
        --lifes;
        
        // ui update operations
        
        // loose condition
        if (lifes == 0)
        {
            print("Game Over...!");
            return;
        }
        
        CreateBall();
        
        // now reset the paddle position
        Paddle.instance.ResetPaddlePosition();
    }

    public void LostBall(GameObject ball)
    {
        _ballList.Remove(ball);
        Destroy(ball);

        if (_ballList.Count == 0)
        {
            RemoveLife();
        }
    }
    
    // bricks operation
    public void AddBrick(GameObject brick)
    {
        _brickList.Add(brick);
    }

    public void RemoveBrick(GameObject brick)
    {
        _brickList.Remove(brick);
        
        // here is winning condition
        if (_brickList.Count == 0)
        {
            print("You Won..!");
        }
    }

    // creating ball
    private void CreateBall()
    {
        var o = Paddle.instance.gameObject;
        var newBall = Instantiate(_ballPrefab, o.transform, true);
        newBall.transform.position = o.transform.position + new Vector3(0, 1.5F, 0);
        newBall.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        
        _ballList.Add(newBall);
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void StartBall()
    {
        _ballList[0].GetComponent<Ball>().StartBall();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _ballList.Count > 0)
        {
            if (_ballList[0] != null && !_ballList[0].GetComponent<Ball>().BallStarted())
            {
                StartBall();
            }
        }
    }
}
