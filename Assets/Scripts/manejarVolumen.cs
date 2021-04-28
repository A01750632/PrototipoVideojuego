using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
/*
 * Controla el volumen del juego
 *
 * Autores: 
 * Jorge Ch�vez Badillo            A01749448
 * Ariadna Jocelyn Guzm�n Jim�nez  A01749373
 * Liam Garay Monroy               A01750632
 * Amy Murakami Tsutsumi           A01750185
 * Andrea Vianey D�az �lvarez      A01750147
 */

public class manejarVolumen : MonoBehaviour
{
    public AudioMixer audio;
    
    // Start is called before the first frame update
    public void manejarNivel(float valor)
    {
        //Conversion de el nivel de volumen actual en el slider (decibeles)
        audio.SetFloat("MusicVol", Mathf.Log10(valor) * 20);
    }
}

