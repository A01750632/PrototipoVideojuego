using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Preguntas : MonoBehaviour
{
    private bool hide;
    public GameObject pantallaGameOver;
    public GameObject pantallaWinner;

    public void Ganador()
    {
        hide = !hide;
        pantallaWinner.SetActive(hide);
        Time.timeScale = hide ? 0 : 1f;
    }

    public void GameOver()
    {
        hide = !hide;
        pantallaGameOver.SetActive(hide);
        Time.timeScale = hide ? 0 : 1f;
    }
}