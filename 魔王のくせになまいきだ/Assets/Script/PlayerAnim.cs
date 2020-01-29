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
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightControl) && Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetBool("attack", true);
        }
        else if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.RightControl) && Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("attack right", true);
        }
        else if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.RightControl) && Input.GetKey(KeyCode.UpArrow))
        {
            anim.SetBool("attack up", true);
        }
        else if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.RightControl) && Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool("attack down", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("walk right", true);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("walk", true);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("walk", true);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("walk back", true);
        }
        
        //else if (VerticalKey > 0 && Input.GetKey(KeyCode.LeftControl))
        //{
        //    transform.localScale = new Vector3(3, 3, 1);
        //    //anim.SetBool("walk back", true);
        //    anim.SetBool("attack back", true);
        //}
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            anim.SetBool("idle right", true);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            anim.SetBool("idle left", true);
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            anim.SetBool("idle up", true);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            anim.SetBool("idle down", true);
        }
        else
        {
            anim.SetBool("walk", false);
            anim.SetBool("walk back", false);
            anim.SetBool("attack", false);
            anim.SetBool("attack back", false);
            anim.SetBool("attack right", false);
            anim.SetBool("idle right", false);
            anim.SetBool("idle left", false);
            anim.SetBool("idle up", false);
            anim.SetBool("idle down", false);
            anim.SetBool("attack up", false);
            anim.SetBool("attack down", false);
            anim.SetBool("walk right", false);
        }
    }
}
