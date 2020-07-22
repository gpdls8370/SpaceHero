using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallMove : MonoBehaviour
{
    public int speed;
    private Rigidbody2D BallRb;

    void Start()
    {
        // speed = float.Parse(GameObject.Find("BallSpeed").GetComponent<InputField>().text);

        BallRb = GetComponent<Rigidbody2D>();
        BallRb.isKinematic = false;
        BallRb.AddForce(new Vector2(0, speed));
    }

   
    void Update()
    {
        
    }
}
