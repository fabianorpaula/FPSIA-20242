using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{

    public float alncearma;
    public bool meuDano;
    public void AtivarVel(bool ativar)
    {
        meuDano = ativar;
       
    }
    
    public void Tiro()
    {
        RaycastHit hit;

        Vector3 olharprafrente = transform.TransformDirection(
            Vector3.forward) * alncearma;

        if (Physics.Raycast(transform.position, olharprafrente,
            out hit, alncearma))
        {
            //Quando Vc Acertar
            if (hit.collider.gameObject.tag == "Inimigo")
            {
                if (meuDano)
                {
                    hit.collider.gameObject.GetComponent<IaFps>().Dano();
                    hit.collider.gameObject.GetComponent<IaFps>().Dano();
                }
                else
                {
                    hit.collider.gameObject.GetComponent<IaFps>().Dano();
                }
                
            }

        }
        else
        {
            //Debug.Log("Errei");
        }
    }
}
