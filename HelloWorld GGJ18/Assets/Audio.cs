using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        GetComponent<AudioSource>().Play();
        GetComponent<AudioSource>().volume = 0.7f;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
