using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //박스가 공이랑 부딪히면 없애기
        if(collision.gameObject.tag == "Ball")
        {
            if (this.gameObject.tag == "Stone" || this.gameObject.tag == "Ice")
            {
                Destroy(this.gameObject);
            }

            else if (this.gameObject.tag == "AlienIce")
            {
                Destroy(this.gameObject);
                Instantiate(Resources.Load("Prefabs/Alien"), new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
            }

            else if (this.gameObject.tag == "ItemIce")
            {
                Destroy(this.gameObject);
                Instantiate(Resources.Load("Prefabs/Item"), new Vector2(this.transform.position.x, this.transform.position.y), Quaternion.identity);
            }
        }
    }
}
