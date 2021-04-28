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

    //public static Red instance;
    public static String tiempoInicio;

    //Campos con la informacion nombre y puntos
    public Text textoNombre;
    public Text textoContrasena;
    public static String nombre;
    public static float tiempoTotal;
    public int nivel; //Para agregar el IDNivel

    //Inicializar los intentos para pista
    void Start()
    {
        PlayerPrefs.SetInt("intentos", 2);
        PlayerPrefs.Save();
    }
    //Escribir
    public void EscribirTextoPlano()     //Boton
    {
        //Concurrente
        StartCoroutine(SubirTextoPlano());
    }
    public void CrearCuenta()     //Boton
    {
     
        SceneManager.LoadScene("EscenaRegistro");
    }

    public void Salir()
    {
        Application.Quit();
    }

    private IEnumerator SubirTextoPlano()
    {

        //Encapsular los datos que se suben a la red con el metodo POST
        WWWForm forma = new WWWForm();

        forma.AddField("usuarioUsuarioo", textoNombre.text);
        forma.AddField("passwordUsuarioo", textoContrasena.text);

        UnityWebRequest request = UnityWebRequest.Post("http://Localhost:8080/jugador/BuscarJugador", forma); //3.22.38.105
        yield return request.SendWebRequest();   //Regresa, ejecuta, espera...
        //...ya regreso a la linea 27 (termino de ejecutar SendWebRequest())

        if (request.result == UnityWebRequest.Result.Success)  //200 OK
        {
            string textoPlano = request.downloadHandler.text;  //Datos descargados de la red
            resultado.text = textoPlano;
            if (textoPlano == "")
            {
                SceneManager.LoadScene("EscenaMenu");
                nombre = textoNombre.text;
            }
        }
        else
        {
            resultado.text = "Error en la descarga: " + request.responseCode.ToString();
        }
    }

    private IEnumerator subirTiempoPuntaje(int puntajeTotal)
    {
        tiempoTotal = Time.time - Menu.tiempoInicial;

        WWWForm forma2 = new WWWForm();

        forma2.AddField("tiempoTotal", tiempoTotal.ToString());
        forma2.AddField("puntajeTotal", puntajeTotal);
        forma2.AddField("nivelID", nivel);

        if (Red.nombre == null)
        {
            forma2.AddField("Usuario", Registro.nombre);
        }
        else
        {
            forma2.AddField("Usuario", Red.nombre);
        }
        UnityWebRequest request = UnityWebRequest.Post("http://Localhost:8080/partida/AgregarPartida", forma2);//3.22.38.105
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

    public void tiempopuntaje(int puntajeTotal)
    {
        StartCoroutine(subirTiempoPuntaje(puntajeTotal));
    }

    private IEnumerator subiractualizarNivel(int nivel)
    {
        WWWForm forma2 = new WWWForm();
        forma2.AddField("nivel", nivel);

        if (Red.nombre == null)
        {
            forma2.AddField("Usuario", Registro.nombre);
        }
        else
        {
            forma2.AddField("Usuario", Red.nombre);
        }
        UnityWebRequest request = UnityWebRequest.Post("http://Localhost:8080/jugador/ActualizarNivel", forma2);//3.22.38.105
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
    public void actualizarNivel(int nivel)
    {
        StartCoroutine(subiractualizarNivel(nivel));
    }
}
