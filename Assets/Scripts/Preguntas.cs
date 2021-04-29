using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Muestra pantalla de ganador o game over al contestar las preguntas
 *
 * Autores: 
 * Jorge Chávez Badillo            A01749448
 * Ariadna Jocelyn Guzmán Jiménez  A01749373
 * Liam Garay Monroy               A01750632
 * Amy Murakami Tsutsumi           A01750185
 * Andrea Vianey Díaz Álvarez      A01750147
 */
public class Preguntas : MonoBehaviour
{
    private bool hide;
    public GameObject pantallaGameOver; //Panel de game over
    public GameObject pantallaWinner; //Panel de ganador

    public void Ganador() //Muestra panel de ganador
    {
        hide = !hide;
        pantallaWinner.SetActive(hide);
        Time.timeScale = hide ? 0 : 1f;
    }

    public void GameOver() //Muestra panel de game over
    {
        hide = !hide;
        pantallaGameOver.SetActive(hide);
        Time.timeScale = hide ? 0 : 1f;
    }
}