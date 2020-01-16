using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{

    [SerializeField] public static int Hp = 10; //HP
    [SerializeField] public static int Atk = 1; //攻撃力
    [SerializeField] public static int Def = 0; //防御力
    //[SerializeField] float m_moveSpeed = 5f;  //プレイヤーの移動速度
    Rigidbody2D m_rb2d;
    [SerializeField] GameObject attack_left = default;
    [SerializeField] GameObject attack_up = default;
    [SerializeField] GameObject attack_down = default;

    [SerializeField] public Text m_Text1 = default;
    [SerializeField] public Text m_Text2 = default;
    [SerializeField] public Text m_Text3 = default;
    [SerializeField] public Text m_Text4 = default;
    [SerializeField] public Text m_Text5 = default;
    [SerializeField] public Text m_Text6 = default;
    [SerializeField] public Text m_Text7 = default;
    [SerializeField] public Text m_Text8 = default;
    [SerializeField] public Text m_Text9 = default;
    [SerializeField] public Text m_Text10 = default;

    [SerializeField] public Text m_Text = default;

    [SerializeField] Text m_messageText = default;
    [SerializeField] Text m_clearText = default;

    [SerializeField] Button m_restartButton = default;

    AudioSource audioSource;
    [SerializeField] AudioClip m_attack = default;
    [SerializeField] AudioClip m_item = default;

    public Vector3 MOVEX = new Vector3(1f, 0, 0); // x軸方向に１マス移動するときの距離
    public Vector3 MOVEY = new Vector3(0, 1f, 0); // y軸方向に１マス移動するときの距離

    [SerializeField] public float step = 1f;     // 移動速度
    public Vector3 target;      // 入力受付時、移動後の位置を算出して保存 
    public Vector3 prevPos;     // 何らかの理由で移動できなかった場合、元の位置に戻すため移動前の位置を保存

    Animator animator;   // アニメーション

    bool objW = true;
    bool objS = true;
    bool objA = true;
    bool objD = true;

    public EnemyController enemyController;

    void Start()
    {
        m_rb2d = GetComponent<Rigidbody2D>();
        target = transform.position;
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        m_Text1 = GameObject.FindWithTag("Text1").GetComponentInChildren<Text>();
        m_Text2 = GameObject.FindWithTag("Text2").GetComponentInChildren<Text>();
        m_Text3 = GameObject.FindWithTag("Text3").GetComponentInChildren<Text>();
        m_Text4 = GameObject.FindWithTag("Text4").GetComponentInChildren<Text>();
        m_Text5 = GameObject.FindWithTag("Text5").GetComponentInChildren<Text>();
        m_Text6 = GameObject.FindWithTag("Text6").GetComponentInChildren<Text>();
        m_Text7 = GameObject.FindWithTag("Text7").GetComponentInChildren<Text>();
        m_Text8 = GameObject.FindWithTag("Text8").GetComponentInChildren<Text>();
        m_Text9 = GameObject.FindWithTag("Text9").GetComponentInChildren<Text>();
        m_Text10 = GameObject.FindWithTag("Text10").GetComponentInChildren<Text>();

        m_Text = GameObject.FindWithTag("Text").GetComponentInChildren<Text>();

        m_messageText = GameObject.FindWithTag("MessageText").GetComponentInChildren<Text>();
        m_clearText = GameObject.FindWithTag("ClearText").GetComponentInChildren<Text>();

        Hp = 10;
        step = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }

        Ray();

        // ① 移動中かどうかの判定。移動中でなければ入力を受付
        if (transform.position == target)
        {
            SetTargetPosition();
        }
        Move();

        if (Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightControl) && Input.GetKey(KeyCode.LeftArrow))
        {
            Attack_Left();
            audioSource.PlayOneShot(m_attack);
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl)&& Input.GetKey(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.RightControl) && Input.GetKey(KeyCode.RightArrow))
        {
            Attack_Left();
            audioSource.PlayOneShot(m_attack);
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKey(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.RightControl) && Input.GetKey(KeyCode.UpArrow))
        {
            Attack_Up();
            audioSource.PlayOneShot(m_attack);
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKey(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.RightControl) && Input.GetKey(KeyCode.DownArrow))
        {
            Attack_Down();
            audioSource.PlayOneShot(m_attack);
        }
        else
        {
            attack_left.SetActive(false);
            attack_up.SetActive(false);
            attack_down.SetActive(false);
        }

        if (Hp <= 0)
        {
            Destroy(gameObject);
            GameOver();
        }
    }

    void SetTargetPosition()
    {

        prevPos = target;

        if (Input.GetKey(KeyCode.D) && objD)
        {
            target = transform.position + MOVEX;
            return;
        }
        if (Input.GetKey(KeyCode.A) && objA)
        {
            target = transform.position - MOVEX;
            return;
        }
        if (Input.GetKey(KeyCode.W) && objW)
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

    void Attack_Left()
    {
        attack_left.SetActive(true);
        Debug.Log("攻撃した");
    }

    void Attack_Up()
    {
        attack_up.SetActive(true);
        Debug.Log("攻撃した");
    }

    void Attack_Down()
    {
        attack_down.SetActive(true);
        Debug.Log("攻撃した");
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Item HP")
        {
            Debug.Log("HPが1増えた");
            audioSource.PlayOneShot(m_item);
            if (m_Text3)
            {
                m_Text.text = " " + "HPが1増えた";
                LogSet();
            }
            Hp++;
        }

        if (col.gameObject.tag == "Item ATK")
        {
            Atk++;
            Debug.Log("ATKが1増えた");
            audioSource.PlayOneShot(m_item);
            if (m_Text3)
            {
                m_Text.text = " " + "ATKが1増えた";
                LogSet();
            }
            audioSource.PlayOneShot(m_item);
        }

        if (col.gameObject.tag == "Item SPEED")
        {
            step = step + (float)0.5;
            Debug.Log("SPEEDが0.5増えた");
            audioSource.PlayOneShot(m_item);
            if (m_Text3)
            {
                m_Text.text = " " + "SPEEDが0.5増えた";
                LogSet();
            }
        }
    }
    void LogSet()
    {
        m_Text1.text = m_Text2.text;
        m_Text2.text = m_Text3.text;
        m_Text3.text = m_Text4.text;
        m_Text4.text = m_Text5.text;
        m_Text5.text = m_Text6.text;
        m_Text6.text = m_Text7.text;
        m_Text7.text = m_Text8.text;
        m_Text8.text = m_Text9.text;
        m_Text9.text = m_Text10.text;
        m_Text10.text = m_Text.text;
    }

    void Ray()
    {
 
        int layerMask = LayerMask.GetMask(new string[] { "wall", "Enemy" });
        Ray2D rayW = new Ray2D(this.transform.position + new Vector3(0, 0.5f,0), transform.up);
        Ray2D rayS = new Ray2D(this.transform.position + new Vector3(0, -0.5f, 0), transform.up * -1);
        Ray2D rayD = new Ray2D(this.transform.position + new Vector3(0.5f, 0, 0), transform.right);
        Ray2D rayA = new Ray2D(this.transform.position + new Vector3(-0.5f, 0, 0), transform.right * -1);
        RaycastHit2D hitW = Physics2D.Raycast(rayW.origin, rayW.direction, 0.5f, layerMask);
        RaycastHit2D hitS = Physics2D.Raycast(rayS.origin, rayS.direction, 0.5f, layerMask);
        RaycastHit2D hitD = Physics2D.Raycast(rayD.origin, rayD.direction, 0.5f, layerMask);
        RaycastHit2D hitA = Physics2D.Raycast(rayA.origin, rayA.direction, 0.5f, layerMask);
        Debug.DrawLine(this.transform.position + new Vector3(0, 0.5f, 0), this.transform.position + transform.up);
        Debug.DrawLine(this.transform.position + new Vector3(0, -0.5f, 0), this.transform.position + transform.up * -1);
        Debug.DrawLine(this.transform.position + new Vector3(0.5f, 0, 0), this.transform.position + transform.right);
        Debug.DrawLine(this.transform.position + new Vector3(-0.5f, 0, 0), this.transform.position + transform.right * -1);
        if (hitW)
        {
            Debug.Log(hitW.transform.name);
            objW = false;
        }
        else
        {
            objW = true;
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
        if (hitD)
        {
            Debug.Log(hitD.transform.name);
            objD = false;
        }
        else
        {
            objD = true;
        }
        if (hitA)
        {
            Debug.Log(hitA.transform.name);
            objA = false;
        }
        else
        {
            objA = true;
        }
        
    }
    void GameOver()
    {
        if (m_messageText)
        {
            m_messageText.text = "GAME OVER";
        }

        if (m_restartButton)
        {
            m_restartButton.gameObject.SetActive(true);
        }
    }

    void GameClear()
    {
        if (m_clearText)
        {
            m_clearText.text = "GAME CLEAR";
        }
    }
}