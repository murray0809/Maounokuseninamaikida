using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{
    private void Start()
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