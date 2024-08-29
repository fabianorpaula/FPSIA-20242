using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Visao : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        Vector3 olharprafrente = transform.TransformDirection(
            Vector3.forward) * 40;

        if(Physics.Raycast(transform.position, olharprafrente,
            out hit, 40))
        {
            //Quando Vc Acertar
            
            /*Debug.DrawLine(transform.position, olharprafrente,
                Color.magenta);*/
            
            if(hit.collider.gameObject.tag == "Inimigo")
            {
                Debug.Log("ACERTEI INIMIGO");
                Debug.Log(hit.collider.gameObject.name);
                Destroy(hit.collider.gameObject);
            }

        }
        else
        {
            
            Debug.Log("Errei");
        }
    }
}
