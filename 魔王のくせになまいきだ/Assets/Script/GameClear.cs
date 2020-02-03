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
    GameObject player;
    void Start()
    {
        m_clearText = GameObject.FindWithTag("ClearText").GetComponentInChildren<Text>();
        SceneLoader = GetComponent<SceneLoader>();
        player = GameObject.Find("Player(Clone)");
    }

    // Update is called once per frame
    void Update()
    {

        //if (enemyObjects.Length == 0)
        //{
        //     Clear();
        // }
        //if (player.transform.position.x == )
        //{

        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("atari");
        if (collision.gameObject.name == "Player(Clone)")
        {
            Debug.Log("clear");
            Clear();
        }
    }


    void Clear()
    {
        SceneLoader.LoadScene("result");
    }
}
