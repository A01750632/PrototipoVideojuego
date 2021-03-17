using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PruebaPiso : MonoBehaviour
{
    public static bool estaEnPiso = false;

    //Se ejecuta cuando el collider Entra a otro collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag != "Moneda")
        {
            estaEnPiso = true;
            print("Está en piso");
        }
    }

    //se ejecuta cuando el collider Sale de otro collider
    private void OnTriggerExit2D(Collider2D other)
    {
        estaEnPiso = false;
        print("No está en piso");
    }
}