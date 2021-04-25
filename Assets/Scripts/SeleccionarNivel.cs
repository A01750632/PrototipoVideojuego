using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeleccionarNivel : MonoBehaviour
{
    public Button[] nivBotones;

    // Start is called before the first frame update
    void Start()
    {
        int posNiv = PlayerPrefs.GetInt("posNiv",2); //Posicion de escena primer nivel

        for (int i = 0; i < nivBotones.Length; i++)
        {
            if (i + 2 > posNiv)
                nivBotones[i].interactable = false;
        }
    }

    
}
