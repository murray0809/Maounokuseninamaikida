using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timeScript : MonoBehaviour
{
    GameObject limitTimeUI;
    float time = 300.0f;

    // Use this for initialization
    void Start()
    {
        limitTimeUI = GameObject.Find("LimitTimeUI");
    }

    void Update()
    {
        // 毎フレーム毎に残り時間を減らしていく
        time -= Time.deltaTime;
        if (time < 0)
        {
            limitTimeUI.GetComponent<Text>().text = "終了";
        }
        else
        {
            // timeを文字列に変換したものをテキストに表示する
            // ToStringのF1とは、小数点以下1桁までという意味
            limitTimeUI.GetComponent<Text>().text = time.ToString("F1");
        }
    }
}