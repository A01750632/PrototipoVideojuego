using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverAmigo : MonoBehaviour
{
    public GameObject player;
    
    public GameObject box1;
    public GameObject box2;
    public GameObject box3;

    public int direccionDerecha = +1;

    private MoverPersonaje personaje;

    //Animator para actualizar el párametro velocidad
    private Animator anim; 
    //SpriteRenderer para cambiar la orientación. FlipX, FlipY 
    private SpriteRenderer sprRenderer;

    void Start()
    {
        sprRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    public void CambiarDireccion(float velocidad)
    {
        direccionDerecha = velocidad < 0 ? -1 : +1;
    }

    public void AnimarMovimiento(float velocidad)
    {
        anim.SetFloat("velocidad", velocidad * direccionDerecha);
    }

    public void Update()
    {
        Physics2D.IgnoreCollision(box1.GetComponent<Collider2D>(),box2.GetComponent<Collider2D>(), true);
        Physics2D.IgnoreCollision(box1.GetComponent<Collider2D>(),box3.GetComponent<Collider2D>(), true);

        if (direccionDerecha <= -1)
        {
            transform.position = new Vector3(player.transform.position.x+0.6f, player.transform.position.y, -1f);
            sprRenderer.flipX = true;
        }
        else if (direccionDerecha >= 1)
        {
            transform.position = new Vector3(player.transform.position.x-0.6f, player.transform.position.y, -1f);
            sprRenderer.flipX = false;
        }

        //Saltando
        anim.SetBool("saltando", !PruebaPiso.estaEnPiso);

    }
}
