using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class SeleccionarNivel : MonoBehaviour
{
    public Button[] nivBotones;
    public static int nivel;

    // Start is called before the first frame update
    public IEnumerator Start()
    {
        if (CanvasEnemigo.niveel == 0 && Enemigo.niveel == 0)
        {
            WWWForm forma = new WWWForm();
            if (Red.nombre == null)
            {
                forma.AddField("Usuario", Registro.nombre);
            }
            else
            {
                forma.AddField("Usuario", Red.nombre);
            }
            UnityWebRequest request = UnityWebRequest.Post("http://Localhost:8080/jugador/BuscarNivel", forma);
            yield return request.SendWebRequest();
            if (request.result == UnityWebRequest.Result.Success)
            {
                print(request.downloadHandler.text);
            }
            else
            {
                print(request.responseCode.ToString());
            }
            nivel = Convert.ToInt32(request.downloadHandler.text) + 1;
        }
        else if (CanvasEnemigo.niveel == 0)
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
