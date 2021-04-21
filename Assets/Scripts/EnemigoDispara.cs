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
    public GameObject proyectil;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerarDisparo());   
    }

    private IEnumerator GenerarDisparo()
    {
        while(true)     //Ciclo infinito
        {
            yield  return new WaitForSeconds(1.35f);
            //Continuar..
            GameObject nuevo = Instantiate(proyectil);
            nuevo.transform.position = gameObject.transform.position;
            nuevo.SetActive(true);
        }
    }
}
