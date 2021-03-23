using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
/*
 * Detecta la colisi�n del enemigo con el personaje
 * 
 * Autores: 
 * Jorge Ch�vez Badillo A01749448
 * Ariadna Jocelyn Guzm�n Jim�nez A01749373
 * Liam Garay Monroy A01750632
 * Andrea Vianey D�az �lvarez A01750147
 * Amy Murakami Tsutsumi A01750185
 */
public class Enemigo : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            //Descontar una vida 
            //SaludPersonaje.instance.vidas--; 
            //Actualizar los 'corazones'
            //HUD.instance.ActualizarVidas();
            //if (SaludPersonaje.instance.vidas == 0)
            {
                Destroy(other.gameObject, 0.3f);
                //SceneManager.LoadScene("EscenaMenu"); //Pierde, regresa al men�
            }
        }
    }
}
