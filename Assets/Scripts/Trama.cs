using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trama : MonoBehaviour
{
    public GameObject trama;
    // Start is called before the first frame update
    void Start()
    {
        trama.SetActive(true);
        Destroy(trama,20);
    }

    public void Empezar()
    {
        Destroy(trama, 0.2f);
    }


}
