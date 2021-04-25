using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoverSiguienteNivel : MonoBehaviour
{
    public int cargarProxEscena;
    // Start is called before the first frame update
    void Start()
    {
        cargarProxEscena = SceneManager.GetActiveScene().buildIndex + 1;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (SceneManager.GetActiveScene().buildIndex == 8) /* < Change this int value to whatever your
                                                                   last level build index is on your
                                                                   build settings */
            {
                Debug.Log("You Completed ALL Levels");

                //Show Win Screen or Somethin.
            }
            else
            {
                //Move to next level
                SceneManager.LoadScene(cargarProxEscena);

                //Setting Int for Index
                if (cargarProxEscena > PlayerPrefs.GetInt("posNiv"))
                {
                    PlayerPrefs.SetInt("posNiv", cargarProxEscena);
                }
            }
        }
    }
}
