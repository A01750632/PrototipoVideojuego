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
    private float velocidadX = 10;
    private Rigidbody2D rb;
    // Start is called before the first frame update

    //renderer del objeto
    private SpriteRenderer rendererProyectil; // Sabe si la cmara lo está viendo

    public int direccionDerecha = 0; //+1       //Factor de la velocidad

    private float veloz1 = +0.1f;

    /*public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }*/

        void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(direccionDerecha * (velocidadX*1.6f), 0);

        //rb.velocity = new Vector2(-1, -(velocidadX * 1.6f)); //Pajaro
        rendererProyectil = GetComponent<SpriteRenderer>();
    }

    public void CambiarDireccion(float velocidad)
    {
        direccionDerecha = velocidad < 0 ? -1 : +1;
    }

    public void velocidad(float veloz)
    {
        veloz1 = veloz;
    }

    public void Destruir(float segundos)
    {
        Destroy(gameObject,segundos);
    }

    public void CambiarDireccionPAmigo()
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
        // Rotar
        //gameObject.transform.Rotate(Vector3.forward, 5);
        // Revisas si debo destruir el proyectil (sale de la pantalla)
        /*
        if(! rendererProyectil.isVisible)
        {
            Destroy(gameObject);
        }
        */
        //Detectar velocidad para destruir proyectil
        if (veloz1 == 0)
        {
            Destroy(gameObject,0.6f);
        }
        else if(veloz1 != 0)
        {
            if(!rendererProyectil.isVisible)
            {
                Destroy(gameObject);
            }
            else{
                Destroy(gameObject,1.4f);
            }
        }
    }
}