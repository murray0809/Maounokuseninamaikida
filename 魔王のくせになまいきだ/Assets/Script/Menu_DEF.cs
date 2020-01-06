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
            m_Menu_DEF.text = "DEF:" + PlayerController.Def;
        }
    }
}
