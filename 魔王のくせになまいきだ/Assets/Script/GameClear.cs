using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameClear : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Text m_clearText = default;

    SceneLoader SceneLoader;

    GameObject[] enemyObjects;

    void Start()
    {
        m_clearText = GameObject.FindWithTag("ClearText").GetComponentInChildren<Text>();
        SceneLoader = GetComponent<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");

        //if (enemyObjects.Length == 0)
        //{
       //     Clear();
       // }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Clear();
        }
    }

    void Clear()
    {
        SceneLoader.LoadScene("result");
    }
}
