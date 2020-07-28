using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public enum KeyAction { LEFT, RIGHT, BOOST, KEYCOUNT };

// 기본: 좌측 화살표, 우측 화살표, L키
// 키셋팅 안 바뀌는 거 같으면 Game View 밖을 누른 후 한영키 누르고 재시도
public static class KeySetting
{
    public static Dictionary<KeyAction, KeyCode> keys = new Dictionary<KeyAction, KeyCode> { };
    public static KeyCode[] defaultKeys = new KeyCode[] { KeyCode.LeftArrow, KeyCode.RightArrow, KeyCode.L };
}

public class KeyManager : MonoBehaviour
{
    private void Awake()
    {
        if (KeySetting.keys.Count == 0)
        {
            for (int i = 0; i < (int)KeyAction.KEYCOUNT; i++)
            {
                KeySetting.keys.Add((KeyAction)i, KeySetting.defaultKeys[i]);
            }
        }
    }

    private void OnGUI()
    {
        Event keyEvent = Event.current;
        if (keyEvent.isKey)
        {
            if (!KeySetting.keys.ContainsValue(keyEvent.keyCode))
            {
                KeySetting.keys[(KeyAction)key] = keyEvent.keyCode;
            }
            key = -1;
        }
    }

    int key = -1;
    public void ChangeKey(int num)
    {
        key = num;
    }
}
