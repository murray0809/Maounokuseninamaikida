using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{

    [SerializeField] float m_moveSpeed = 5f;  //プレイヤーの移動速度
    Rigidbody2D m_rb2d;
    void Start()
    {
        m_rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // 自機を移動させる
        float h = Input.GetAxisRaw("Horizontal");   // 垂直方向の入力を取得する
        float v = Input.GetAxisRaw("Vertical");     // 水平方向の入力を取得する
        Vector2 dir = new Vector2(h, v).normalized; // 進行方向の単位ベクトルを作る (dir = direction) 
        m_rb2d.velocity = dir * m_moveSpeed;        // 単位ベクトルにスピードをかけて速度ベクトルにして、それを Rigidbody の速度ベクトルとしてセットする
    }
}
