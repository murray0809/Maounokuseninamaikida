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
        if (gameObject.name == "Wood Box(Clone)")
        {
            this.transform.position = new Vector3((float)x + 0.1f, (float)y - 0.25f, -0.1f);
        }
        else
        {
            this.transform.position = new Vector3((float)x, (float)y, -0.1f);
        }
        
    }
}
