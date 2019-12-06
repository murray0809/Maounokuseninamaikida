using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{

    [SerializeField] public int Hp = 10; //HP
    [SerializeField] public int Atk = 1; //攻撃力
    [SerializeField] public int Def = 0; //防御力
    //[SerializeField] float m_moveSpeed = 5f;  //プレイヤーの移動速度
    Rigidbody2D m_rb2d;
    [SerializeField] GameObject attack = default;
    [SerializeField] Text m_Text = default;

    Vector3 MOVEX = new Vector3(0.64f, 0, 0); // x軸方向に１マス移動するときの距離
    Vector3 MOVEY = new Vector3(0, 0.64f, 0); // y軸方向に１マス移動するときの距離

    float step = 2f;     // 移動速度
    Vector3 target;      // 入力受付時、移動後の位置を算出して保存 
    Vector3 prevPos;     // 何らかの理由で移動できなかった場合、元の位置に戻すため移動前の位置を保存

    Animator animator;   // アニメーション
    void Start()
    {
        m_rb2d = GetComponent<Rigidbody2D>();
        target = transform.position;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // ① 移動中かどうかの判定。移動中でなければ入力を受付
        if (transform.position == target)
        {
            SetTargetPosition();
        }
        Move();

        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            Attack();
        }
        else
        {
            attack.SetActive(false);
        }
    }

    void SetTargetPosition()
    {

        prevPos = target;

        if (Input.GetKey(KeyCode.D))
        {
            target = transform.position + MOVEX;
            return;
        }
        if (Input.GetKey(KeyCode.A))
        {
            target = transform.position - MOVEX;
            return;
        }
        if (Input.GetKey(KeyCode.W))
        {
            target = transform.position + MOVEY;
            return;
        }
        if (Input.GetKey(KeyCode.S))
        {
            target = transform.position - MOVEY;
            return;
        }
    }

    // ③ 目的地へ移動する
    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, step * Time.deltaTime);
    }

    void Attack()
    {
        attack.SetActive(true);
        Debug.Log("攻撃した");
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Item HP")
        {
            Hp++;
            Debug.Log("HPが1増えた");
            if (m_Text)   
            {
                m_Text.text = "HPが1増えた";  
            }
        }

        if (col.gameObject.tag == "Item ATK")
        {
            Atk++;
            Debug.Log("ATKが1増えた");
            if (m_Text)
            {
                m_Text.text = "ATKが1増えた";
            }
        }

        if (col.gameObject.tag == "Item DEF")
        {
            Def++;
            Debug.Log("DEFが1増えた");
            if (m_Text)
            {
                m_Text.text = "DEFが1増えた";
            }
        }
    }
}