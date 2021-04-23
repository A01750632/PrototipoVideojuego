using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
* Mueve al proyectil
*Autores: 
*Jorge Chávez Badillo            A01749448
*Ariadna Jocelyn Guzmán Jiménez  A01749373
*Liam Garay Monroy               A01750632
*Amy Murakami Tsutsumi           A01750185
*Andrea Vianey Díaz Álvarez      A01750147
*/
public class Proyectil : MonoBehaviour
{
    private float velocidadX = 10;
    private Rigidbody2D rb;
    // Start is called before the first frame update

    //renderer del objeto
    private SpriteRenderer rendererProyectil; // Sabe si la cmara lo está viendo

    public int direccionDerecha = +1;       //Factor de la velocidad

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(direccionDerecha * velocidadX, 0);
        rendererProyectil = GetComponent<SpriteRenderer>();
    }

    public void CambiarDireccion(float velocidad)
    {
        direccionDerecha = velocidad < 0 ? -1 : +1;
    }

    // Update is called once per frame
    void Update()
    {
        // Rotar
        //gameObject.transform.Rotate(Vector3.forward, 5);
        // Revisas si debo destruir el proyectil (sale de la pantalla)
        if(! rendererProyectil.isVisible)
        {
            Destroy(gameObject);
        }
        /*
        if (direccionDerecha <= -1)
        {
            rendererProyectil.flipX = true;
        }
        else if (direccionDerecha >= 1)
        {
            rendererProyectil.flipX = false;
        }
        */
    }
}