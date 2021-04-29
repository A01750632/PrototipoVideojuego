using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Permite que la cámara siga al personaje
 *
 * Autores: 
 * Jorge Chávez Badillo            A01749448
 * Ariadna Jocelyn Guzmán Jiménez  A01749373
 * Liam Garay Monroy               A01750632
 * Amy Murakami Tsutsumi           A01750185
 * Andrea Vianey Díaz Álvarez      A01750147
 */

public class MoverCamara : MonoBehaviour
{
    public GameObject personaje;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float x = Mathf.Clamp(personaje.transform.position.x, min: -3.2f, max: 130.2f);  //Posición en x del persoanje
        float y = Mathf.Clamp(personaje.transform.position.y, min: 0, max: 8.6f); //Posición en y del personaje
        float z = transform.position.z; //eje z
        transform.position = new Vector3(x, y, z); //Posición del personaje (3 ejes)

    }
}