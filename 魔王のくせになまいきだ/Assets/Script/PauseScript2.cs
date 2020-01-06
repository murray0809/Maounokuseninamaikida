using UnityEngine;
using System.Collections;

public class PauseScript2 : MonoBehaviour
{
    [SerializeField]
    private GameObject pauseUI = default;

    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            pauseUI.SetActive(!pauseUI.activeSelf);

            if (pauseUI.activeSelf)
            {
                Time.timeScale = 0f;
            }
            else
            {
                Time.timeScale = 1f;
            }
        }
    }
}