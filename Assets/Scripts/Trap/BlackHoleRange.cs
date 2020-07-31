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

        if (transform.localScale.x < 6.0f)
        {
            transform.localScale = new Vector2(transform.localScale.x + 0.4f, transform.localScale.y + 0.4f);
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
            transform.localScale = new Vector2(transform.localScale.x - 0.4f, transform.localScale.y - 0.4f);
            StartCoroutine("sizeDown");
        }

        else
        {
            StartCoroutine("sizeUp");
        }
    }

    IEnumerator Duration()
    {
        yield return new WaitForSeconds(duration);

        Destroy(this.gameObject);

        StopCoroutine("sizeUp");
        StopCoroutine("sizeDown");
    }
}
