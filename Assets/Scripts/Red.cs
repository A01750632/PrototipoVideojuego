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
 * Autor: Equipo1
 */

public class Red : MonoBehaviour
{
    //Para desplegar la informaci�n
    public Text resultado;

    public static Red instance;
    public static String tiempoInicio;

    //Campos con la informaci�n nombre y puntos
    public Text textoNombre;
    public Text textoContrasenia;
    public static String nombre;
    //Escribir
    public void EscribirTextoPlano()     //Bot�n
    {
        //Concurrente
        StartCoroutine(SubirTextoPlano());
    }

    private IEnumerator SubirTextoPlano()
    {
        //Encapsular los datos que se suben a la red con el m�todo POST
        WWWForm forma = new WWWForm();

        forma.AddField("usuarioUsuarioo", textoNombre.text);
        forma.AddField("passwordUsuarioo", textoContrasenia.text);

        UnityWebRequest request = UnityWebRequest.Post("http://Localhost:8080/BuscarUsuario", forma); //
        yield return request.SendWebRequest();   //Regresa, ejecuta, espera...
        //...ya regres� a la l�nea 27 (termin� de ejecutar SendWebRequest())

        if (request.result == UnityWebRequest.Result.Success)  //200 OK
        {
            string textoPlano = request.downloadHandler.text;  //Datos descargados de la red
            resultado.text = textoPlano;
            if (textoPlano == "")
            {
                SceneManager.LoadScene("EscenaMapa");
                tiempoInicio = System.DateTime.Now.TimeOfDay.ToString();
                nombre = textoNombre.text;
            }
        }
        else
        {
            resultado.text = "Error en la descarga: " + request.responseCode.ToString();
        }
    }
}
