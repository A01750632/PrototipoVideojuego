using System.Collections;
using System.Collections.Generic;
//using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
 * Detecta la colisión del enemigo con el personaje
 * Autor: Roberto Mtz. Román
 */
public class enemigoFinal : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("PreguntaFinalNivel5");
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