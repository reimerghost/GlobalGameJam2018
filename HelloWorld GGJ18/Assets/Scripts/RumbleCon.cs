using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RumbleCon : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        int horizontal = 0;
        int vertical = 0;
        horizontal = (int)Input.GetAxisRaw("Horizontal");
        vertical = (int)Input.GetAxisRaw("Vertical");

        Debug.Log("H: " + horizontal);
        Debug.Log("V: " + vertical);



        if (horizontal != 0)
            vertical = 0;



		//input keys
        // UpArrow	    Up arrow key.
        // DownArrow	Down arrow key.
        // RightArrow	Right arrow key.
        // LeftArrow	Left arrow key.

		if( Input.GetKeyDown( KeyCode.Space ) ){
            Debug.Log( "Space key was pressed." );
                Player2.jump()
        }

		if( Input.GetKeyUp( KeyCode.I ) ){
            Debug.Log( "player2 move up" );
                Player2.move_up()
        }

        if( Input.GetKeyDown( KeyCode.K ) ){
            Debug.Log( "player2 move up" );
                Player2.move_down()
        }

		if( Input.GetKeyRight( KeyCode.L ) ){
            Debug.Log( "player2 move right" );
                Player2.move_right()
        }

		if( Input.GetKeyLeft( KeyCode.J ) ){
            Debug.Log( " player 2 move left" );
                Player2.move_left()
        }


        
    }
}
