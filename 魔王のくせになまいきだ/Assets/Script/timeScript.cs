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
        this.limitTimeUI = GameObject.Find("LimitTimeUI");
    }

    void Update()
    {
        // 毎フレーム毎に残り時間を減らしていく
        this.time -= Time.deltaTime;
        if (this.time < 0)
        {
            this.limitTimeUI.GetComponent<Text>().text = "終了";
        }
        else
        {
            // timeを文字列に変換したものをテキストに表示する
            // ToStringのF1とは、小数点以下1桁までという意味
            this.limitTimeUI.GetComponent<Text>().text = this.time.ToString("F1");
        }
    }
}