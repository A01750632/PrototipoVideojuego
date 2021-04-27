using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using UnityEngine.SceneManagement;

public class CanvasEnemigo : MonoBehaviour
{
    // Para desplegar la informaci�n

    public Text textoPregunta;
    public Text opcion1;
    public Text opcion2;
    public Text opcion3;
    public Text opcion4;
    public Text respuestaCorrecta;
    public Text idPregunta;
    public static Red instance;
    public static PreguntasFinal instance2;
    public GameObject pantallaPregunta;
    public GameObject pantallaContestar;
    private bool hide;
    public GameObject pantallaGameOver;
    public GameObject pantallaWinner;

    public GameObject fondo;

    public GameObject objeto; //Enemigo Final

    public GameObject PantallaWinner2;
    public GameObject PantallaGameOver2;
    public Text textoPregunta2;
    public Text opcion1_2; 
    public Text opcion2_2; 
    public Text opcion3_2;  
    public Text opcion4_2;
    public GameObject PantallaPregunta2;
    public GameObject PantallaWinnerFinal;
    public GameObject PantallaGameOverFinal;
    public Text textoPreguntaFinal;
    public Text opcion1Final; 
    public Text opcion2Final; 
    public Text opcion3Final;  
    public Text opcion4Final;
    public GameObject PantallaPregunta3;

    public int nivel; //Nivel actual
    public int sigNivel; //Siguiente nivel.
    public static int niveel;
    public Red red;


    // Campos con la informaci�n de respuestas
    // Leer textoPregunta de la base de datos 

    public void colisiono(int col)
    {
        niveel = nivel;
        if (col == 1)
        {
            pantallaContestar.SetActive(true);
            fondo.SetActive(true);
        }
    }
    public void EscribirPregunta()     // Bot�n EscribirTextoPlano
    {
        // Concurrente
        StartCoroutine(SubirPregunta());
        
        //hide = !hide; 
        pantallaPregunta.SetActive(true);
        pantallaContestar.SetActive(false); 
        //Time.timeScale = hide ? 0 : 1f;
    }

    public void EscribirPregunta2()
    {
        pantallaWinner.SetActive(false);
        pantallaGameOver.SetActive(false);
        pantallaWinner = PantallaWinner2;
        pantallaGameOver = PantallaGameOver2;

        StartCoroutine(SubirPregunta());
        
        textoPregunta = textoPregunta2;
        opcion1 = opcion1_2;
        opcion2 = opcion2_2;
        opcion3 = opcion3_2;
        opcion4 = opcion4_2;
        
        PantallaPregunta2.SetActive(true);
        pantallaWinner.SetActive(false);
        pantallaGameOver.SetActive(false); 
        pantallaContestar.SetActive(false);
    }

