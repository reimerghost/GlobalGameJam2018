using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class niveles : MonoBehaviour {


    public void Start()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }
}
