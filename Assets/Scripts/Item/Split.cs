using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Split : MonoBehaviour
{
    GameObject originalBall;
    GameObject[] splitBalls;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Bar")
        {
            GameManager.ballCount = GameManager.ballCount + 7;

            originalBall = GameObject.FindGameObjectWithTag("Ball");
            splitBalls = new GameObject[8];

            for(int i = 0; i < 8; i++)
            {
                splitBalls[i] = Instantiate(Resources.Load("Prefabs/Item/SplitBall"), originalBall.transform.position, Quaternion.identity) as GameObject;
                splitBalls[i].transform.rotation = Quaternion.Euler(0, 0, 45 * i);
                splitBalls[i].gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
                splitBalls[i].gameObject.GetComponent<Rigidbody2D>().AddForce(splitBalls[i].transform.right * collision.gameObject.GetComponent<BarMove>().ballSpeed);
            }

           Destroy(originalBall.gameObject);
        }
    }
}
