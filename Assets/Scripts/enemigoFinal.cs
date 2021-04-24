using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
* Detecta la colisión del enemigo con el personaje
*Autores: 
*Jorge Chávez Badillo            A01749448
*Ariadna Jocelyn Guzmán Jiménez  A01749373
*Liam Garay Monroy               A01750632
*Amy Murakami Tsutsumi           A01750185
*Andrea Vianey Díaz Álvarez      A01750147
*/
public class enemigoFinal : MonoBehaviour
{
    //private PreguntasFinal preguntas; 

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("PreguntaEnemigoFinal");
            //PreguntasFinal.instance2.EscribirPregunta(); 
            // Reproducir el efecto 
            //efectoEnemigo.Play(); 
            // Descontar una vida
            //SaludPersonaje.instance.vidas--;
            // Actualizar los 'corazones'
            //HUD.instance.ActualizarVidas();
            //if (SaludPersonaje.instance.vidas == 0)
            //{
            // Almacenar en Preferencias las monedas recolectadas
            //PlayerPrefs.SetInt("numeroMonedas", SaludPersonaje.instance.monedas); 
            //PlayerPrefs.Save(); // Inmediato guarda el valor 

            //efectoMuere.Play();  
            //Destroy(other.gameObject, 0.3f);
            //SceneManager.LoadScene("EscenaMenu");   // Pierde, regresa al menú
        }
    }
}