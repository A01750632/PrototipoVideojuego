using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using UnityEngine.SceneManagement;
/*
 * Canvas que activa las 3 preguntas del enemigo final con pistas
 *
 * Autores: 
 * Jorge Chávez Badillo            A01749448
 * Ariadna Jocelyn Guzmán Jiménez  A01749373
 * Liam Garay Monroy               A01750632
 * Amy Murakami Tsutsumi           A01750185
 * Andrea Vianey Díaz Álvarez      A01750147
 */

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
    public int sigNivel = SeleccionarNivel.nivel; //Siguiente nivel.
    public static int niveel;
    public Red red;

    
    public Text categoria;
    public Text categoria2;
    public Text categoría3;
    public Text textoPista; //Texto que guarda la pista
    public GameObject textPista; //Activar el objeto texto
    public GameObject panelPista; //Panel con imagen
    
    public GameObject textPista2; //Activar el objeto texto
    public GameObject panelPista2; //Panel con imagen
    
    public GameObject textPista3; //Activar el objeto texto
    public GameObject panelPista3; //Panel con imagen
    
    public GameObject botonCiencias;
    public GameObject botonTecnologia;
    public GameObject botonArtes;
    public GameObject botonMate;
    public Text textoPista2;
    public GameObject botonCiencias2;
    public GameObject botonTecnologia2;
    public GameObject botonArtes2;
    public GameObject botonMate2;
    public Text textoPista3;
    public GameObject botonCiencias3;
    public GameObject botonTecnologia3;
    public GameObject botonArtes3;
    public GameObject botonMate3;
    public GameObject PantallaWINNER;
    public GameObject PantallaGAMEOVER;

    public int intentos;

    // Campos con la informaci�n de respuestas
    // Leer textoPregunta de la base de datos 

    void Start()
    {
        intentos = PlayerPrefs.GetInt("intentos");
    }
    public void colisiono(int col)
    {
        niveel = nivel;
        if (col == 1)
        {
            fondo.SetActive(true);
            pantallaContestar.SetActive(true);
            
        }
    }
    public void EscribirPregunta()     // Bot�n EscribirTextoPlano
    {
        // Concurrente
        StartCoroutine(SubirPregunta());
        
        hide = !hide; 
        pantallaPregunta.SetActive(hide);
        pantallaContestar.SetActive(false); 
        //Time.timeScale = hide ? 0 : 1f;
    }

    public void EscribirPregunta2()
    {
        fondo.SetActive(true);
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
        categoria = categoria2;
        textoPista = textoPista2;
        textPista = textPista2;
        panelPista = panelPista2;
        botonCiencias = botonCiencias2;
        botonTecnologia = botonTecnologia2;
        botonArtes = botonArtes2;
        botonMate = botonMate2;
        
        PantallaPregunta2.SetActive(true);
        pantallaWinner.SetActive(false);
        pantallaGameOver.SetActive(false); 
        pantallaContestar.SetActive(false);
    }

    public void EscribirPregunta3()
    {
        fondo.SetActive(true);
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
        categoria = categoría3;
        textoPista = textoPista3;
        textPista = textPista3;
        panelPista = panelPista3;
        botonCiencias = botonCiencias3;
        botonTecnologia = botonTecnologia3;
        botonArtes = botonArtes3;
        botonMate = botonMate3;
        
        PantallaPregunta3.SetActive(true);
        pantallaWinner.SetActive(false);
        pantallaGameOver.SetActive(false);
        pantallaContestar.SetActive(false); 
        
    }
    
    public void Pista()
    {
        panelPista.SetActive(true);
        textPista.SetActive(true);
        intentos=intentos-1;
        PlayerPrefs.SetInt("intentos", intentos);
        PlayerPrefs.Save();
        print(intentos);
    }
    private IEnumerator SubirPregunta()
    {
        // Encapsular los datos que se suben a la red con el m�todo POST
        WWWForm forma = new WWWForm();
        UnityWebRequest request;
        if (SceneManager.GetActiveScene().name == "Nivel1")
        {
            request = UnityWebRequest.Get("http://3.22.38.105:8080/pregunta/buscarPreguntaNivel1");  //3.22.38.105 
        } else if (SceneManager.GetActiveScene().name == "Nivel2")
        {
            request = UnityWebRequest.Get("http://3.22.38.105:8080/pregunta/buscarPreguntaNivel2"); //3.22.38.105  
        } else if (SceneManager.GetActiveScene().name == "Nivel3")
        {
            request = UnityWebRequest.Get("http://3.22.38.105:8080/pregunta/buscarPreguntaNivel3");//3.22.38.105
        } else if (SceneManager.GetActiveScene().name == "Nivel4")
        {
            request = UnityWebRequest.Get("http://3.22.38.105:8080/pregunta/buscarPreguntaNivel4");  //3.22.38.105 
        }
        else
        {
            request = UnityWebRequest.Get("http://3.22.38.105:8080/pregunta/buscarPreguntaNivel5");   //3.22.38.105
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
            categoria.text = arregloP[7];
            textoPista.text = arregloP[8];
            
            if (intentos > 0){
                if(categoria.text == "Ciencia"){
                    botonCiencias.SetActive(true);

                }
                else if(categoria.text == "Tecnología"){
                    botonTecnologia.SetActive(true); 
                }
                else if(categoria.text == "Artes"){
                    botonArtes.SetActive(true); 
           
                }
                else{
                    botonMate.SetActive(true); 
                }
            }
            else
            {
                textoPista.text = "Ya no tienes pistas";
                textPista.SetActive(true);
                
            }
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
            botonCiencias.SetActive(false);
            botonTecnologia.SetActive(false);
            botonArtes.SetActive(false);
            botonMate.SetActive(false);
            textPista.SetActive(false);
            panelPista.SetActive(false);
            pantallaWinner.SetActive(true);
            Destroy(pantallaWinner, 20);
        }
        else
        {
            StartCoroutine(MandarOp1());
            //Time.timeScale = 1;
            botonCiencias.SetActive(false);
            botonTecnologia.SetActive(false);
            botonArtes.SetActive(false);
            botonMate.SetActive(false);
            textPista.SetActive(false);
            panelPista.SetActive(false);
            pantallaGameOver.SetActive(true);
            Destroy(pantallaGameOver, 5);
        }
    }

    public void Validar2()
    {
        if (opcion2.text == respuestaCorrecta.text)
        {
            StartCoroutine(MandarOp2());
            //Time.timeScale = 1;
            //Destroy(gameObject, 1);
            VidasPersonaje.instance.monedas += 10;
            HUD.instance.ActualizarMonedas();
            botonCiencias.SetActive(false);
            botonTecnologia.SetActive(false);
            botonArtes.SetActive(false);
            botonMate.SetActive(false);
            textPista.SetActive(false);
            panelPista.SetActive(false);
            pantallaWinner.SetActive(true);
            Destroy(pantallaWinner, 5);

        }
        else
        {
            StartCoroutine(MandarOp2());
            //Time.timeScale = 1;
            //Destroy(gameObject, 1);
            botonCiencias.SetActive(false);
            botonTecnologia.SetActive(false);
            botonArtes.SetActive(false);
            botonMate.SetActive(false);
            textPista.SetActive(false);
            panelPista.SetActive(false);
            pantallaGameOver.SetActive(true);
            Destroy(pantallaGameOver, 5);
        }
    }

    public void Validar3()
    {
        if (opcion3.text == respuestaCorrecta.text)
        {
            StartCoroutine(MandarOp3());
            //Time.timeScale = 1;
            //Destroy(gameObject, 1);
            VidasPersonaje.instance.monedas += 10;
            HUD.instance.ActualizarMonedas();
            botonCiencias.SetActive(false);
            botonTecnologia.SetActive(false);
            botonArtes.SetActive(false);
            botonMate.SetActive(false);
            textPista.SetActive(false);
            panelPista.SetActive(false);
            pantallaWinner.SetActive(true);
            Destroy(pantallaWinner, 5);
        }
        else
        {
            StartCoroutine(MandarOp3());
            //Time.timeScale = 1;
            //Destroy(gameObject, 1);
            botonCiencias.SetActive(false);
            botonTecnologia.SetActive(false);
            botonArtes.SetActive(false);
            botonMate.SetActive(false);
            textPista.SetActive(false);
            panelPista.SetActive(false);
            pantallaGameOver.SetActive(true);
            Destroy(pantallaGameOver, 5);
        }
    }

    public void Validar4()
    {
        if (opcion4.text == respuestaCorrecta.text)
        {
            StartCoroutine(MandarOp4());
            //Time.timeScale = 1;
            //Destroy(gameObject, 1);
            VidasPersonaje.instance.monedas += 10;
            HUD.instance.ActualizarMonedas();
            botonCiencias.SetActive(false);
            botonTecnologia.SetActive(false);
            botonArtes.SetActive(false);
            botonMate.SetActive(false);
            textPista.SetActive(false);
            panelPista.SetActive(false);
            pantallaWinner.SetActive(true);
            Destroy(pantallaWinner, 5);
        }
        else
        {
            StartCoroutine(MandarOp4());
            //Time.timeScale = 1;
            //Destroy(gameObject, 1);
            botonCiencias.SetActive(false);
            botonTecnologia.SetActive(false);
            botonArtes.SetActive(false);
            botonMate.SetActive(false);
            textPista.SetActive(false);
            panelPista.SetActive(false);
            pantallaGameOver.SetActive(true);
            Destroy(pantallaGameOver, 5);
        }
    }

    //Revisa el puntaje para comprobar que se tenga un m�nimo para poder desbloquear el siguiente nivel.
    public void PasarNivel()
    {
        if (VidasPersonaje.instance.monedas > 180) //Condicion de para pasar de nivel
        {
            PantallaWINNER.SetActive(true); //Se activa el panel de ganador
            niveel = sigNivel;
            SceneManager.LoadScene("MapaNiveles"); //Desbloquea el siguiente nivel
            red.tiempopuntaje(VidasPersonaje.instance.monedas);
            
            PlayerPrefs.SetInt("intentos",2);
            PlayerPrefs.Save();
            Time.timeScale = 1; //Corre el tiempo para el siguiente nivel

            red.actualizarNivel(nivel);  //actualiza el nuevo nivel desbloqueado

        }
        else
        {
            PantallaGAMEOVER.SetActive(true); //Se activa panel de juego perdido
            niveel = nivel;
            SceneManager.LoadScene("MapaNiveles"); //Regresa al mapa de niveles.
            red.tiempopuntaje(VidasPersonaje.instance.monedas);
            PlayerPrefs.SetInt("intentos",2);
            PlayerPrefs.Save();
            Time.timeScale = 1; //Corre el tiempo para el siguiente nivel
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
        UnityWebRequest request = UnityWebRequest.Post("http://3.22.38.105:8080/preguntaContestada/agregarPreguntaContestada", forma); //3.22.38.105
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
        UnityWebRequest request = UnityWebRequest.Post("http://3.22.38.105:8080/preguntaContestada/agregarPreguntaContestada", forma); //3.22.38.105
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
        UnityWebRequest request = UnityWebRequest.Post("http://3.22.38.105:8080/preguntaContestada/agregarPreguntaContestada", forma); //3.22.38.105
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
        UnityWebRequest request = UnityWebRequest.Post("http://3.22.38.105:8080/preguntaContestada/agregarPreguntaContestada", forma); //3.22.38.105
        yield return request.SendWebRequest();
    }
}
