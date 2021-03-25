using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Maneja el control de las vidas del personaje
 * Autores: 
 * Jorge Chávez Badillo A01749448
 * Ariadna Jocelyn Guzmán Jiménez A01749373
 * Liam Garay Monroy A01750632
 * Andrea Vianey Díaz Álvarez A01750147
 * Amy Murakami Tsutsumi A01750185
 */

public class VidasPersonaje : MonoBehaviour
{
    // Start is called before the first frame update
    public int vidas = 3;
    public static VidasPersonaje instance;
    public int monedas = 0;

    private void Awake()
    {
        instance = this;
    }
}