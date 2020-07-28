using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MainScene에서 경고를 보여줄 목록을 추가했으면 Alerted.defaultThings를 반드시 수정할 것
// Stone은 임시로 넣어둠
public static class Alerted
{
    public static Dictionary<string, bool> Things = new Dictionary<string, bool> { };
    public static string[] defaultThings = new string[] { "Stone" };
}

public class AlertManager : MonoBehaviour
{
    public static bool isAlert;

    private void Awake()
    {
        isAlert = false;

        if (Alerted.Things.Count != Alerted.defaultThings.Length)
        {
            for (int i = Alerted.Things.Count; i < Alerted.defaultThings.Length; i++)
            {
                Alerted.Things.Add(Alerted.defaultThings[i], false);
            }
        }
    }
}
