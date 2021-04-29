using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Disparo vertical del enemigo pajaro automatico cada 1.35f segundos
 *
 * Autores: 
 * Jorge Ch�vez Badillo            A01749448
 * Ariadna Jocelyn Guzm�n Jim�nez  A01749373
 * Liam Garay Monroy               A01750632
 * Amy Murakami Tsutsumi           A01750185
 * Andrea Vianey D�az �lvarez      A01750147
 */

public class PajaroDispara : MonoBehaviour
{
    public Proyectil proyectil;

    //render del enemigo
    private SpriteRenderer rendererEnemigo;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerarDisparo());
        rendererEnemigo = GetComponent<SpriteRenderer>();
    }

    private IEnumerator GenerarDisparo()
    {
        while (true)     //Ciclo infinito
        {
            yield return new WaitForSeconds(1.35f); //Espera para crear otro proyectil
            //Continuar..
            Proyectil nuevo = Instantiate(proyectil); //Crear nuevo proyectil
            nuevo.transform.position = gameObject.transform.position; //El proyectil se coloca en la posición del enemigo
            nuevo.gameObject.SetActive(true); //Enemigo dispara el proyectil

            nuevo.Destruir(1f); //Se destruye despues de un segundo
        }
        
    }
}
