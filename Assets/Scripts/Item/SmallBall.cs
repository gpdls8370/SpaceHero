using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBall : MonoBehaviour
{
    public float plusSpeed;
    public float minusScale;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Bar")
        {
            GameObject.Find("Ball").transform.localScale = new Vector2(minusScale, minusScale);
            GameObject.Find("Bar").GetComponent<BarMove>().ballSpeed = plusSpeed;
        }
    }
}
