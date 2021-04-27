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

public class ProyectilEnemigo : MonoBehaviour
{
    public static ProyectilEnemigo instance;
    public static float tiempoTotal;

    public int nivel;

    public IEnumerator OnTriggerEnter2D(Collider2D other)
    {
        /*if(other.gameObject.CompareTag("proyectilArt"))
        {
            Destroy(gameObject);
        }
        */
        if (other.gameObject.CompareTag("Player"))
        {
            //Descontar una vida 
            VidasPersonaje.instance.vidas--; 
            //Actualizar las 'flechas'
            HUD.instance.ActualizarVidas();
            if (VidasPersonaje.instance.vidas == 0)
            {

                tiempoTotal = Time.time - Menu.tiempoInicial;
                Destroy(other.gameObject, 0.3f);
                Enemigo.niveel = nivel;
                SceneManager.LoadScene("MapaNiveles"); //Pierde, regresa al mapa de niveles

                WWWForm forma2 = new WWWForm();

                forma2.AddField("tiempoTotal", tiempoTotal.ToString());
                if (Red.nombre == null)
                {
                    forma2.AddField("Usuario", Registro.nombre);
                }
                else
                {
                    forma2.AddField("Usuario", Red.nombre);
                }
                

                UnityWebRequest request = UnityWebRequest.Post("http://Localhost:8080/partida/agregarPartida", forma2);
                yield return request.SendWebRequest();
                if (request.result == UnityWebRequest.Result.Success)  //200 OK
                {
                    string textoPlano = request.downloadHandler.text;  //Datos descargados de la red
                    print(textoPlano);
                }
                else
                {
                    print("Error en la descarga: " + request.responseCode.ToString());
                }

             
            }
        }
    }
}