using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Disparo del enemigo automático cada 1.35f segundos
 *
 * Autores: 
 * Jorge Chávez Badillo            A01749448
 * Ariadna Jocelyn Guzmán Jiménez  A01749373
 * Liam Garay Monroy               A01750632
 * Amy Murakami Tsutsumi           A01750185
 * Andrea Vianey Díaz Álvarez      A01750147
 */
public class EnemigoDispara : MonoBehaviour
{
    public Proyectil proyectil;

    //Render del enemigo
    private SpriteRenderer rendererEnemigo;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerarDisparo());
        rendererEnemigo = GetComponent<SpriteRenderer>();   
    }

    private IEnumerator GenerarDisparo()
    {
        while(true)     //Ciclo infinito
        {
            yield  return new WaitForSeconds(1.35f); //Espera para crear otro proyectil
            //Continuar..
            Proyectil nuevo = Instantiate(proyectil); //Crear nuevo proyectil
            nuevo.transform.position = gameObject.transform.position; //El proyectil se coloca en la posición del enemigo
            nuevo.gameObject.SetActive(true); //Enemigo dispara el proyectil
            
            if(rendererEnemigo.flipX == false) //Cambiar dirección del enemigo
            {
                nuevo.CambiarDireccion(-1);
            }
            else
            {
                nuevo.CambiarDireccion(1);
            }
            nuevo.Destruir(0.45f); //Destruye el proyectil
        }
    }
}
