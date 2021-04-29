using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/* 
 * Habilita y carga la escena si el jugador pasa de nivel
 * 
 * Autores: 
 * Jorge Chávez Badillo            A01749448
 * Ariadna Jocelyn Guzmán Jiménez  A01749373
 * Liam Garay Monroy               A01750632
 * Amy Murakami Tsutsumi           A01750185
 * Andrea Vianey Díaz Álvarez      A01750147
 */

public class MoverSiguienteNivel : MonoBehaviour
{
    public int cargarProxEscena;
    // Start is called before the first frame update
    void Start()
    {
        cargarProxEscena = SceneManager.GetActiveScene().buildIndex + 1; //Cargar escena del siguiente nivel
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (SceneManager.GetActiveScene().buildIndex == 8)  //Cargar escena del último nivel, el build index del último nivel es 8
            {
                Debug.Log("Comletaste todos los niveles"); //Jugador completa todos los niveles
            }
            else
            {
                //Carga escena del siguiente nivel
                SceneManager.LoadScene(cargarProxEscena);

                //Bloqueo de los botones de nivel
                if (cargarProxEscena > PlayerPrefs.GetInt("posNiv"))
                {
                    PlayerPrefs.SetInt("posNiv", cargarProxEscena);
                }
            }
        }
    }
}
