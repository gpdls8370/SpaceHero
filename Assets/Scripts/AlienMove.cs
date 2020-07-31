using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AlienMove : MonoBehaviour
{
    private Animator ani;
    private GameObject SavedAlien;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "ButtomWall")
        {
            ani = this.GetComponent<Animator>();
            ani.runtimeAnimatorController = RuntimeAnimatorController.Instantiate(Resources.Load("Ani/AlienWalk")) as RuntimeAnimatorController;
               
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().gravityScale = 0;
            GetComponent<Rigidbody2D>().velocity = new Vector2(2, 0);
        }

        else if (collision.gameObject.name == "RightWall")
        {
            GameManager.coin += 1;
            Destroy(this.gameObject);
            SavedAlien = Instantiate(Resources.Load("Prefabs/SavedAlien"), new Vector2(Random.Range(540, 680), Random.Range(45, 145)), Quaternion.identity) as GameObject;
            SavedAlien.transform.SetParent(GameObject.Find("SavedThings").transform);
        }
    }
}
