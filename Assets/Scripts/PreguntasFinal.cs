using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;
using System; 
public class PreguntasFinal : MonoBehaviour
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
    /*--------------------------CAMBIOS----------------------------------*/
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
        StartCoroutine(BuscarIdPregunta());

        //hide = !hide; 
        pantallaPregunta.SetActive(true);
        pantallaContestar.SetActive(false); 
        //Time.timeScale = hide ? 0 : 1f;
    }
    
    /*-------------------------------Cambios -----------------------------------------------------*/
    public void EscribirPregunta2()
    {
        pantallaWinner.SetActive(false);
        pantallaGameOver.SetActive(false);
        pantallaWinner = PantallaWinner2;
        pantallaGameOver = PantallaGameOver2;
        
        
        StartCoroutine(SubirPregunta());
        StartCoroutine(SubirOpcion1());
        StartCoroutine(SubirOpcion2());
        StartCoroutine(SubirOpcion3());
        StartCoroutine(SubirOpcion4());
        StartCoroutine(GuardarCorrecta());
        StartCoroutine(BuscarIdPregunta());
        
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
        StartCoroutine(SubirOpcion1());
        StartCoroutine(SubirOpcion2());
        StartCoroutine(SubirOpcion3());
        StartCoroutine(SubirOpcion4());
        StartCoroutine(GuardarCorrecta());
        StartCoroutine(BuscarIdPregunta());
        
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

    public void Pasar()
    {
        SceneManager.LoadScene("Nivel3");
    }
    private IEnumerator SubirPregunta()
    {
        // Encapsular los datos que se suben a la red con el método POST
        WWWForm forma = new WWWForm();

        UnityWebRequest request = UnityWebRequest.Get("http://Localhost:8080/pregunta/buscarPreguntaNivel4"); 

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

        UnityWebRequest request1 = UnityWebRequest.Get("http://Localhost:8080/pregunta/buscarOpcion1Nivel4"); 
        
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

        UnityWebRequest request2 = UnityWebRequest.Get("http://Localhost:8080/pregunta/buscarOpcion2Nivel4"); 
        
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

        UnityWebRequest request3 = UnityWebRequest.Get("http://Localhost:8080/pregunta/buscarOpcion3Nivel4"); 
        
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
        UnityWebRequest request4 = UnityWebRequest.Get("http://Localhost:8080/pregunta/buscarOpcion4Nivel4"); 

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
        UnityWebRequest request6 = UnityWebRequest.Get("http://Localhost:8080/pregunta/buscarRespuestaCorrectaNivel4"); 

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
            StartCoroutine(MandarOp2());
            pantallaWinner.SetActive(true);
        }
        else{
            StartCoroutine(MandarOp2());
            pantallaGameOver.SetActive(true);
        }
    }

    public void Validar3() 
    {
        if(opcion3.text == respuestaCorrecta.text){
            StartCoroutine(MandarOp3());
            pantallaWinner.SetActive(true);
        }
        else{
            StartCoroutine(MandarOp3());
            pantallaGameOver.SetActive(true);
        }
    }

    public void Validar4()
    {
        if(opcion4.text == respuestaCorrecta.text){
            StartCoroutine(MandarOp4());
            pantallaWinner.SetActive(true);
        }
        else{
            StartCoroutine(MandarOp4());
            pantallaGameOver.SetActive(true);
        }
    }

    public IEnumerator BuscarIdPregunta(){
        WWWForm forma = new WWWForm();
        UnityWebRequest request = UnityWebRequest.Get("http://Localhost:8080/pregunta/buscarIdPreguntaNivel4"); 

        yield return request.SendWebRequest();  

        if (request.result == UnityWebRequest.Result.Success) 
        {
            string id = request.downloadHandler.text;
            idPregunta.text = id; 
        }
        else
        {
            idPregunta.text = "Error en la descarga: " + request.responseCode.ToString(); 
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
        UnityWebRequest request = UnityWebRequest.Post("http://Localhost:8080/preguntaContestada/agregarPreguntaContestada", forma); 
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
        UnityWebRequest request = UnityWebRequest.Post("http://Localhost:8080/preguntaContestada/agregarPreguntaContestada", forma); 
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
        UnityWebRequest request = UnityWebRequest.Post("http://Localhost:8080/preguntaContestada/agregarPreguntaContestada", forma); 
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
        UnityWebRequest request = UnityWebRequest.Post("http://Localhost:8080/preguntaContestada/agregarPreguntaContestada", forma); 
        yield return request.SendWebRequest(); 
    }
}