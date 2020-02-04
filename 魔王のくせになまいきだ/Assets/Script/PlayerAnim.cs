using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Animator anim = null;
    bool Up = false;
    bool Down = false;
    bool Left = false;
    bool Right = false;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        bool D = Input.GetKey(KeyCode.D);
        bool A = Input.GetKey(KeyCode.A);
        bool S = Input.GetKey(KeyCode.S);
        bool W = Input.GetKey(KeyCode.W);
        
        bool LeftControl = Input.GetKeyDown(KeyCode.LeftControl);
        bool RightControl = Input.GetKeyDown(KeyCode.RightControl);
        bool LeftArrow = Input.GetKey(KeyCode.LeftArrow);
        bool RightArrow = Input.GetKey(KeyCode.RightArrow);
        bool UpArrow = Input.GetKey(KeyCode.UpArrow);
        bool DownArrow = Input.GetKey(KeyCode.DownArrow);

        if (D)
        {
            transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("walk right", true);
            anim.SetBool("walk left", false);
            anim.SetBool("walk down", false);
            anim.SetBool("walk back", false);
            Up = false;
            Down = false;
            Left = false;
            Right = true;
        }
        else if (A)
        {
            transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("walk left", true);
            anim.SetBool("walk right", false);
            anim.SetBool("walk down", false);
            anim.SetBool("walk back", false);
            Up = false;
            Down = false;
            Left = true;
            Right = false;
        }
        else if (S)
        {
            transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("walk down", true);
            anim.SetBool("walk right", false);
            anim.SetBool("walk left", false);
            anim.SetBool("walk back", false);
            Up = false;
            Down = true;
            Left = false;
            Right = false;
        }
        else if (W)
        {
            transform.localScale = new Vector3(1, 1, 1);
            anim.SetBool("walk back", true);
            anim.SetBool("walk right", false);
            anim.SetBool("walk down", false);
            anim.SetBool("walk left", false);
            Up = true;
            Down = false;
            Left = false;
            Right = false;
        }
        else if (RightArrow)
        {
            anim.SetBool("idle right", true);
            Up = false;
            Down = false;
            Left = false;
            Right = true;
        }
        else if (LeftArrow)
        {
            anim.SetBool("idle left", true);
            Up = false;
            Down = false;
            Left = true;
            Right = false;
        }
        else if (UpArrow)
        {
            anim.SetBool("idle up", true);
            Up = true;
            Down = false;
            Left = false;
            Right = false;
        }
        else if (DownArrow)
        {
            anim.SetBool("idle down", true);
            Up = false;
            Down = true;
            Left = false;
            Right = false;
        }
        else if ((LeftControl || RightControl) && Left)
        {
            anim.SetBool("attack", true);
        }
        else if ((LeftControl || RightControl) && Right)
        {
            anim.SetBool("attack right", true);
        }
        else if ((LeftControl || RightControl) && Up)
        {
            anim.SetBool("attack up", true);
        }
        else if ((LeftControl || RightControl) && Down)
        {
            anim.SetBool("attack down", true);
        }
        else
        {
            anim.SetBool("walk left", false);
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
            anim.SetBool("walk down", false);
        }
    }
}
