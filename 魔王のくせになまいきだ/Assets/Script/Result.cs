using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{
    private void Start()
    {
        FadeManager.FadeIn();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            FadeManager.FadeOut(0);
        }
    }
}
