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
 * 
 * Autores: 
 * Jorge Chávez Badillo            A01749448
 * Ariadna Jocelyn Guzmán Jiménez  A01749373
 * Liam Garay Monroy               A01750632
 * Amy Murakami Tsutsumi           A01750185
 * Andrea Vianey Díaz Álvarez      A01750147
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

        forma.AddField("usuarioUsuarioo", textoNombre.text); //Guardar en nombre del usuario 
        forma.AddField("passwordUsuarioo", textoContrasena.text); //Guardar el password del usuario

        //Conectar el videojuego a la base de datos para validar los datos del jugador
        UnityWebRequest request = UnityWebRequest.Post("http://3.22.38.105:8080/jugador/BuscarJugador", forma); 
        yield return request.SendWebRequest();   //Regresa, ejecuta, espera...
        //...ya regreso a la linea 27 (termino de ejecutar SendWebRequest())

        //Verificar si la conexión fue correcta
        if (request.result == UnityWebRequest.Result.Success)  //200 OK
        {
            string textoPlano = request.downloadHandler.text;  //Datos descargados de la red
            resultado.text = textoPlano;

            //Si los datos son correctos, muestra la escena de menu
            if (textoPlano == "")
            {
                SceneManager.LoadScene("EscenaMenu");
                nombre = textoNombre.text;
            }
        }
        else //En caso contrario, muestra el error en la descarga de datos
        {
            resultado.text = "Error en la descarga: " + request.responseCode.ToString();
        }
    }

    //Mandar el tiempo y puntaje total del jugador a la base de datos
    private IEnumerator subirTiempoPuntaje(int puntajeTotal)
    {
        tiempoTotal = Time.time - Menu.tiempoInicial; //Calcula el tiempo jugado

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
        //Agregar datos a la tabla partida
        UnityWebRequest request = UnityWebRequest.Post("http://3.22.38.105:8080/partida/AgregarPartida", forma2);//3.22.38.105
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
    //Subir el tiempo y puntaje total de la partida
    public void tiempopuntaje(int puntajeTotal)
    {
        StartCoroutine(subirTiempoPuntaje(puntajeTotal));
    }

    //Actualizar el nivel para guardar el progreso del jugador
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
        //Modificar el nivel del jugador
        UnityWebRequest request = UnityWebRequest.Post("http://3.22.38.105:8080/jugador/ActualizarNivel", forma2);//3.22.38.105
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
    //Subir actualizaciones de nivel
    public void actualizarNivel(int nivel)
    {
        StartCoroutine(subiractualizarNivel(nivel));
    }
}
