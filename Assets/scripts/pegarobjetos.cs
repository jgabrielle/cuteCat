using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pegarobjetos : MonoBehaviour
{
    public bool grabbed;
    RaycastHit2D hit;
    public float distance = 0.25f;
    public Transform holdpoint;
  //public float throwforce;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            if (!grabbed)
            {
                //grab
                Physics2D.queriesStartInColliders=false;
                hit = Physics2D.Raycast(transform.position,Vector2.right*transform.localScale.x,distance);
                if(hit.collider!=null)
                {
                    grabbed=true;
                    print("bateu");
                }
            }
            else
            {
                /*/throw
                grabbed = false;
                if (hit.collider.gameObject.GetComponent<Rigidbody2D>(!=null))
                {
                    hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity* new Vector2()
                }*/
            }
            
        }
        if (grabbed)
        {
            hit.collider.gameObject.transform.position=holdpoint.position;
        }
        
    }
    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position  + Vector3.right * transform.localScale.x * distance);
    }
    
}
