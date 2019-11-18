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
        float VerticalKey = Input.GetAxis("Vertical");
        if (horizontalKey > 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            anim.SetBool("walk", true);
        }
        else if (horizontalKey < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("walk", true);
        }
        else if (VerticalKey < 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("walk", true);
        }
        else if (VerticalKey > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("walk back", true);
        }
        else if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            anim.SetBool("attack", true);
        }
        else if (VerticalKey > 0 && Input.GetKey(KeyCode.LeftControl))
        {
            transform.localScale = new Vector3(3, 3, 1);
            anim.SetBool("walk back", true);
            anim.SetBool("attack back", true);
        }
        else
        {
            anim.SetBool("walk", false);
            anim.SetBool("walk back", false);
            anim.SetBool("attack", false);
            anim.SetBool("attack back", false);
        }
    }
}
