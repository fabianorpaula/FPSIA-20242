using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{
    public IaFps Soldado;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        Vector3 olharprafrente = transform.TransformDirection(
            Vector3.forward) * 20;

        if (Physics.Raycast(transform.position, olharprafrente,
            out hit, 20))
        {
            //Quando Vc Acertar
            if (hit.collider.gameObject.tag == "Inimigo")
            {
                //Debug.Log("ACERTEI INIMIGO");
                //Debug.Log(hit.collider.gameObject.name);
                Soldado.Dano();
            }

        }
        else
        {
            //Debug.Log("Errei");
        }
    }
}
