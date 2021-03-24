using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Para imagenes

public class HUD : MonoBehaviour
{
    public Image imagen1;
    public Image imagen2;
    public Image imagen3;
    public static HUD instance;
    //public Text textoMonedas;
    private void Awake()
    {
        instance = this;
    }
    /*
    public void ActualizarMonedas()
    {
        //textoMonedas.text = VidasPersonaje.instance.monedas.ToString();
    }
    */
    public void ActualizarVidas()
    {
        int vidas = VidasPersonaje.instance.vidas;
        if (vidas == 2)
        {
            imagen3.enabled = false;
        }
        else if (vidas == 1)
        {
            imagen2.enabled = false;
        }
        else if (vidas == 0)
        {
            imagen1.enabled = false;
        }

    }
}