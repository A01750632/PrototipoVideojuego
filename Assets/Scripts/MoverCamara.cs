using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Permite que la camara siga al personaje
 * 
 * Autores: 
 * Jorge Chávez Badillo A01749448
 * Ariadna Jocelyn Guzmán Jiménez A01749373
 * Liam Garay Monroy A01750632
 * Andrea Vianey Díaz Álvarez A01750147
 * Amy Murakami Tsutsumi A01750185
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
        float x = Mathf.Clamp(personaje.transform.position.x, min: -3.2f, max: 55.4f);
        float y = Mathf.Clamp(personaje.transform.position.y, min: 0, max: 6.6f);
        float z = transform.position.z;
        transform.position = new Vector3(x, y, z);

    }
}