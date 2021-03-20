using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Detecta la colision con una moneda

Autores:   
Jorge Chávez Badillo            A01749448
Ariadna Jocelyn Guzmán Jiménez  A01749373
Liam Garay Monroy               A01750632
Amy Murakami Tsutsumi           A01750185
Andrea Vianey Díaz Álvarez      A01750147
*/

public class Moneda : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D other)
   {
       // La moneda colisionó con otro objeto (colliders)
       if (other.gameObject.CompareTag("Player"))
       {
           // Recolectar
           //print("Recolectando");
           //Dejar de dibujar la moneda
           GetComponent<SpriteRenderer>().enabled = false;
           //prender la explosión
           //moneda.transform.hijo del transform(transform de la explosion).explosion se hace activa
           //gameObject.transform.GetChild(0).gameObject.SetActive(true);
           Destroy(gameObject, 0.8f);
       }
   }
}