using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public int _health = 1;
    public int _score = 50;
    void Start()
    {
        // Add the brick game manager..!
    }

    public void TakeDamage()
    {
        --_health;
        if (_health <= 0)
        {
            // create particle
            // report the game manager
            // report the score manager
            // destroy brick
            Destroy(gameObject);
        }
    }
}
