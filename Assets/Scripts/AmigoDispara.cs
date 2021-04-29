using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Disparo del amigo automático cada 1.5f segundos
 *
 * Autores: 
 * Jorge Chávez Badillo            A01749448
 * Ariadna Jocelyn Guzmán Jiménez  A01749373
 * Liam Garay Monroy               A01750632
 * Amy Murakami Tsutsumi           A01750185
 * Andrea Vianey Díaz Álvarez      A01750147
 */

public class AmigoDispara : MonoBehaviour
{
    public Proyectil proyectil;

    public int direccionDerecha = +1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerarDisparo()); 
    }

    public void CambiarDireccion(int direccion) //Cambia direccion del amigo de acuerdo a la dirección del personaje
    {
        direccionDerecha=direccion;
    }
    private IEnumerator GenerarDisparo()
    {
        while(true)     //Ciclo infinito
        {
            yield  return new WaitForSeconds(1.5f); //Espera para crear otro proyectil
            //Continuar..
            Proyectil nuevo = Instantiate(proyectil);  //COPIA, clona
            nuevo.transform.position = gameObject.transform.position; //El proyectil se coloca en la posición del amigo
            nuevo.CambiarDireccion(direccionDerecha); //Cambia la direccion de acuerdo con el amigo y personaje
            nuevo.gameObject.SetActive(true); //Amigo dispara el proyectil

        }
    }
}