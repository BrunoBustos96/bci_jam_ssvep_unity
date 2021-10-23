using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asteroid_movement : MonoBehaviour
{

    private Rigidbody2D rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3 (0,1f,0).normalized * speed;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
