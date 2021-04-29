using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Disparo vertical del enemigo p�jaro autom�tico cada 1.35f segundos
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
            yield return new WaitForSeconds(1.35f);
            //Continuar..
            Proyectil nuevo = Instantiate(proyectil);
            nuevo.transform.position = gameObject.transform.position;
            nuevo.gameObject.SetActive(true);

            nuevo.Destruir(1f);
        }
        
    }
}
