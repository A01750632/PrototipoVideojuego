using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidasPersonaje : MonoBehaviour
{
    // Start is called before the first frame update
    public int vidas = 3;
    public static VidasPersonaje instance;
    //public int monedas = 0;

    private void Awake()
    {
        instance = this;
    }
}