using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gatoprincipal : MonoBehaviour
{
    public bool face = true;
    public Transform heroiT;
    

    void Start()
    {
        heroiT = GetComponent<Transform> ();
        
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) && !face)
        {
            Flip ();
        } 
        else if (Input.GetKey(KeyCode.LeftArrow) && face)
        {
            Flip ();
        }

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(h * Time.deltaTime,v * Time.deltaTime,0 ));

        
    }
    void Flip()
    {
        face = !face;
        Vector2 scala = heroiT.localScale;
        scala.x *= -1;
        heroiT.localScale = scala;

    }

    // Update is called once per frame
    
}
