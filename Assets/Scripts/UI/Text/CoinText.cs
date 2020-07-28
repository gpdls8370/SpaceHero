using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinText : MonoBehaviour
{
    public Text coinNum;
    void Start()
    {
        coinNum.text = GameManager.coin.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        coinNum.text = GameManager.coin.ToString();
    }
}
