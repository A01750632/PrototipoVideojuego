using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
Controla el menú.
Agregamos los métodos para atender los componentes del menú

Autores: 
Jorge Chávez Badillo            A01749448
Ariadna Jocelyn Guzmán Jiménez  A01749373
Liam Garay Monroy               A01750632
Amy Murakami Tsutsumi           A01750185
Andrea Vianey Díaz Álvarez      A01750147
 */

public class Menu : MonoBehaviour
{
    public static float tiempoInicial;
    public bool hide;
    public GameObject opciones;
    public GameObject creditos; 
    
    public void IniciarJuego(){
        // Cambiar escena
        tiempoInicial = Time.time;
        SceneManager.LoadScene("MapaNiveles");
    }

    public void Opciones()
    {
        hide = !hide;
        opciones.SetActive(hide);
    }

    public void Creditos(){
        hide = !hide; 
        creditos.SetActive(hide); 
    }

    public void Salir(){
        // Regresa al Sistema Operativo
        Application.Quit();
    }
}