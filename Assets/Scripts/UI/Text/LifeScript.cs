using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeScript : MonoBehaviour
{
    public Text currentLife;

    void Start()
    {
        currentLife.text = GameManager.currentLife.ToString();
    }

    void Update()
    {
        currentLife.text = GameManager.currentLife.ToString();
    }
}
