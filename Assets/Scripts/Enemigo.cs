using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

/*
 * Detecta la colisión del enemigo con el personaje
 * 
 * Autores: 
 * Jorge Chávez Badillo A01749448
 * Ariadna Jocelyn Guzmán Jiménez A01749373
 * Liam Garay Monroy A01750632
 * Andrea Vianey Díaz Álvarez A01750147
 * Amy Murakami Tsutsumi A01750185
 */

public class Enemigo : MonoBehaviour
{
    public static Enemigo instance;
    public static float tiempoTotal;
    public Red red; //Mandar los datos al servidor
    public int nivel; //Posición del nivel
    public static int niveel;
    //Referencia al Audio Source
    public AudioSource vidaMenos;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("proyectilArt")) //Colision del Enemigo con el Proyectil del Personaje
        {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Player")) //Colisiona el Personaje con Enemigo
        {
            //Descontar una vida 
            VidasPersonaje.instance.vidas--;
            //Reproducir un efecto de sonido
            vidaMenos.Play();

            //Actualizar las 'flechas'
            HUD.instance.ActualizarVidas();
            if (VidasPersonaje.instance.vidas == 0)
            {
                Destroy(other.gameObject, 0.3f);
                niveel= nivel; //Se queda en el mismo nivel
                SceneManager.LoadScene("MapaNiveles"); //Pierde, regresa al mapa de niveles
                red.tiempopuntaje(VidasPersonaje.instance.monedas); //Registrar el tiempo/puntaje

            }
        }
    }
}
