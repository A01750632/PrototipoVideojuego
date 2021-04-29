using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement; //escenas
/*
 * Detecta la colision del enemigo final con el personaje para desplegar 
 * las últimas 3 preguntas del nivel
 *
 * Autores: 
 * Jorge Chávez Badillo            A01749448
 * Ariadna Jocelyn Guzmán Jiménez  A01749373
 * Liam Garay Monroy               A01750632
 * Amy Murakami Tsutsumi           A01750185
 * Andrea Vianey Díaz Álvarez      A01750147
 */
public class enemigoFinal : MonoBehaviour
{
    //private PreguntasFinal preguntas; 

    public void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Player"))//Personaje colisiona con el enemigo final
        {
            SceneManager.LoadScene("PreguntaEnemigoFinal"); //Carga la escena con las 3 preguntas del enemigo final
        }
    }
}