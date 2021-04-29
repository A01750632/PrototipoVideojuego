using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * 
Autores de equipo 1: 
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

    //CLONAR objetos
    public Proyectil proyectil;       //Prefabs

    //clase amigo para indicar direccion
    public MoverAmigo amigo;

    //clase amigoDispara 
    public AmigoDispara disparoAmigo;
    
    private int direccion = 1;

    //Referencia al Audio Source
    public AudioSource armaDisparo;
    public AudioSource armaEnemigo;


    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("ArmaEnemigo")) //Destruye el proyectil del enemigo al colisionar con el personaje
        {
            armaEnemigo.Play();
            Destroy(other.gameObject);
        }
    }


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
        if(movHorizontal<-0.001) //Indicar la dirección del personaje
        {
            direccion=-1;
        } else if (movHorizontal>0.001)
        {
            direccion = +1;
        }

        rigidbody.velocity = new Vector2(movHorizontal*maxVelocidadX, rigidbody.velocity.y); //Velocidad del personaje

        //salto (Después lo vamos a resolver con JUMP)
        //float movVertical = Input.GetAxis("Vertical");
        //if (movVertical > 0 && PruebaPiso.estaEnPiso)
        if(Input.GetButtonDown("Jump") && PruebaPiso.estaEnPiso)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, maxVelocidadY);
        }
        //amigo.transform.position = gameObject.transform.position;

        // DISPARA!!
        if(Input.GetButtonDown("Fire1"))
        {
            //Reproducir un efecto de sonido
            armaDisparo.Play();
            Proyectil nuevo = Instantiate(proyectil);  //COPIA, clona
            nuevo.transform.position = gameObject.transform.position; //posiciona el proyectil en la posicion del personaje
            nuevo.CambiarDireccion(direccion);
            
            nuevo.gameObject.SetActive(true);  //Start
            //proyectil amigo
        }

        if(amigo.gameObject.activeSelf) //Si el amigo está activo sigue la dirección y posición del personaje
        {
        amigo.CambiarDireccion(direccion);
        amigo.AnimarMovimiento(rigidbody.velocity.x);
        disparoAmigo.CambiarDireccion(direccion);
        }
        
    }
}