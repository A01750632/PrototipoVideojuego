using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PajaroDispara : MonoBehaviour
{
    public Proyectil proyectil;

    //render del enemigo
    private SpriteRenderer rendererEnemigo;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenerarDisparo());
        rendererEnemigo = GetComponent<SpriteRenderer>();
    }

    private IEnumerator GenerarDisparo()
    {
        while (true)     //Ciclo infinito
        {
            yield return new WaitForSeconds(1.35f);
            //Continuar..
            Proyectil nuevo = Instantiate(proyectil);
            nuevo.transform.position = gameObject.transform.position;
            nuevo.gameObject.SetActive(true);

            nuevo.Destruir(1f);
        }
        
    }
}
