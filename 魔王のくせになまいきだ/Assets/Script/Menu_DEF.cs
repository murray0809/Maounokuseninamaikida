using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_DEF : MonoBehaviour
{
    [SerializeField] public Text m_Menu_DEF = default;

    public PlayerController playerController;
    void Start()
    {
        
    }

    void Update()
    {
        if (m_Menu_DEF)
        {
            int DEF = playerController.Def;
            string Def = DEF.ToString();
            m_Menu_DEF.text = "DEF:" + Def;
        }
    }
}
