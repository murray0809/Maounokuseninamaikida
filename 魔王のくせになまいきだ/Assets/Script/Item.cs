using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{
    private void Start()
    {
        transform.parent = null;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }

}