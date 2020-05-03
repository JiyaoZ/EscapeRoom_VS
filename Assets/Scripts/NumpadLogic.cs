using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;

public class NumpadLogic : MonoBehaviour
{
    //赢游戏的条件
    public string winCode = "4236";
    //用于跟踪目前玩家输入的数字
    protected string currentCode = "0000";
    //用于在玩家赢了游戏的时候触发关联的脚本，让玩家赢游戏（会在Inspector上显示关联触发动作的界面）
    public UnityEvent onWin;
    //在屏幕上显示输入的数字
    public TMPro.TextMeshProUGUI display;


    void Awake() {
        currentCode = display.text;
    }

    //按钮触发代码
    public void ButtonPressed(int val) {
        currentCode = currentCode.Substring(1) + val.ToString();
        display.text = currentCode;

        if (currentCode == winCode) {
            Debug.Log("WINNER!");
            if (onWin != null) {
                onWin.Invoke();
            }
        }
    }
}
