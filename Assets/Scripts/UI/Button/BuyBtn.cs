using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuyBtn : MonoBehaviour
{
    public GameObject buyCanvas;
    public GameObject buyName;
    public GameObject buyPrice;

    private string thingsName;
    private int thingsPrice;

    public void TryingBuy()
    {
        thingsName = buyName.GetComponent<Text>().text;
        thingsPrice = int.Parse(buyPrice.GetComponent<Text>().text);

        if (GameManager.coin >= thingsPrice)
        {
            GameManager.coin -= thingsPrice;
            Store.Things[thingsName] = true;
            StoreManager.ChangeSell();
        }
        else
        {
            // 구매할 수 없다는 내용이 나오면 좋을 듯
        }

        buyCanvas.SetActive(false);
    }

    public void TryingCancel()
    {
        buyCanvas.SetActive(false);
    }
}
