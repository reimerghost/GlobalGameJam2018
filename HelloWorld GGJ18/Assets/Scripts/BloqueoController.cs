using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueoController : MonoBehaviour {
    public bool obstaculo;
    public Sprite spriteON;
    public Sprite spriteOFF;

    private void FixedUpdate()
    {
        if (obstaculo) {
        GetComponent<SpriteRenderer>().sprite = spriteON;
        }
        else {
        GetComponent<SpriteRenderer>().sprite = spriteOFF;
        }
    }
}
