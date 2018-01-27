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


        
    }
}
