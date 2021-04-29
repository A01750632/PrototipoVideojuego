using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
/*
 * Canvas que despliega una pregunta para obtener la ayuda del Amigo
 *
 * Autores: 
 * Jorge Chávez Badillo            A01749448
 * Ariadna Jocelyn Guzmán Jiménez  A01749373
 * Liam Garay Monroy               A01750632
 * Amy Murakami Tsutsumi           A01750185
 * Andrea Vianey Díaz Álvarez      A01750147
 */

public class CanvasAmigo : MonoBehaviour
{
// Para desplegar la información

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
    public CanvasAmigo instanceAmigo;

    public GameObject fondo;

    public MoverAmigo amigo;

    

    
    // Campos con la información de respuestas
    // Leer textoPregunta de la base de datos 


    public void colisiono(int col)
    {
     if(col == 1){
         pantallaContestar.SetActive(true);
         fondo.SetActive(true);
     }   
    }
    public void EscribirPregunta()     // Botón EscribirTextoPlano
    {
        // Concurrente
        StartCoroutine(SubirPregunta());
        
        
        hide = !hide; 
        pantallaPregunta.SetActive(hide);
        pantallaContestar.SetActive(false); 
        Time.timeScale = hide ? 0 : 1f;
    }
    private IEnumerator SubirPregunta()
    {
        WWWForm forma = new WWWForm();
        UnityWebRequest request;
        if (SceneManager.GetActiveScene().name == "Nivel1")
        {
            request = UnityWebRequest.Get("http://3.22.38.105:8080/pregunta/buscarPreguntaNivel1");   //3.22.38.105
        } else if (SceneManager.GetActiveScene().name == "Nivel2")
        {
            request = UnityWebRequest.Get("http://3.22.38.105:8080/pregunta/buscarPreguntaNivel2");   //3.22.38.105
        } else if (SceneManager.GetActiveScene().name == "Nivel3")
        {
            request = UnityWebRequest.Get("http://3.22.38.105:8080/pregunta/buscarPreguntaNivel3"); //3.22.38.105
        }else if (SceneManager.GetActiveScene().name == "Nivel4")
        {
            request = UnityWebRequest.Get("http://3.22.38.105:8080/pregunta/buscarPreguntaNivel4");  //3.22.38.105 
        }
        else
        {
            request = UnityWebRequest.Get("http://3.22.38.105:8080/pregunta/buscarPreguntaNivel5");   //3.22.38.105
        }

        yield return request.SendWebRequest();   //Regresa, ejecuta, espera...
        
        if (request.result == UnityWebRequest.Result.Success) //200 OK
        {
            string pregunta = request.downloadHandler.text; //Datos descargados de la red
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
        if (opcion1.text == respuestaCorrecta.text) {
            StartCoroutine(MandarOp1());
            pantallaWinner.SetActive(true);
            Time.timeScale = 1;
            Destroy(gameObject, 1);
            amigo.gameObject.SetActive(true);
            VidasPersonaje.instance.monedas += 10;
            HUD.instance.ActualizarMonedas();

        }
        else{
            StartCoroutine(MandarOp1());
            pantallaGameOver.SetActive(true);
            Time.timeScale = 1;
            Destroy(gameObject, 1);
        }
    }

    public void Validar2()
    {
        if(opcion2.text == respuestaCorrecta.text){
            StartCoroutine(MandarOp2());
            pantallaWinner.SetActive(true);
            Time.timeScale = 1;
            Destroy(gameObject, 1);
            amigo.gameObject.SetActive(true);
            VidasPersonaje.instance.monedas += 10;
            HUD.instance.ActualizarMonedas();

        }
        else{
            StartCoroutine(MandarOp2());
            pantallaGameOver.SetActive(true);
            Time.timeScale = 1;
            Destroy(gameObject, 1);
        }
    }

    public void Validar3() 
    {
        if(opcion3.text == respuestaCorrecta.text){
            StartCoroutine(MandarOp3());
            pantallaWinner.SetActive(true);
            Time.timeScale = 1;
            Destroy(gameObject, 1);
            amigo.gameObject.SetActive(true);
            VidasPersonaje.instance.monedas += 10;
            HUD.instance.ActualizarMonedas();
        }
        else{
            StartCoroutine(MandarOp3());
            pantallaGameOver.SetActive(true);
            Time.timeScale = 1;
            Destroy(gameObject, 1);
        }
    }

    public void Validar4()
    {
        if(opcion4.text == respuestaCorrecta.text){
            StartCoroutine(MandarOp4());
            pantallaWinner.SetActive(true);
            Time.timeScale = 1;
            Destroy(gameObject, 1);
            amigo.gameObject.SetActive(true);
            VidasPersonaje.instance.monedas += 10;
            HUD.instance.ActualizarMonedas();
        }
        else{
            StartCoroutine(MandarOp4());
            pantallaGameOver.SetActive(true);
            Time.timeScale = 1;
            Destroy(gameObject, 1);
        }
    }
    
    private IEnumerator MandarOp1()
    {
        WWWForm forma = new  WWWForm();
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
        if(opcion1.text == respuestaCorrecta.text){
            forma.AddField("estado", "Correcta");
            
        }
        else{
            forma.AddField("estado", "Incorrecto");

        }
        UnityWebRequest request = UnityWebRequest.Post("http://3.22.38.105:8080/preguntaContestada/agregarPreguntaContestada", forma); //3.22.38.105
        yield return request.SendWebRequest(); 
    }

    private IEnumerator MandarOp2()
    {
        WWWForm forma = new  WWWForm();
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
        if(opcion2.text == respuestaCorrecta.text){
            forma.AddField("estado", "Correcta");
            
        }
        else{
            forma.AddField("estado", "Incorrecto");

        }
        UnityWebRequest request = UnityWebRequest.Post("http://3.22.38.105:8080/preguntaContestada/agregarPreguntaContestada", forma); //3.22.38.105
        yield return request.SendWebRequest(); 
    }

    private IEnumerator MandarOp3()
    {
        WWWForm forma = new  WWWForm();
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
        if(opcion3.text == respuestaCorrecta.text){
            forma.AddField("estado", "Correcta");
            
        }
        else{
            forma.AddField("estado", "Incorrecto");

        }
        UnityWebRequest request = UnityWebRequest.Post("http://3.22.38.105:8080/preguntaContestada/agregarPreguntaContestada", forma); //3.22.38.105
        yield return request.SendWebRequest(); 
    }

    private IEnumerator MandarOp4()
    {
        WWWForm forma = new  WWWForm();
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
        if(opcion4.text == respuestaCorrecta.text){
            forma.AddField("estado", "Correcta");
             
        }
        else{
            forma.AddField("estado", "Incorrecto");

        }
        UnityWebRequest request = UnityWebRequest.Post("http://3.22.38.105:8080/preguntaContestada/agregarPreguntaContestada", forma); //3.22.38.105
        yield return request.SendWebRequest(); 
    }
}
