using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNiveles : MonoBehaviour
{
    // Start is called before the first frame update
    public void nivelUno()
    {
        SceneManager.LoadScene("Nivel1");
    }
    /*
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
    */
};

