using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

Autores: 
Jorge Chávez Badillo            A01749448
Ariadna Jocelyn Guzmán Jiménez  A01749373
Liam Garay Monroy               A01750632
Amy Murakami Tsutsumi           A01750185
Andrea Vianey Díaz Álvarez      A01750147
*/

public class MoverPersonaje : MonoBehaviour
{
    //VARIABLES
    public float maxVelocidadX = 10; //Mov. horizontal <- ->
    public float maxVelocidadY = 7; //Mov. Vertical ^

    private Rigidbody2D rigidbody; //Para física


    //METODOS
    // Start is called before the first frame update
    void Start()
    {
        //Inicializar variables
        rigidbody = GetComponent<Rigidbody2D>();    //Enlazar RB ->script
        
    }

    // Update is called once per frame (FRECUENTEMENTE, 60 veces/seg)
    void Update()
    {
        float movHorizontal = Input.GetAxis("Horizontal");  //[-1, 1]

        rigidbody.velocity = new Vector2(movHorizontal*maxVelocidadX, rigidbody.velocity.y);

        //salto (Después lo vamos a resolver con JUMP)
        float movVertical = Input.GetAxis("Vertical");
        if (movVertical > 0 && PruebaPiso.estaEnPiso)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, maxVelocidadY);
        }
    }
}