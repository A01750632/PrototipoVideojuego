using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System; 

public class PreguntaAmigo : MonoBehaviour
{
    //private PreguntasFinal preguntas; 
    // Para desplegar la información
    public int colision = 0;

    public CanvasAmigo canvasA;
    public HUD canvasV;
    

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            colision = 1;
            canvasA.colisiono(colision);
        }
    }
}