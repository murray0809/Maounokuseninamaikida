using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{

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

    public PlayerController playerController;
    public EnemyController enemyController;

    // Start is called before the first frame update
    void Start()
    {
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
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            int Atk;

            Atk = PlayerController.Atk;

            int Hp;

            Hp = enemyController.Hp;

            Hp -= Atk;

            enemyController.Hp = Hp;

            if (m_Text3)
            {
                m_Text.text = Atk + "ダメージを与えた";
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
}
