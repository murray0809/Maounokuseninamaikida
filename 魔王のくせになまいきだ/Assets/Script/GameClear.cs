using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameClear : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Text m_clearText = default;

    GameObject[] enemyObjects;

    void Start()
    {
        m_clearText = GameObject.FindWithTag("ClearText").GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemyObjects.Length == 0)
        {
            Clear();
        }
    }

    void Clear()
    {
        if (m_clearText)
        {
            m_clearText.text = "GAME CLEAR";
        }
    }
}
