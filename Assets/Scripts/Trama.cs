using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* 
 * Agrega el canvas de trama de la historia al inicio de cada nivel
 * 
 * Autores: 
 * Jorge Ch�vez Badillo            A01749448
 * Ariadna Jocelyn Guzm�n Jim�nez  A01749373
 * Liam Garay Monroy               A01750632
 * Amy Murakami Tsutsumi           A01750185
 * Andrea Vianey D�az �lvarez      A01750147
 */

public class Trama : MonoBehaviour
{
    public GameObject trama;
    // Start is called before the first frame update
    void Start()
    {
        trama.SetActive(true);
        Destroy(trama,20);
    }

    public void Empezar()
    {
        Destroy(trama, 0.2f);
    }


}
