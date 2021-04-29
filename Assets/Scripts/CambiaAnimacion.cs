using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Cambia animación del personaje. Permite modificar el parámetro de velocidad de Animator.
 *
 * Autores: 
 * Jorge Chávez Badillo            A01749448
 * Ariadna Jocelyn Guzmán Jiménez  A01749373
 * Liam Garay Monroy               A01750632
 * Amy Murakami Tsutsumi           A01750185
 * Andrea Vianey Díaz Álvarez      A01750147
 */

public class CambiaAnimacion : MonoBehaviour
{
    private Rigidbody2D rb2D;
    //Animator
    private Animator anim;  //Animator, actualizar el párametro velocidad

    //SpriteRenderer, es para cambiar la orientación. FlipX, FlipY
    private SpriteRenderer sprRenderer;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Velocidad
        float velocidad = Mathf.Abs(rb2D.velocity.x);
        anim.SetFloat("velocidad", velocidad);

        //Orientación
        if (rb2D.velocity.x > 0.001)
        {
            sprRenderer.flipX = false;
        }
        else if (rb2D.velocity.x < -0.001)
        {
            sprRenderer.flipX = true;
        }

        //Saltando
        anim.SetBool("saltando", !PruebaPiso.estaEnPiso);

        //Disparando
        anim.SetBool("disparando",Input.GetButtonDown("Fire1"));
    }
}
