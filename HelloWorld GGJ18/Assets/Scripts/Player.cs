using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    private float walkSpeed;
    public float curSpeed;

    public bool isTouchingWallRight;
    public bool isTouchingWallLeft;
    public bool isTouchingWallUp;
    public bool isTouchingWallDown;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        walkSpeed = (float)4;
        curSpeed = walkSpeed;

    }

    private float hor = 0, ver = 0;
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") ;
        float moveVertical = Input.GetAxis("Vertical");


		if( Input.GetKey( KeyCode.I ) ){
            Debug.Log( "player move up" );
            moveVertical = 1;
        }

        if( Input.GetKey( KeyCode.K ) ){
            Debug.Log( "player move up" );
            moveVertical = -1;
        }

		if( Input.GetKey( KeyCode.L ) ){
            Debug.Log( "player move right" );
            moveHorizontal = 1;
        }

		if( Input.GetKey( KeyCode.J ) ){
            Debug.Log( " player  move left" );
            moveHorizontal = -1;
        }

        Move(moveHorizontal, moveVertical, curSpeed);


    }

    public void Move(float movehorizontal, float movevertical, float movespeed)
    {

        HeroController herocontroller = gameObject.GetComponent<HeroController>();

        //Check to see what direction you are facing in, then, if you're touching a wall, prioritize the opposite axis's movement
        switch (herocontroller.facingDirection)
        {
            case Constants.RIGHT:
                if (isTouchingWallRight)
                {
                    movevertical = movevertical * 10;
                    movespeed = movespeed / 2;
                }
                break;
            case Constants.LEFT:
                if (isTouchingWallLeft)
                {
                    movevertical = movevertical * 10;
                    movespeed = movespeed / 2;
                }
                break;
            case Constants.UP:
                if (isTouchingWallUp)
                {
                    movehorizontal = movehorizontal * 10;
                    movespeed = movespeed / 2;
                }
                break;
            case Constants.DOWN:
                if (isTouchingWallDown)
                {
                    movehorizontal = movehorizontal * 10;
                    movespeed = movespeed / 2;
                }
                break;
            default:
                break;
        }
        //First, figure out the angle of the joystick in degrees
        float angle = Mathf.Atan2(movevertical, movehorizontal) * Mathf.Rad2Deg;

        //Then, figure out whether or not the joystick is being sufficiently pushed to prevent joystick inaccuracy from creating false movement
        float deadcheck = Mathf.Abs(movehorizontal) + Mathf.Abs(movevertical);

        if (deadcheck > 0.6)
        {

            //Right
            if ((angle > -45) && (angle <= 45))
            {
                herocontroller.facingDirection = Constants.RIGHT;
                movehorizontal = 1;
                movevertical = 0;
            }
            //Up
            else if ((angle > 45) && (angle <= 135))
            {
                herocontroller.facingDirection = Constants.UP;
                movehorizontal = 0;
                movevertical = 1;
            }
            //Down
            else if ((angle > -135) && (angle <= -45))
            {
                herocontroller.facingDirection = Constants.DOWN;
                movehorizontal = 0;
                movevertical = -1;
            }
            else
            {
                herocontroller.facingDirection = Constants.LEFT;
                movehorizontal = -1;
                movevertical = 0;
            }
        }
        else
        {
            movevertical = 0;
            movehorizontal = 0;
        }
               
         
                 rb.velocity = new Vector2(Mathf.Lerp(0, movehorizontal * curSpeed, 0.8f),
                                             Mathf.Lerp(0, movevertical * curSpeed, 0.8f));

    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Muro")
        {
            Vector3 contactPoint = coll.contacts[0].point;
            Vector3 center = coll.collider.bounds.center;
            isTouchingWallLeft = contactPoint.x > center.x;
            isTouchingWallRight = contactPoint.x < center.x;
            isTouchingWallUp = contactPoint.y < center.y;
            isTouchingWallDown = contactPoint.y > center.y;
        }
    }

    //OnCollisionExit2D is used to reset the isTouchingWall variables once you leave contact with a wall
    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Muro")
        {
            isTouchingWallLeft = false;
            isTouchingWallRight = false;
            isTouchingWallUp = false;
            isTouchingWallDown = false;
        }
    }
    }