    public void EscribirPregunta3()
    {
        PantallaWinner2.SetActive(false);
        PantallaGameOver2.SetActive(false);
        PantallaPregunta2.SetActive(false);
        pantallaWinner = PantallaWinnerFinal;
        pantallaGameOver = PantallaGameOverFinal;

        StartCoroutine(SubirPregunta());

        textoPregunta = textoPreguntaFinal;
        opcion1 = opcion1Final;
        opcion2 = opcion2Final;
        opcion3 = opcion3Final;
        opcion4 = opcion4Final;
        
        PantallaPregunta3.SetActive(true);
        pantallaWinner.SetActive(false);
        pantallaGameOver.SetActive(false);
        pantallaContestar.SetActive(false); 
        
    }
    private IEnumerator SubirPregunta()
    {
        // Encapsular los datos que se suben a la red con el m�todo POST
        WWWForm forma = new WWWForm();
        UnityWebRequest request;
        if (SceneManager.GetActiveScene().name == "Nivel1")
        {
            request = UnityWebRequest.Get("http://Localhost:8080/pregunta/buscarPreguntaNivel1");   
        } else if (SceneManager.GetActiveScene().name == "Nivel2")
        {
            request = UnityWebRequest.Get("http://Localhost:8080/pregunta/buscarPreguntaNivel2");   
        } else if (SceneManager.GetActiveScene().name == "Nivel3")
        {
            request = UnityWebRequest.Get("http://Localhost:8080/pregunta/buscarPreguntaNivel3");
        }else if (SceneManager.GetActiveScene().name == "Nivel4")
        {
            request = UnityWebRequest.Get("http://Localhost:8080/pregunta/buscarPreguntaNivel4");   
        }
        else
        {
            request = UnityWebRequest.Get("http://Localhost:8080/pregunta/buscarPreguntaNivel5");   
        }

        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.Success)  //200 OK
        {
            string pregunta = request.downloadHandler.text;  //Datos descargados de la red
            string[] arregloP = pregunta.Split('&');
            textoPregunta.text = arregloP[0];
            opcion1.text = arregloP[1];
            opcion2.text = arregloP[2];
            opcion3.text = arregloP[3];
            opcion4.text = arregloP[4];
            respuestaCorrecta.text = arregloP[5];
            idPregunta.text = arregloP[6];
        }
        else
        {
            textoPregunta.text = "Error en la descarga: " + request.responseCode.ToString(); 
        }
    }


    public void Validar1()
    {
        if (opcion1.text == respuestaCorrecta.text)
        {
            StartCoroutine(MandarOp1());
            //Time.timeScale = 1;
            //Destroy(gameObject, 1);
            VidasPersonaje.instance.monedas += 10;
            HUD.instance.ActualizarMonedas();
            pantallaWinner.SetActive(true);
        }
        else
        {
            StartCoroutine(MandarOp1());
            Time.timeScale = 1;
            pantallaGameOver.SetActive(true);
            //Destroy(gameObject, 1);
        }

        //PasarNivel();
    }

    public void Validar2()
    {
        if (opcion2.text == respuestaCorrecta.text)
        {
            StartCoroutine(MandarOp2());
            Time.timeScale = 1;
            Destroy(gameObject, 1);
            VidasPersonaje.instance.monedas += 10;
            HUD.instance.ActualizarMonedas();

        }
        else
        {
            StartCoroutine(MandarOp2());
            Time.timeScale = 1;
            Destroy(gameObject, 1);
        }

        PasarNivel();
    }

    public void Validar3()
    {
        if (opcion3.text == respuestaCorrecta.text)
        {
            StartCoroutine(MandarOp3());
            Time.timeScale = 1;
            Destroy(gameObject, 1);
            VidasPersonaje.instance.monedas += 10;
            HUD.instance.ActualizarMonedas();
        }
        else
        {
            StartCoroutine(MandarOp3());
            Time.timeScale = 1;
            Destroy(gameObject, 1);
        }

        PasarNivel();
    }

    public void Validar4()
    {
        if (opcion4.text == respuestaCorrecta.text)
        {
            StartCoroutine(MandarOp4());
            Time.timeScale = 1;
            Destroy(gameObject, 1);
            VidasPersonaje.instance.monedas += 10;
            HUD.instance.ActualizarMonedas();
        }
        else
        {
            StartCoroutine(MandarOp4());
            Time.timeScale = 1;
            Destroy(gameObject, 1);
        }

        PasarNivel();
    }

    //Revisa el puntaje para comprobar que se tenga un m�nimo para poder desbloquear el siguiente nivel.
    public void PasarNivel()
    {
        if (VidasPersonaje.instance.monedas > -1)
        {
            pantallaWinner.SetActive(true); //Se activa el panel de ganador
            niveel = sigNivel;
            SceneManager.LoadScene("MapaNiveles"); //Desbloquea el siguiente nivel
            red.tiempopuntaje(VidasPersonaje.instance.monedas);
        }
        else
        {
            pantallaGameOver.SetActive(true); //Se activa panel de juego perdido
            niveel = nivel;
            SceneManager.LoadScene("MapaNiveles"); //Regresa al mapa de niveles.
            red.tiempopuntaje(VidasPersonaje.instance.monedas);
        }
    }
    

    private IEnumerator MandarOp1()
    {
        WWWForm forma = new WWWForm();
        forma.AddField("opcionContestada", opcion1.text);
        forma.AddField("preguntumIdPregunta", Convert.ToInt32(idPregunta.text));
        if (String.IsNullOrEmpty(Registro.nombre))
        {
            forma.AddField("jugadorUsername", Red.nombre);
        }
        else
        {
            forma.AddField("jugadorUsername", Registro.nombre);
        }
        if (opcion1.text == respuestaCorrecta.text)
        {
            forma.AddField("estado", "Correcta");

        }
        else
        {
            forma.AddField("estado", "Incorrecto");

        }
        UnityWebRequest request = UnityWebRequest.Post("http://Localhost:8080/preguntaContestada/agregarPreguntaContestada", forma);
        yield return request.SendWebRequest();
    }

    private IEnumerator MandarOp2()
    {
        WWWForm forma = new WWWForm();
        forma.AddField("opcionContestada", opcion2.text);
        forma.AddField("preguntumIdPregunta", Convert.ToInt32(idPregunta.text));
        if (String.IsNullOrEmpty(Registro.nombre))
        {
            forma.AddField("jugadorUsername", Red.nombre);
        }
        else
        {
            forma.AddField("jugadorUsername", Registro.nombre);
        }
        if (opcion2.text == respuestaCorrecta.text)
        {
            forma.AddField("estado", "Correcta");

        }
        else
        {
            forma.AddField("estado", "Incorrecto");

        }
        UnityWebRequest request = UnityWebRequest.Post("http://Localhost:8080/preguntaContestada/agregarPreguntaContestada", forma);
        yield return request.SendWebRequest();
    }

    private IEnumerator MandarOp3()
    {
        WWWForm forma = new WWWForm();
        forma.AddField("opcionContestada", opcion3.text);
        forma.AddField("preguntumIdPregunta", Convert.ToInt32(idPregunta.text));
        if (String.IsNullOrEmpty(Registro.nombre))
        {
            forma.AddField("jugadorUsername", Red.nombre);
        }
        else
        {
            forma.AddField("jugadorUsername", Registro.nombre);
        }
        if (opcion3.text == respuestaCorrecta.text)
        {
            forma.AddField("estado", "Correcta");

        }
        else
        {
            forma.AddField("estado", "Incorrecto");

        }
        UnityWebRequest request = UnityWebRequest.Post("http://Localhost:8080/preguntaContestada/agregarPreguntaContestada", forma);
        yield return request.SendWebRequest();
    }

    private IEnumerator MandarOp4()
    {
        WWWForm forma = new WWWForm();
        forma.AddField("opcionContestada", opcion4.text);
        forma.AddField("preguntumIdPregunta", Convert.ToInt32(idPregunta.text));
        if (String.IsNullOrEmpty(Registro.nombre))
        {
            forma.AddField("jugadorUsername", Red.nombre);
        }
        else
        {
            forma.AddField("jugadorUsername", Registro.nombre);
        }
        if (opcion4.text == respuestaCorrecta.text)
        {
            forma.AddField("estado", "Correcta");

        }
        else
        {
            forma.AddField("estado", "Incorrecto");

        }
        UnityWebRequest request = UnityWebRequest.Post("http://Localhost:8080/preguntaContestada/agregarPreguntaContestada", forma);
        yield return request.SendWebRequest();
    }
}
