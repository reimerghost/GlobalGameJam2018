using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {


	public static GameManager instance = null;
	public BoardManager boardScript;


	private void Awake (){
        if (instance == null)
        { instance = this; }
        else if (instance != this)
        { Destroy(gameObject); }

		DontDestroyOnLoad (gameObject);
		boardScript = GetComponent<BoardManager>();
		InitGame ();
	}

    private void OnLevelWasLoaded(int index)
    {
        InitGame();
    }

    void InitGame(){
        boardScript.SetupScene();
    }

	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        /*if (playerTurn || doingSetup)
        {
            return;
        }*/


	}
    
}
