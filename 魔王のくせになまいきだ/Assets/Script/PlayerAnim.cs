using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Animator anim = null;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontalKey = Input.GetAxis("Horizontal");
        if (horizontalKey > 0)
        {
            transform.localScale = new Vector3(-3, 3, 1);
            anim.SetBool("walk", true);
        }
        else if (horizontalKey < 0)
        {
            transform.localScale = new Vector3(3, 3, 1);
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
        }
    }
}
