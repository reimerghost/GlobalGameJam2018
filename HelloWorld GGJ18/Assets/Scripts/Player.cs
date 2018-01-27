using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    private float walkSpeed;
    private float curSpeed;

    public bool isTouchingWallRight;
    public bool isTouchingWallLeft;
    public bool isTouchingWallUp;
    public bool isTouchingWallDown;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        walkSpeed = (float)5;
        curSpeed = walkSpeed;

    }

    private float hor = 0, ver = 0;
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");


        //rb.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal") * curSpeed, 0.8f),
          //                          Mathf.Lerp(0, Input.GetAxis("Vertical") * curSpeed, 0.8f));


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
                    movespeed = movespeed / 2; //This is so you don't move along walls at full speed
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
}
