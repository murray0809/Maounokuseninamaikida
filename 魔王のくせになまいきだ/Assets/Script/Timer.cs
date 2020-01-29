using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Text m_console;
    bool m_isWorking; // 動作中フラグ
    [SerializeField] float m_timer; //タイマー

    private void Start()
    {
        m_isWorking = true;
    }
    void Update()
    {
        if (m_isWorking)
        {
            m_timer -= Time.deltaTime;
            Refresh();
        }
    }

    void Refresh()
    {
        m_console.text = m_timer.ToString("F2");    // 小数点以下２桁を表示する
    }
}
