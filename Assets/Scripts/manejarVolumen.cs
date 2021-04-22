using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

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

