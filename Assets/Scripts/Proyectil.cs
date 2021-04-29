using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Mueve el proyectil
 *
 * Autores: 
 * Jorge Chávez Badillo            A01749448
 * Ariadna Jocelyn Guzmán Jiménez  A01749373
 * Liam Garay Monroy               A01750632
 * Amy Murakami Tsutsumi           A01750185
 * Andrea Vianey Díaz Álvarez      A01750147
 */

public class Proyectil : MonoBehaviour
{
    private float velocidadX = 10; //Establece velocidad en eje x
    private Rigidbody2D rb;
    // Start is called before the first frame update

    //renderer del objeto
    private SpriteRenderer rendererProyectil; // Sabe si la cmara lo está viendo

    public int direccionDerecha = 0; //+1       //Factor de la velocidad

    private float veloz1 = +0.1f; //Velocidad del proyectil

        void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(direccionDerecha * (velocidadX*1.6f), 0); //Establece la velocidad del proyectil de acuerdo con la dirección del personaje

        rendererProyectil = GetComponent<SpriteRenderer>();
    }

    public void CambiarDireccion(float velocidad) //Cambia dirección del proyectil
    {
        direccionDerecha = velocidad < 0 ? -1 : +1;
    }

    public void velocidad(float veloz) //Indica la velocidad del proyectil
    {
        veloz1 = veloz;
    }

    public void Destruir(float segundos) //Destruye el proyectil en cierto tiempo
    {
        Destroy(gameObject,segundos);
    }

    public void CambiarDireccionPAmigo() //Cambiar la dirección del proyectil del Amigo
    {
        if (direccionDerecha <= -1)
        {
            rendererProyectil.flipX = true;
        }
        else if (direccionDerecha >= 1)
        {
            rendererProyectil.flipX = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        //Detectar velocidad para destruir proyectil
        if (veloz1 == 0) //Si la velocidad es cero se destruye en 0.6 segundos
        {
            Destroy(gameObject,0.6f);
        }
        else if(veloz1 != 0) //Si la velocidad es diferente a cero
        {
            if(!rendererProyectil.isVisible) //En caso de no estar visible se destruye automáticamente
            {
                Destroy(gameObject);
            }
            else //De lo contrario se destruye en 1.4 segundos
            {
                Destroy(gameObject,1.4f); 
            }
        }
    }
}