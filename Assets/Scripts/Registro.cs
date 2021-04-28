using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

/* Agrega los nuevos Registros 
 * Autor: Equipo1
 */

public class Registro : MonoBehaviour
{
    //Para desplegar la informaci�n
    public Text resultado;
    //Campos con la informaci�n nombre y puntos
    public Text textoNombre;
    public Text textoContrasena;
    public Text textoCorreo;
    public Text textoYear;
    public Text textoMes;
    public Text textoDia;
    public Text textoUsuario;
    public Text textoEstudiar;

    public Text textoGenero;
    public Text textoPais;
    public Text textoMateria;
    public Text textoNivel;
    private String textoNacimiento;
    public static Registro instance;
    public static String nombre;
    public Red red;

    //Inicializar los intentos para pista
    void Start()
    {
        PlayerPrefs.SetInt("intentos", 2);
        PlayerPrefs.Save();
    }
    // -------
    private void Awake(){
        instance = this; 
    }
    // -------

    public void volver()     //Bot�n
    {
        SceneManager.LoadScene("InicioSesion");
    }

    //Escribir
    public void EscribirRegistro()     //Bot�n
    {
        //Concurrente
        StartCoroutine(SubirRegistro());
    }


    private IEnumerator SubirRegistro()
    {
        if (textoNombre.text != "" && textoContrasena.text != "" && textoCorreo.text != "" && textoYear.text != "" && textoMes.text != "" && textoDia.text != "" && textoUsuario.text != "" && textoEstudiar.text != "" && textoGenero.text != "" && textoPais.text != "" && textoMateria.text != "" && textoNivel.text != "")
        {
            print(textoNombre.text);
            if (email_bien_escrito(textoCorreo.text.ToString()) == true)
            {
                //Revisar que el usuario no exita
                nombre = textoUsuario.text;
                WWWForm forma2 = new WWWForm();
                forma2.AddField("usuarioUsuarioo", textoUsuario.text);
                UnityWebRequest request2 = UnityWebRequest.Post("http://Localhost:8080/jugador/BuscarJugadorUnity", forma2); //3.22.38.105
                yield return request2.SendWebRequest();   //Regresa, ejecuta, espera...
                                                          //...ya regres� a la l�nea 27 (termin� de ejecutar SendWebRequest())
                if (request2.result == UnityWebRequest.Result.Success)  //200 OK
                {
                    string textoPlano2 = request2.downloadHandler.text;  //Datos descargados de la red
                    resultado.text = textoPlano2;
                    //Si el usuario no existe ya realiza el regs
                    if (textoPlano2 == "")
                    {
                        textoNacimiento = textoYear.text.ToString() + "-" + textoMes.text.ToString() + "-" + textoDia.text.ToString();
                        print(textoNacimiento);

                        //Encapsular los datos que se suben a la red con el m�todo POST
                        WWWForm forma = new WWWForm();

                        forma.AddField("Username", textoUsuario.text);
                        forma.AddField("CorreoElectronico", textoCorreo.text);
                        forma.AddField("password", textoContrasena.text);
                        forma.AddField("nombreUsuario", textoNombre.text);
                        forma.AddField("FechaNacimiento", textoNacimiento);
                        forma.AddField("genero", textoGenero.text);
                        forma.AddField("pais", textoPais.text);
                        forma.AddField("nivel", textoNivel.text);
                        forma.AddField("Carrera", textoEstudiar.text);
                        forma.AddField("materia", textoMateria.text);

                        UnityWebRequest request = UnityWebRequest.Post("http://Localhost:8080/jugador/AgregarJugadorUnity", forma); ////3.22.38.105
                        yield return request.SendWebRequest();

                        if (request.result == UnityWebRequest.Result.Success)  //200 OK
                        {
                            string textoPlano = request.downloadHandler.text;  //Datos descargados de la red
                            resultado.text = textoPlano;
                            SceneManager.LoadScene("EscenaMenu");

                        }
                        else
                        {
                            resultado.text = "Error en la descarga: " + request.responseCode.ToString();
                        }
                    }
                    else
                    {
                        resultado.text = "Usuario ya existente";
                    }
                }
                else
                {
                    resultado.text = "Error en la descarga: " + request2.responseCode.ToString();
                }
            }
            else
            {
                resultado.text = "Correo inválido";
            }
        }
        else
        {
            resultado.text = "Faltan Campos de llenar";
        }
    }

    private Boolean email_bien_escrito(String email)
    {
        String expresion;
        expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
        if (Regex.IsMatch(email, expresion))
        {
            if (Regex.Replace(email, expresion, String.Empty).Length == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}
