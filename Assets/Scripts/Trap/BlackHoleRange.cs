using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class BlackHoleRange : MonoBehaviour
{
    public float duration;

    private void Start()
    {
        StartCoroutine("sizeDown");
        StartCoroutine("spinAni");
        StartCoroutine("Duration");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            if (GameManager.ballCount > 1)
            {
                GameManager.ballCount = GameManager.ballCount - 1;
            }
            GameObject.Find("GameManager").GetComponent<Life>().minusLife(collision.gameObject);            
        }
    }

    IEnumerator sizeUp()
    {
        yield return new WaitForSeconds(0.1f);

        if (transform.localScale.x < 3.0f)
        {
            transform.localScale = new Vector2(transform.localScale.x + 0.15f, transform.localScale.y + 0.15f);
            StartCoroutine("sizeUp");
        }

        else
        {
            StartCoroutine("sizeDown");
        }
    }

    IEnumerator sizeDown()
    {
        yield return new WaitForSeconds(0.1f);
        
        if (transform.localScale.x > 0.8f)
        {
            transform.localScale = new Vector2(transform.localScale.x - 0.15f, transform.localScale.y - 0.15f);
            StartCoroutine("sizeDown");
        }

        else
        {
            StartCoroutine("sizeUp");
        }
    }

    IEnumerator spinAni()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.05f);
            transform.Rotate(new Vector3(0, 0, 10));
        }
    }

    IEnumerator Duration()
    {
        yield return new WaitForSeconds(duration);

        Destroy(this.gameObject);

        StopCoroutine("sizeUp");
        StopCoroutine("sizeDown");
        StopCoroutine("spinAni");
    }
}
