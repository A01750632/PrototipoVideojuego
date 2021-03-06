using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Prueba si el colider esta fuera o dentro de una plataforma.
 *
 * Autores: 
 * Jorge Chávez Badillo            A01749448
 * Ariadna Jocelyn Guzmán Jiménez  A01749373
 * Liam Garay Monroy               A01750632
 * Amy Murakami Tsutsumi           A01750185
 * Andrea Vianey Díaz Álvarez      A01750147
 */

public class PruebaPiso : MonoBehaviour
{
    public static bool estaEnPiso = false; //Booleano que indica si el personaje está tocando el piso

    //Se ejecuta cuando el collider Entra a otro collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Oro") //Personaje choca con colider que no sea el de oro
        {
            estaEnPiso = true;
        }
    }

    //se ejecuta cuando el collider Sale de otro collider
    private void OnTriggerExit2D(Collider2D other)
    {
        estaEnPiso = false;
    }
}