using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        //velocidad
        float velocidad = Mathf.Abs(rb2D.velocity.x);
        anim.SetFloat("velocidad", velocidad);

        //Orientación
        if (rb2D.velocity.x > 0)
        {
            sprRenderer.flipX = false;
        }
        else if (rb2D.velocity.x < 0)
        {
            sprRenderer.flipX = true;
        }

        // saltando
        anim.SetBool("saltando", !PruebaPiso.estaEnPiso);
    }
}
