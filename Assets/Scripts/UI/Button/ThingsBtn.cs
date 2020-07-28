using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThingsBtn : MonoBehaviour
{
    public GameObject buyCanvas;
    public GameObject buyName;
    public GameObject buyImage;
    public GameObject buyPrice;

    public void ThingsClicked()
    {
        buyName.GetComponent<Text>().text = gameObject.transform.Find("Name").GetComponent<Text>().text;
        buyImage.GetComponent<Image>().sprite = gameObject.transform.Find("Image").GetComponent<Image>().sprite;
        buyPrice.GetComponent<Text>().text = gameObject.transform.Find("Price").GetComponent<Text>().text;

        buyCanvas.SetActive(true);
    }
}
