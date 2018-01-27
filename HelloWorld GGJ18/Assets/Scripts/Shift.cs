using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shift : MonoBehaviour {

    public GameObject p1, p2;

    private Player jug1, jug2;

    private float time = 5.4f;
    private float timeLeft = 5.4f;
    private GameObject contador;
    private TextMesh tm;

    private void Start()
    {
        jug1 = p1.GetComponent<Player>();
        jug2 = p2.GetComponent<Player>();
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        contador = GameObject.Find("Contador");

        tm = contador.GetComponent<TextMesh>();
        tm.text = "TIEMPO: "+ Mathf.RoundToInt(timeLeft);
        if (timeLeft < 0)
        {
            timeLeft = time;
            Shifting();
        }
    }

    private void Shifting()
    {
        jug1.enabled = !jug1.enabled;
        jug2.enabled = !jug2.enabled;

        if(jug1.enabled == false)
        p1.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        if(jug2.enabled == false)
            p2.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);


    }
}
