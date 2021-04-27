using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeleccionarNivel : MonoBehaviour
{
    public Button[] nivBotones;
    private int nivel;

    // Start is called before the first frame update
    void Start()
    {
        if(CanvasEnemigo.niveel == 0 && VidasPersonaje.instance.vidas == 3)
        {
            nivel = 2;
        } 
        else if(CanvasEnemigo.niveel == 0)
        {
            nivel = Enemigo.niveel;
        }
        else
        {
            nivel = CanvasEnemigo.niveel;
        }
        int posNiv = PlayerPrefs.GetInt("posNiv", nivel); //Posiciona en el Nivel indicado

        for (int i = 0; i < nivBotones.Length; i++)
        {
            if (i + 2 > posNiv)
                nivBotones[i].interactable = false;
        }
    }

    
}
