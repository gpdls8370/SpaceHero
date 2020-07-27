using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Bar")
        {
            GameObject.FindGameObjectWithTag("Ball").layer = 13;
            GameObject.Find("GhostBallTrigger").GetComponent<GhostBallTrigger>().ghostBall = true;
        }
    }
}
