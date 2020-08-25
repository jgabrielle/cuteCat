using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class variaveis : MonoBehaviour
{
    public float distancia;
    public LayerMask mask;
    public Rigidbody2D corpo;
    public GameObject moeda;
    
    void Start()
    {
        corpo = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(h * Time.deltaTime,v * Time.deltaTime,0 ));
        
        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.right * transform.localScale.x, distancia, mask);
    
        if(hit.collider != null)
        {
            moeda = hit.collider.gameObject;
            print(moeda.name);

            if(Input.GetKey(KeyCode.Z))
            {
                moeda.GetComponent<Rigidbody2D>().isKinematic = false;
                GetComponent<FixedJoint2D>().enabled = true;
                GetComponent<FixedJoint2D>().connectedBody = moeda.GetComponent<Rigidbody2D>();

            }
            else
            {
                GetComponent<FixedJoint2D>().enabled = false;
                GetComponent<FixedJoint2D>().connectedBody = null;
                moeda.GetComponent<Rigidbody2D>().Sleep();
                moeda.GetComponent<Rigidbody2D>().isKinematic = true;

            }
        }
        else
        {
            moeda = null;
        }

    
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position  + Vector2.right * transform.localScale.x * distancia);
    }*/

}
