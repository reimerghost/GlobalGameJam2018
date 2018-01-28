using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palanca : MonoBehaviour {

    public int numPalanca;
    public bool presionada = false;
    public GameObject[] bloqueos;

    private void Start()
    {
        bloqueos = GameObject.FindGameObjectsWithTag("Bloqueo");
    }
    

    public void PresionarPalanca()
    {
        presionada = !presionada;
        if (presionada) { 
        GetComponent<SpriteRenderer>().color = Color.white;
        }
        else
        {
        GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        ReaccionarBloqueos();
    }

    private void ReaccionarBloqueos()
    {
        bool b;
        foreach (GameObject bloquecito in bloqueos)
        {
            b = bloquecito.GetComponent<BloqueoController>().obstaculo;
            bloquecito.GetComponent<BloqueoController>().obstaculo = !b;
            bloquecito.GetComponent<BoxCollider2D>().enabled = !b;

        }
    }
}
