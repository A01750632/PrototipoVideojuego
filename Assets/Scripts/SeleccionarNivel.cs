using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
/* 
 * Selecciona el nivel del jugador. Bloquea los niveles que a�n no est�n disponibles.
 * Desbloquea los niveles cuando pasa el nivel. 
 * 
 * Autores: 
 * Jorge Ch�vez Badillo            A01749448
 * Ariadna Jocelyn Guzm�n Jim�nez  A01749373
 * Liam Garay Monroy               A01750632
 * Amy Murakami Tsutsumi           A01750185
 * Andrea Vianey D�az �lvarez      A01750147
 */

public class SeleccionarNivel : MonoBehaviour
{
    public Button[] nivBotones;
    public static int nivel; //Nivel del jugador

    // Start is called before the first frame update
    public IEnumerator Start()
    {
        WWWForm forma = new WWWForm();
        //Guarda el nombre del usuario que inici� sesi�n
        if (Red.nombre == null)
        {
            forma.AddField("Usuario", Registro.nombre);
        }
        else
        {
            forma.AddField("Usuario", Red.nombre);
        }
        //Busca el nivel en el que se encuentra el jugador
        UnityWebRequest request = UnityWebRequest.Post("http://3.22.38.105:8080/jugador/BuscarNivel", forma);
        yield return request.SendWebRequest();
        if (request.result == UnityWebRequest.Result.Success)
        {
            print(request.downloadHandler.text);
        }
        else
        {
            print(request.responseCode.ToString());
        }
        nivel = Convert.ToInt32(request.downloadHandler.text) + 1; //Convierte el nivel (string) a un entero

        int posNiv = PlayerPrefs.GetInt("posNiv", nivel); //Posiciona en el Nivel indicado

        for (int i = 0; i < nivBotones.Length; i++) //Habilita los botones para que el jugador pueda presionarlo en caso de que haya pasado el nivel
        {
            if (i + 2 > posNiv)
                nivBotones[i].interactable = false;
        }
    }
}
