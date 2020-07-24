using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongBar : MonoBehaviour
{

    public float plusScale;     //바꿀 스케일 값(고정값)
    public float minusSpeed;    //바꿀 속도 값


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Bar")
        {
            collision.gameObject.transform.localScale = new Vector2(plusScale, collision.gameObject.transform.localScale.y);
            collision.gameObject.GetComponent<BarMove>().speed = minusSpeed;
        }
    }
}
