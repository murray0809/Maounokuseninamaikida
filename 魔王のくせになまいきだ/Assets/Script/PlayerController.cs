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

    [SerializeField] public Text m_Text1 = default;
    [SerializeField] public Text m_Text2 = default;
    [SerializeField] public Text m_Text3 = default;

    [SerializeField] public Text text = default;

    Vector3 MOVEX = new Vector3(1f, 0, 0); // x軸方向に１マス移動するときの距離
    Vector3 MOVEY = new Vector3(0, 1f, 0); // y軸方向に１マス移動するときの距離

    float step = 2f;     // 移動速度
    Vector3 target;      // 入力受付時、移動後の位置を算出して保存 
    Vector3 prevPos;     // 何らかの理由で移動できなかった場合、元の位置に戻すため移動前の位置を保存

    Animator animator;   // アニメーション

    bool objN = true;
    bool objS = true;
    bool objE = true;
    bool objW = true;
    void Start()
    {
        m_rb2d = GetComponent<Rigidbody2D>();
        target = transform.position;
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Ray();

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

        if (Input.GetKey(KeyCode.D) && objE)
        {
            target = transform.position + MOVEX;
            return;
        }
        if (Input.GetKey(KeyCode.A) && objW)
        {
            target = transform.position - MOVEX;
            return;
        }
        if (Input.GetKey(KeyCode.W) && objN)
        {
            target = transform.position + MOVEY;
            return;
        }
        if (Input.GetKey(KeyCode.S) && objS)
        {
            target = transform.position - MOVEY;
            return;
        }
        return;
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
            if (m_Text3)
            {
                text.text = "HPが1増えた";
                LogSet();
            }
        }

        if (col.gameObject.tag == "Item ATK")
        {
            Atk++;
            Debug.Log("ATKが1増えた");
            if (m_Text3)
            {
                text.text = "ATKが1増えた";
                LogSet();
            }
        }

        if (col.gameObject.tag == "Item DEF")
        {
            Def++;
            Debug.Log("DEFが1増えた");
            if (m_Text3)
            {
                text.text = "DEFが1増えた";
                LogSet();
            }
        }
    }
    void LogSet()
    {
        m_Text1.text = m_Text2.text;
        m_Text2.text = m_Text3.text;
        m_Text3.text = text.text;
    }

    void Ray()
    {
       
        int layerMask = LayerMask.GetMask(new string[] { "wall", "Enemy" });
        Ray2D rayN = new Ray2D(this.transform.position + new Vector3(0, 0.5f,0), transform.up);
        Ray2D rayS = new Ray2D(this.transform.position + new Vector3(0, -0.5f, 0), transform.up * -1);
        Ray2D rayE = new Ray2D(this.transform.position + new Vector3(0.5f, 0, 0), transform.right);
        Ray2D rayW = new Ray2D(this.transform.position + new Vector3(-0.5f, 0, 0), transform.right * -1);
        RaycastHit2D hitN = Physics2D.Raycast(rayN.origin, rayN.direction, 0.5f, layerMask);
        RaycastHit2D hitS = Physics2D.Raycast(rayS.origin, rayS.direction, 0.5f, layerMask);
        RaycastHit2D hitE = Physics2D.Raycast(rayE.origin, rayS.direction, 0.5f, layerMask);
        RaycastHit2D hitW = Physics2D.Raycast(rayW.origin, rayS.direction, 0.5f, layerMask);
        Debug.DrawLine(this.transform.position + new Vector3(0, 0.5f, 0), this.transform.position + transform.up);
        Debug.DrawLine(this.transform.position + new Vector3(0, -0.5f, 0), this.transform.position + transform.up * -1);
        Debug.DrawLine(this.transform.position + new Vector3(0.5f, 0, 0), this.transform.position + transform.right);
        Debug.DrawLine(this.transform.position + new Vector3(-0.5f, 0, 0), this.transform.position + transform.right * -1);
        if (hitN)
        {
            Debug.Log(hitN.transform.name);
            objN = false;
        }
        else
        {
            objN = true;
        }
        if (hitS)
        {
            Debug.Log(hitS.transform.name);
            objS = false;
        }
        else
        {
            objS = true;
        }
        if (hitE)
        {
            Debug.Log(hitE.transform.name);
            objE = false;
        }
        else
        {
            objE = true;
        }
        if (hitW)
        {
            Debug.Log(hitW.transform.name);
            objW = false;
        }
        else
        {
            objW = true;
        }
        
    }
}