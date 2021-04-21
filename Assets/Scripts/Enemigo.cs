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
    //public static String tiempoFinal;
    //public static Enemigo instance;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("proyectilArt"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            //Descontar una vida 
            VidasPersonaje.instance.vidas--; 
            //Actualizar las 'flechas'
            HUD.instance.ActualizarVidas();
            if (VidasPersonaje.instance.vidas == 0)
            {
                Destroy(other.gameObject, 0.3f);
                SceneManager.LoadScene("MapaNiveles"); //Pierde, regresa al mapa de niveles

                /*   Para eviar los datos a la base de datos usando archivo Red
                tiempoFinal = System.DateTime.Now.TimeOfDay.ToString(); //Declaramos la hora final en el momento que pierde las 3 vidas
                String TiempoInicio2 = Red.tiempoInicio; //Traemos del archivo Red el tiempo inicio

                WWWForm forma2 = new WWWForm();

                forma2.AddField("TiempoInicio", TiempoInicio2);
                forma2.AddField("TiempoFinal", tiempoFinal);
                forma2.AddField("TiempoUsuario", Red.nombre);

                UnityWebRequest request = UnityWebRequest.Post("http://Localhost:8080/AgregarTiempo", forma2);
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
                */
            }
        }
    }
}
