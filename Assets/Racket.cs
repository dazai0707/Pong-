using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Racket : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 5f;
    public string axis;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float y = Input.GetAxisRaw(axis);  // 1      0    -1 
        rb.velocity = new Vector2(0, y)*speed;
       
    }
}
