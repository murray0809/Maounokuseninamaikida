using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{

    [SerializeField] int Hp = 100; //HP
    [SerializeField] int Atk = 30; //攻撃力
    [SerializeField] int Def = 25; //防御力
    [SerializeField] float m_moveSpeed = 5f;  //プレイヤーの移動速度
    Rigidbody2D m_rb2d;
    [SerializeField] GameObject attack;

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
            attack.SetActive(true);
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
            SetAnimationParam(1);
            return;
        }
        if (Input.GetKey(KeyCode.A))
        {
            target = transform.position - MOVEX;
            SetAnimationParam(2);
            return;
        }
        if (Input.GetKey(KeyCode.W))
        {
            target = transform.position + MOVEY;
            SetAnimationParam(3);
            return;
        }
        if (Input.GetKey(KeyCode.S))
        {
            target = transform.position - MOVEY;
            SetAnimationParam(0);
            return;
        }
    }

    void SetAnimationParam(int param)
    {
        animator.SetInteger("WalkParam", param);
    }

    // ③ 目的地へ移動する
    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, step * Time.deltaTime);
    }
}