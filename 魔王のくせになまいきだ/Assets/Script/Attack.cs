using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{

    [SerializeField] public Text m_Text1 = default;
    [SerializeField] public Text m_Text2 = default;
    [SerializeField] public Text m_Text3 = default;

    [SerializeField] public Text m_Text = default;

    [SerializeField] Text m_messageText = default;

    public PlayerController playerController;
    public Enemycontroller2 enemyController;

    // Start is called before the first frame update
    void Start()
    {
        m_Text1 = GameObject.FindWithTag("Text1").GetComponentInChildren<Text>();
        m_Text2 = GameObject.FindWithTag("Text2").GetComponentInChildren<Text>();
        m_Text3 = GameObject.FindWithTag("Text3").GetComponentInChildren<Text>();

        m_Text = GameObject.FindWithTag("Text").GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            int Atk;

            Atk = playerController.Atk;

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
        m_Text3.text = m_Text.text;
    }
}
