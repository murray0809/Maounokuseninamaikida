using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] GameObject m_item1 = default;
    [SerializeField] GameObject m_item2 = default;
    [SerializeField] GameObject m_item3 = default;
    [SerializeField] GameObject m_item4 = default;
    [SerializeField] GameObject m_item5 = default;
    GameObject item;
    Transform t;
    
    bool y = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        int layerMask = LayerMask.GetMask(new string[] { "wall"});
        Ray2D rayW = new Ray2D(this.transform.position + new Vector3(0, 0.5f, 0), transform.up);
        Ray2D rayWA = new Ray2D(this.transform.position + new Vector3(-0.5f, 0.5f, 0), new Vector3(-0.5f, 0.5f));
        Ray2D rayS = new Ray2D(this.transform.position + new Vector3(0, -0.5f, 0), transform.up * -0.5f);
        Ray2D raySA = new Ray2D(this.transform.position + new Vector3(-0.5f, -0.5f, 0), new Vector3(-0.5f, -0.5f));
        Ray2D rayD = new Ray2D(this.transform.position + new Vector3(0.5f, 0, 0), transform.right * 0.5f);
        Ray2D raySD = new Ray2D(this.transform.position + new Vector3(0.5f, -0.5f, 0), new Vector3(0.5f, -0.5f));
        Ray2D rayA = new Ray2D(this.transform.position + new Vector3(-0.5f, 0, 0), transform.right * -0.5f);
        Ray2D rayWD = new Ray2D(this.transform.position + new Vector3(0.5f, 0.5f, 0), new Vector3(0.5f, 0.5f));
        RaycastHit2D hitW = Physics2D.Raycast(rayW.origin, rayW.direction, 0.5f, layerMask);
        RaycastHit2D hitS = Physics2D.Raycast(rayS.origin, rayS.direction, 0.5f, layerMask);
        RaycastHit2D hitD = Physics2D.Raycast(rayD.origin, rayD.direction, 0.5f, layerMask);
        RaycastHit2D hitA = Physics2D.Raycast(rayA.origin, rayA.direction, 0.5f, layerMask);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Attack")
        {
            t = this.gameObject.transform;
            //item = m_item1;
            //int k = Random.Range(1, 5);
            //if (k == 1)
            //{
            //    item = m_item1;
            //}
            //else if (k == 2)
            //{
            //    item = m_item2;
            //}
            //else if (k == 3)
            //{
            //    item = m_item3;
            //}
            //else if (k == 4)
            //{
            //    item = m_item4;
            //}
            //else if (k == 5)
            //{
            //    item = m_item5;
            //}
            //var vs = new List<int>();
            //for (int j = Random.Range(1, 4), r = 1; r <= j; r++)//出す数
            //{
            //    int i = Random.Range(1, 10);//出す方向

                
            //    for (int l = 0; l <= j; l++)
            //    {
            //        if (vs.Contains(i))
            //        {
            //            y = true;
            //        }
            //    }
            //    if (y)
            //    {
            //        continue;
            //    }
            //    vs.Add(i);

            //    if (i == 1)
            //    {
            //        t.position += new Vector3(-1.0f, -1.0f, 0);
            //        Instantiate(item, t);
            //    }
            //    else if (i == 2)
            //    {
            //        t.position += new Vector3(0, -1.0f, 0);
            //        Instantiate(item, t);
            //    }
            //    else if (i == 3)
            //    {
            //        t.position += new Vector3(1.0f, -1.0f, 0);
            //        Instantiate(item, t);
            //    }
            //    else if (i == 4)
            //    {
            //        t.position += new Vector3(-1.0f, 0, 0);
            //        Instantiate(item, t);
            //    }
            //    else if (i == 5)
            //    {
            //        Instantiate(item, t);
            //    }
            //    else if (i == 6)
            //    {
            //        t.position += new Vector3(1.0f, 0, 0);
            //        Instantiate(item, t);
            //    }
            //    else if (i == 7)
            //    {
            //        t.position += new Vector3(-1.0f, 1.0f, 0);
            //        Instantiate(item, t);
            //    }
            //    else if (i == 8)
            //    {
            //        t.position += new Vector3(0, 1.0f, 0);
            //        Instantiate(item, t);
            //    }
            //    else if (i == 9)
            //    {
            //        t.position += new Vector3(1.0f, 1.0f, 0);
            //        Instantiate(item, t);
            //    }
            //}

            Instantiate(m_item1, t);
            Destroy(gameObject);
        }
    }
}
