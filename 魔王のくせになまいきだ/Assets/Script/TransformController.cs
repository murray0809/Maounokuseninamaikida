using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int x = (int)transform.position.x;
        int y = (int)transform.position.y;

        this.transform.position = new Vector3((float)x, (float)y, -0.1f);
    }
}
