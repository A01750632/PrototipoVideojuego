using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Mueve al amigo utilizando la dirección del personaje
 *
 * Autores: 
 * Jorge Chávez Badillo            A01749448
 * Ariadna Jocelyn Guzmán Jiménez  A01749373
 * Liam Garay Monroy               A01750632
 * Amy Murakami Tsutsumi           A01750185
 * Andrea Vianey Díaz Álvarez      A01750147
 */

public class MoverAmigo : MonoBehaviour
{
    public GameObject player; //jugador
    
    public GameObject box1; //collider del personaje
    public GameObject box2; //collider del amigo
    public GameObject box3; //collider del piso/plataforma

    public int direccionDerecha = +1; //dirección del personaje y amigo

    private MoverPersonaje personaje; //movimiento del personaje

    //Animator para actualizar el parametro velocidad
    private Animator anim; 
    //SpriteRenderer para cambiar la orientacion. FlipX, FlipY 
    private SpriteRenderer sprRenderer;

    void Start()
    {
        sprRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    public void CambiarDireccion(float velocidad) //Cambiar dirección de Amigo
    {
        direccionDerecha = velocidad < 0 ? -1 : +1;
    }

    public void AnimarMovimiento(float velocidad) //Animación de movimiento de amigo, según su velocidad
    {
        anim.SetFloat("velocidad", velocidad * direccionDerecha);
    }

    public void Update()
    {
        //Ignora la colisión entre el personaje y el amigo ya que tienen el mismo movimiento
        Physics2D.IgnoreCollision(box1.GetComponent<Collider2D>(),box2.GetComponent<Collider2D>(), true);
        //Ignora la colisión entre el amigo y el piso
        Physics2D.IgnoreCollision(box1.GetComponent<Collider2D>(),box3.GetComponent<Collider2D>(), true);

        if (direccionDerecha <= -1) //Si la dirección del personaje es a la izquierda
        {
            //Movimiento y dirección del amigo a la izquierda
            transform.position = new Vector3(player.transform.position.x+0.6f, player.transform.position.y, -1f);
            sprRenderer.flipX = true;
        }
        else if (direccionDerecha >= 1) //Si la dirección del personaje es a la derecha
        {
            //Movimiento y dirección del amigo a la derecha
            transform.position = new Vector3(player.transform.position.x-0.6f, player.transform.position.y, -1f);
            sprRenderer.flipX = false;
        }

        //Saltando
        anim.SetBool("saltando", !PruebaPiso.estaEnPiso);

    }
}
