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

        Handheld.Vibrate();

        if (horizontal != 0)
            vertical = 0;



		//input keys

//		if( Input.GetKeyDown( KeyCode.Space ) )
//			Debug.Log( "Space key was pressed." );
//
//		if( Input.GetKeyUp( KeyCode.UpArrow ) )
//			Debug.Log( "Space key was released." );
//
//		if( Input.GetKeyRight( KeyCode.UpArrow ) )
//			Debug.Log( "Space key was released." );
//
//		if( Input.GetKeyLeft( KeyCode.DownArrow ) )
//			Debug.Log( "Space key was released." );

    // if (Input.GetKey ("up"))
    //     print ("up arrow key is held down");

    // if (Input.GetKey ("down"))
    //     print ("down arrow key is held down");

        
    }
}
