using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Controla el menu pausa (muestra/oculta)
 * Autores: 
 * Jorge Chávez Badillo A01749448
 * Ariadna Jocelyn Guzmán Jiménez A01749373
 * Liam Garay Monroy A01750632
 * Andrea Vianey Díaz Álvarez A01750147
 * Amy Murakami Tsutsumi A01750185
 */

public class MenuPausa : MonoBehaviour
{
    public bool estaPausado;   //true, esta en pausa. false. esta jugando
    public GameObject pantallaPausa;  //Panel

    //Cada vez que el usuario solicita la pausa, o quiera quitar la pausa, se llama con un botón 
    public void Pausar()
    {
        estaPausado = !estaPausado;
        //Prende o apaga la pantalla, depende del valor del bool
        pantallaPausa.SetActive(estaPausado);
        //Escala de tiempo -if terciario-
        Time.timeScale = estaPausado ? 0 : 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pausar();
        }
    }
}