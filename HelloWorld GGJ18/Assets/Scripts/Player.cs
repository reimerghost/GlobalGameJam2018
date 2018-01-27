using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float speed;
    private Rigidbody2D rb;



    private float walkSpeed;
    private float curSpeed;
    private float maxSpeed;
    private float sprintSpeed;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
        walkSpeed = (float)(5 + (14 / 5));
        sprintSpeed = walkSpeed + (walkSpeed / 2);
        
    }

    void FixedUpdate()
    {
        curSpeed = walkSpeed;
        maxSpeed = curSpeed;

        // Move senteces
        rb.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * curSpeed, 0.8f),
                                             Mathf.Lerp(0, Input.GetAxis("Vertical") * curSpeed, 0.8f));
    }
    
}
