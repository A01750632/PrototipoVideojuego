using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* 
 * Agrega el canvas de trama de la historia al inicio de cada nivel
 * 
 * Autores: 
 * Jorge Chávez Badillo            A01749448
 * Ariadna Jocelyn Guzmán Jiménez  A01749373
 * Liam Garay Monroy               A01750632
 * Amy Murakami Tsutsumi           A01750185
 * Andrea Vianey Díaz Álvarez      A01750147
 */

public class Trama : MonoBehaviour
{
    public GameObject trama; //Canvas trama
    // Start is called before the first frame update
    void Start()
    {
        trama.SetActive(true); //Activa la trama correspondiente al inicio del nivel
        Destroy(trama,20); //La destruye en 20 segundos
    }

    public void Empezar()
    {
        Destroy(trama, 0.2f); //Destruye el canvas trama cuando presiona el botón empezar
    }


}
