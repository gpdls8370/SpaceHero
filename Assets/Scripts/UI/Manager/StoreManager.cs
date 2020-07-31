using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// StoreScene에서 상점에 목록을 추가했으면 Store.defaultThings를 반드시 수정할 것
// 그리고 ChangeSell()의 가장 내부에 있는 if문을 복붙한 후 if문의 조건문과 Find 함수의 매개변수를 반드시 수정할 것 (아래 예시 참조)
// 폭탄과 생명 모두 임시로 넣어둠
public static class Store
{
    public static Dictionary<string, bool> Things = new Dictionary<string, bool> { };
    public static List<string> unlockItem = new List<string>();
    public static string[] defaultThings = new string[] { "폭탄", "생명" };     //추가 아이템 이름 : 분열, 유령, 공작게, 공크게, 바짧게, 바길게
}

public class StoreManager : MonoBehaviour
{
    private void Awake()
    {
        if (Store.Things.Count != Store.defaultThings.Length)
        {
            for (int i = Store.Things.Count; i < Store.defaultThings.Length; i++)
            {
                Store.Things.Add(Store.defaultThings[i], false);
            }
        }
    }

    public static void ChangeSell()
    {
        for (int i = 0; i < Store.Things.Count; i++)
        {
            if (Store.Things[Store.defaultThings[i]] == true)
            {
                if (Store.defaultThings[i] == "폭탄")
                {
                    GameObject Button = GameObject.Find("BombButton");
                    Button.GetComponent<CanvasGroup>().alpha = 0.5f;
                    Destroy(Button.GetComponent<Button>());
                }
                if (Store.defaultThings[i] == "생명")
                {
                    GameObject Button = GameObject.Find("HeartButton");
                    Button.GetComponent<CanvasGroup>().alpha = 0.5f;
                    Destroy(Button.GetComponent<Button>());
                }
            }
        }
    }
}
