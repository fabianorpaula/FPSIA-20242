using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visao : MonoBehaviour
{
    public IaFps Soldado;

    public float alcance;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        Vector3 olharprafrente = transform.TransformDirection(
            Vector3.forward) * alcance;

        if(Physics.Raycast(transform.position, olharprafrente,
            out hit, alcance))
        {
            //Quando Vc Acertar
            if(hit.collider.gameObject.tag == "Inimigo")
            {
                //Debug.Log("ACERTEI INIMIGO");
                //Debug.Log(hit.collider.gameObject.name);
                Soldado.AtivaPerseguicao(hit.collider.gameObject);
            }

        }
        else
        {
            //Debug.Log("Errei");
        }
    }
}
