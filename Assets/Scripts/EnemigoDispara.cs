using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
*Autores: 
*Jorge Chávez Badillo            A01749448
*Ariadna Jocelyn Guzmán Jiménez  A01749373
*Liam Garay Monroy               A01750632
*Amy Murakami Tsutsumi           A01750185
*Andrea Vianey Díaz Álvarez      A01750147
*/
public class EnemigoDispara : MonoBehaviour
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
        while(true)     //Ciclo infinito
        {
            yield  return new WaitForSeconds(1.35f);
            //Continuar..
            Proyectil nuevo = Instantiate(proyectil);
            nuevo.transform.position = gameObject.transform.position;
            nuevo.gameObject.SetActive(true);
            if(rendererEnemigo.flipX == false)
            {
                nuevo.CambiarDireccion(-1);
            }else
            {
                nuevo.CambiarDireccion(1);
            }
            nuevo.Destruir(0.45f);
        }
    }
}
