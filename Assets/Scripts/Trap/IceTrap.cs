using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceTrap : MonoBehaviour
{
    private Rigidbody2D ballRb;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            ballRb = collision.gameObject.GetComponent<Rigidbody2D>();
            ballRb.velocity = Vector2.zero;
            ballRb.gravityScale = 1;
            GameManager.ballisIceTraped = true;
        }
    }
}
