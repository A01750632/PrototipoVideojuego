using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;

/*
 * Detecta la colisión del proyectil del enemigo con el personaje. 
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

    //Referencia al Audio Source
    public AudioSource vidaMenos;

    public IEnumerator OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            //Descontar una vida 
            VidasPersonaje.instance.vidas--;
            //Reproducir un efecto de sonido
            vidaMenos.Play();

            //Actualizar las 'flechas'
            HUD.instance.ActualizarVidas();
            if (VidasPersonaje.instance.vidas == 0) //Si el personaje no tiene vidas
            {

                tiempoTotal = Time.time - Menu.tiempoInicial; //tiempo jugado
                Destroy(other.gameObject, 0.3f); //Destruye el personaje
                Enemigo.niveel = nivel; //Se queda en el mismo nivel
                SceneManager.LoadScene("MapaNiveles"); //Pierde, regresa al mapa de niveles

                WWWForm forma2 = new WWWForm();

                //Manda el tiempo total jugado del usuario
                forma2.AddField("tiempoTotal", tiempoTotal.ToString());
                if (Red.nombre == null)
                {
                    forma2.AddField("Usuario", Registro.nombre);
                }
                else
                {
                    forma2.AddField("Usuario", Red.nombre);
                }
                
                //Agrega un registro en la tabla partida
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