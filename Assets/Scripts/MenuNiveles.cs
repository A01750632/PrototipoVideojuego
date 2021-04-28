using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Menú que despliega los niveles, se carga el nivel de acuerdo con el botón que presiona el jugador
 *
 * Autores: 
 * Jorge Chávez Badillo            A01749448
 * Ariadna Jocelyn Guzmán Jiménez  A01749373
 * Liam Garay Monroy               A01750632
 * Amy Murakami Tsutsumi           A01750185
 * Andrea Vianey Díaz Álvarez      A01750147
 */

public class MenuNiveles : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject trama;
    public void nivelUno()
    {
        SceneManager.LoadScene("Nivel1");
        
    }
    
    public void nivelDos()
    {
        SceneManager.LoadScene("Nivel2");
            
    }
    
    public void nivelTres()
    {
        SceneManager.LoadScene("Nivel3");
            
    }
    public void nivelCuatro()
    {
        SceneManager.LoadScene("Nivel4");
            
    }
    public void nivelCinco()
    {
        SceneManager.LoadScene("Nivel5");
            
    }

    public void Menu()
    {
        SceneManager.LoadScene("EscenaMenu");
    }
    
};

