using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    public int speed;
    private Rigidbody2D BallRb;

    void Start()
    {
        BallRb = GetComponent<Rigidbody2D>();
        BallRb.isKinematic = false;
        BallRb.AddForce(new Vector2(0, speed));
    }

   
    void Update()
    {
        
    }
}
