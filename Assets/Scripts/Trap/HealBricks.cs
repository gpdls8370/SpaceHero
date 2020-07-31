using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBricks : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            GameObject.Find("ItemManager").transform.Find("HealRangeTrigger").gameObject.SetActive(true);
            GameObject.Find("HealRangeTrigger").transform.position = this.transform.position;
            Destroy(this.gameObject);
        }
    }
}
