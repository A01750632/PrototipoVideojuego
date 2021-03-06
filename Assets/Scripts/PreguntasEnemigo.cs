using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using UnityEngine.SceneManagement;
/*
 * Activa el canvas de preguntas de enemigo final en caso de colisión
 *
 * Autores: 
 * Jorge Chávez Badillo            A01749448
 * Ariadna Jocelyn Guzmán Jiménez  A01749373
 * Liam Garay Monroy               A01750632
 * Amy Murakami Tsutsumi           A01750185
 * Andrea Vianey Díaz Álvarez      A01750147
 */

public class PreguntasEnemigo : MonoBehaviour
{
    //private PreguntasFinal preguntas; 
    // Para desplegar la informaci�n
    public int colision = 0;

    public CanvasEnemigo canvasA; //Canvas de preguntas de enemigo final
    public HUD canvasV; //Canvas de vidas del personaje


    public void OnTriggerEnter2D(Collider2D other) //El personaje colisiona con el enemigo final
    {
        if (other.gameObject.CompareTag("Player")) //Colisiona el Personaje con Enemigo
        {
            //canvasV.gameObject.SetActive(false);
            colision = 1;
            canvasA.colisiono(colision); //Despliega el canvas de enemeigo
        }
    }
}
