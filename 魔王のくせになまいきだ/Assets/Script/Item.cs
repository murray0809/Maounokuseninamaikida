using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{
    void start()
    {
        gameObject.transform.parent = null;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}