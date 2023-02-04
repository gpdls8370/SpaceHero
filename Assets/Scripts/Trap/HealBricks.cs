﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealBricks : MonoBehaviour
{
    private Animator hammerOpenAni;

    private void Start()
    {
        hammerOpenAni = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            hammerOpenAni.enabled = true;        
        }
    }

    private void healEvent()
    {
        GameObject.Find("ItemManager").transform.Find("HealRangeTrigger").gameObject.SetActive(true);
        GameObject.Find("HealRangeTrigger").transform.position = this.transform.position;
        Destroy(this.gameObject);
    }
}
