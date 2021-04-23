using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
public class PreguntasFinal : MonoBehaviour
{
    // Para desplegar la información
    public Text textoPregunta;
    public Text opcion1; 
    public Text opcion2; 
    public Text opcion3;  
    public Text opcion4; 
    public Text respuestaCorrecta; 
    public static Red instance;
    public static PreguntasFinal instance2; 
    public GameObject pantallaPregunta; 
    public GameObject pantallaContestar; 
    private bool hide; 
    public GameObject pantallaGameOver;
    public GameObject pantallaWinner;

    // Campos con la información de respuestas
    // Leer textoPregunta de la base de datos 
    public void EscribirPregunta()     // Botón EscribirTextoPlano
    {
        // Concurrente
        StartCoroutine(SubirPregunta());
        StartCoroutine(SubirOpcion1());
        StartCoroutine(SubirOpcion2());
        StartCoroutine(SubirOpcion3());
        StartCoroutine(SubirOpcion4());
        StartCoroutine(GuardarCorrecta());

        hide = !hide; 
        pantallaPregunta.SetActive(hide);
        pantallaContestar.SetActive(false); 
        Time.timeScale = hide ? 0 : 1f;
    }
    private IEnumerator SubirPregunta()
    {
        // Encapsular los datos que se suben a la red con el método POST
        WWWForm forma = new WWWForm();

        UnityWebRequest request = UnityWebRequest.Get("http://Localhost:8080/pregunta/buscarPregunta"); 

        yield return request.SendWebRequest();   //Regresa, ejecuta, espera...
        //...ya regresó a la línea 27 (terminó de ejecutar SendWebRequest())

        if (request.result == UnityWebRequest.Result.Success)  //200 OK
        {
            string pregunta = request.downloadHandler.text;  //Datos descargados de la red
            textoPregunta.text = pregunta;
        }
        else
        {
            textoPregunta.text = "Error en la descarga: " + request.responseCode.ToString(); 
        }
    }

    private IEnumerator SubirOpcion1()
    {
        WWWForm forma = new WWWForm();

        UnityWebRequest request1 = UnityWebRequest.Get("http://Localhost:8080/pregunta/buscarOpcion1"); 
        
        yield return request1.SendWebRequest();

        if (request1.result == UnityWebRequest.Result.Success)
        {
            string op1 = request1.downloadHandler.text;
            opcion1.text = op1; 
        }
        else
        {
            opcion1.text = "Error en la descarga: " + request1.responseCode.ToString(); 
        }
    }

    private IEnumerator SubirOpcion2()
    {
        WWWForm forma = new WWWForm();

        UnityWebRequest request2 = UnityWebRequest.Get("http://Localhost:8080/pregunta/buscarOpcion2"); 
        
        yield return request2.SendWebRequest();

        if (request2.result == UnityWebRequest.Result.Success)
        {
            string op2 = request2.downloadHandler.text;
            opcion2.text = op2; 
        }
        else
        {
            opcion2.text = "Error en la descarga: " + request2.responseCode.ToString(); 
        }
    }

    private IEnumerator SubirOpcion3()
    {
        WWWForm forma = new WWWForm();

        UnityWebRequest request3 = UnityWebRequest.Get("http://Localhost:8080/pregunta/buscarOpcion3"); 
        
        yield return request3.SendWebRequest();

        if (request3.result == UnityWebRequest.Result.Success)
        {
            string op3 = request3.downloadHandler.text;
            opcion3.text = op3; 
        }
        else
        {
            opcion3.text = "Error en la descarga: " + request3.responseCode.ToString(); 
        }
    }
    
    private IEnumerator SubirOpcion4()
    {
        WWWForm forma = new WWWForm();
        UnityWebRequest request4 = UnityWebRequest.Get("http://Localhost:8080/pregunta/buscarOpcion4"); 

        yield return request4.SendWebRequest();  

        if (request4.result == UnityWebRequest.Result.Success)
        {
            string op4 = request4.downloadHandler.text;
            opcion4.text = op4; 
        }
        else
        {
            opcion4.text = "Error en la descarga: " + request4.responseCode.ToString(); 
        }
    }

    private IEnumerator GuardarCorrecta()
    {
        WWWForm forma = new WWWForm();
        UnityWebRequest request6 = UnityWebRequest.Get("http://Localhost:8080/pregunta/buscarRespuestaCorrecta"); 

        yield return request6.SendWebRequest();  

        if (request6.result == UnityWebRequest.Result.Success) 
        {
            string respuesta = request6.downloadHandler.text;
            respuestaCorrecta.text = respuesta; 
        }
        else
        {
            respuestaCorrecta.text = "Error en la descarga: " + request6.responseCode.ToString(); 
        }
    }

    public void Validar1()
    {
        print(Registro.nombre);
        if(opcion1.text == respuestaCorrecta.text){
            StartCoroutine(MandarOp1());
            pantallaWinner.SetActive(true);
        }
        else{
            StartCoroutine(MandarOp1());
            pantallaGameOver.SetActive(true);
        }
    }

    public void Validar2()
    {
        if(opcion2.text == respuestaCorrecta.text){
            pantallaWinner.SetActive(true);
        }
        else{
            pantallaGameOver.SetActive(true);
        }
    }

    public void Validar3() 
    {
        if(opcion3.text == respuestaCorrecta.text){
            pantallaWinner.SetActive(true);
        }
        else{
            pantallaGameOver.SetActive(true);
        }
    }

    public void Validar4()
    {
        if(opcion4.text == respuestaCorrecta.text){
            pantallaWinner.SetActive(true);
        }
        else{
            pantallaGameOver.SetActive(true);
        }
    }

    private IEnumerator MandarOp1()
    {
        WWWForm forma = new  WWWForm();
        forma.AddField("opcionContestada", opcion1.text);
        forma.AddField("jugadorUsername", Registro.instance.textoUsuario.text);
        //forma.AddField('opcionContestada', opcion1.text);
        
        if(opcion1.text == respuestaCorrecta.text){
            forma.AddField("estado", "Correcta");
            
        }
        else{
            forma.AddField("estado", "Incorrecto");

        }
        UnityWebRequest request = UnityWebRequest.Post("http://Localhost:8080/preguntaContestada/agregarPreguntaContestada", forma); 
        yield return request.SendWebRequest(); 
    }
}