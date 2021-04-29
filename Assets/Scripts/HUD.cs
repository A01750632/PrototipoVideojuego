using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Para imagenes
/*
 * Ejecuta el control de actualización gráfica de monedas y vidas en el juego
 * Autores: 
 * Jorge Chávez Badillo A01749448
 * Ariadna Jocelyn Guzmán Jiménez A01749373
 * Liam Garay Monroy A01750632
 * Andrea Vianey Díaz Álvarez A01750147
 * Amy Murakami Tsutsumi A01750185
 */
 
public class HUD : MonoBehaviour
{
    //Imagenes de las vidas (flechas)
    public Image imagen1;
    public Image imagen2;
    public Image imagen3;
    public static HUD instance;
    public Text textoMonedas; //Texto que cuenta las monedas recolectadas


    private void Awake() //Se ejecuta cuando el objeto se activa (antes del Start)
    {
        instance = this;
    }
    
    public void ActualizarMonedas() //Actualiza las monedas que recolecta el personaje
    {
        textoMonedas.text = VidasPersonaje.instance.monedas.ToString();
    }
    
    public void ActualizarVidas()
    {
        int vidas = VidasPersonaje.instance.vidas; //Cuántas vidas tiene el personaje
        if (vidas == 2) //Esconde las imagenes de las vidas cuando las pierde el personaje
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