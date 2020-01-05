using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu_ATK : MonoBehaviour
{
    [SerializeField] public Text m_Menu_ATK = default;
    
    public PlayerController playerController;
    void Start()
    {
        
    }

    void Update()
    {
        if (m_Menu_ATK)
        {
            int ATK = playerController.Atk;
            string Atk = ATK.ToString();
            m_Menu_ATK.text = "ATK:" + Atk;
        }
    }
}
