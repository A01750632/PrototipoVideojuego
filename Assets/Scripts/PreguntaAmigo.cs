using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
/*
 * Destruye el canvas amigo al terminar de contestar la pregunta
 *
 * Autores: 
 * Jorge Chávez Badillo            A01749448
 * Ariadna Jocelyn Guzmán Jiménez  A01749373
 * Liam Garay Monroy               A01750632
 * Amy Murakami Tsutsumi           A01750185
 * Andrea Vianey Díaz Álvarez      A01750147
 */
public class PreguntaAmigo : MonoBehaviour
{
    //private PreguntasFinal preguntas; 
    // Para desplegar la información
    public int colision = 0;

    public CanvasAmigo canvasA; //Canvas de amigo
    public HUD canvasV; //Canvas de vidas del personaje
    

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")) //colisión del personaje con amigo
        {
            colision = 1;
            canvasA.colisiono(colision); //Mostrar el canvas de amigo para desplegar la pregunta
            Destroy(gameObject); //Destruye el canvas amigo
            if (VidasPersonaje.instance.vidas > 10) //Si el jugador contesta mal la pregunta, destruye el amigo
            {
                Destroy(gameObject);
            }
        }
    }
}