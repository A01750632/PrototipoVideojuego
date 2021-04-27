using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using UnityEngine.SceneManagement;


public class PreguntasEnemigo : MonoBehaviour
{
    //private PreguntasFinal preguntas; 
    // Para desplegar la informaci�n
    public int colision = 0;

    public CanvasEnemigo canvasA;
    public HUD canvasV;


    public void OnTriggerEnter2D(Collider2D other)
    {
        //canvasV.gameObject.SetActive(false);
        colision = 1;
        canvasA.colisiono(colision);
    }
}
