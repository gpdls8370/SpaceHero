using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fast : MonoBehaviour
{
    public float duration;  //지속시간

    private Animator fastBrickAni;

    private void Start()
    {
        fastBrickAni = GetComponent<Animator>();
    }

    private void fastAniEvent()
    {
        Destroy(this.gameObject);
        fastEvent();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            fastBrickAni.enabled = true;           
        }
    }

    private void fastEvent()
    {
        GameObject.Find("BrickManager").GetComponent<BrickSpawn>().nowFallTime = GameObject.Find("BrickManager").GetComponent<BrickSpawn>().nowFallTime / 2;
        if (GameObject.Find("BrickManager").GetComponent<BrickSpawn>().nowFallTime <= 1.0f) //1초 아래로는 안내려감
        {
            GameObject.Find("BrickManager").GetComponent<BrickSpawn>().nowFallTime = GameObject.Find("BrickManager").GetComponent<BrickSpawn>().nowFallTime * 2;
        }
        else
        {
            StartCoroutine("fastTime");
        }
    }

    IEnumerator fastTime()
    {
        yield return new WaitForSeconds(duration);

        GameObject.Find("BrickManager").GetComponent<BrickSpawn>().nowFallTime = GameObject.Find("BrickManager").GetComponent<BrickSpawn>().nowFallTime * 2;
    }
}
