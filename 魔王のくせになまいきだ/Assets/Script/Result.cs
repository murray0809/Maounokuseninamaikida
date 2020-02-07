using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{
    SceneLoader loader;
    private void Start()
    {
        FadeManager.FadeIn();
        loader = GetComponent<SceneLoader>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            loader.LoadScene("Title");
        }
    }
}
