using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_HP : MonoBehaviour
{
    [SerializeField] public Text m_Menu_HP = default;

    public PlayerController playerController;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Menu_HP)
        {
            int HP = playerController.Hp;
            string Hp = HP.ToString();
            m_Menu_HP.text = "HP:" + Hp;
        }
    }
}
