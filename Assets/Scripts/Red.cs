using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
//using Newtonsoft.Json;

/*
 * Muestra el uso de UnityWebRequest para comunicarse con un servidor en la red
 * Jorge Chávez Badillo            A01749448
 * Ariadna Jocelyn Guzmán Jiménez  A01749373
 * Liam Garay Monroy               A01750632
 * Amy Murakami Tsutsumi           A01750185
 * Andrea Vianey Díaz Álvarez      A01750147
 */

public class Red : MonoBehaviour
{
    //Para desplegar la información
    public Text resultado;

    //public static Red instance;
    //public static String tiempoInicio;

    //Campos con la información nombre y puntos
    public Text textoNombre;
    public Text textoContrasena;
    //public static String nombre;
    //Escribir
    public void EscribirTextoPlano()     //Botón
    {
        //Concurrente
        StartCoroutine(SubirTextoPlano());
    }

    private IEnumerator SubirTextoPlano()
    {
        //print(textoNombre.text);
        //Encapsular los datos que se suben a la red con el método POST
        WWWForm forma = new WWWForm();
        forma.AddField("usuarioUsuario", textoNombre.text);
        forma.AddField("passwordUsuario", textoContrasena.text);

        print(textoNombre.text);
        print(forma.data);

        UnityWebRequest request = UnityWebRequest.Post("http://Localhost:8080/jugador/BuscarJugador", forma); //
        yield return request.SendWebRequest();   //Regresa, ejecuta, espera...
        //...ya regresó a la línea 27 (terminó de ejecutar SendWebRequest())

        if (request.result == UnityWebRequest.Result.Success)  //200 OK
        {
            string textoPlano = request.downloadHandler.text;  //Datos descargados de la red
            resultado.text = textoPlano;
            if (textoPlano == "")
            {
                SceneManager.LoadScene("EscenaMenu");
                //tiempoInicio = System.DateTime.Now.TimeOfDay.ToString();
                //nombre = textoNombre.text;
            }
        }
        else
        {
            resultado.text = "Error en la descarga: " + request.responseCode.ToString();
        }
    }
}
