using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBall : MonoBehaviour
{
    public float minusSpeed;
    public float plusScale;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Bar")
        {
            GameObject.Find("Ball").transform.localScale = new Vector2(plusScale, plusScale);
            GameObject.Find("Bar").GetComponent<BarMove>().ballSpeed = minusSpeed;
        }
    }
}
