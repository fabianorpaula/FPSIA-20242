using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IaFps : MonoBehaviour
{

    private NavMeshAgent agente;
    public List<GameObject> Destinos;
    public int objeto = 0;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        
    }

    void Ronda()
    {
        agente.SetDestination(Destinos[objeto].
            transform.position);

        float DistanciaPonto = Vector3.Distance(
            transform.position,
            Destinos[objeto].transform.position);
        if(DistanciaPonto < 10)
        {
            objeto = Random.Range(0, Destinos.Count);
        }
    }
}
