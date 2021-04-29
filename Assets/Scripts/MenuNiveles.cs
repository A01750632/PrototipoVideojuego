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

    public void nivelUno() //Carga escena del nivel 1
    {
        SceneManager.LoadScene("Nivel1");
        
    }
    
    public void nivelDos() //Carga escena del nivel 2
    {
        SceneManager.LoadScene("Nivel2");
            
    }
    
    public void nivelTres() //Carga escena del nivel 3
    {
        SceneManager.LoadScene("Nivel3");
            
    }
    public void nivelCuatro() //Carga escena del nivel 4
    {
        SceneManager.LoadScene("Nivel4");
            
    }
    public void nivelCinco() //Carga escena del nivel 5
    {
        SceneManager.LoadScene("Nivel5");
            
    }

    public void Menu() //Carga escena del menu
    {
        SceneManager.LoadScene("EscenaMenu");
    }
    
};

