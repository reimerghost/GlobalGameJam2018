using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class niveles : MonoBehaviour {


    public void Update()
    {
        if (Input.GetKey(KeyCode.Space)) {
            Application.LoadLevel("Game");
        }
    }
}
