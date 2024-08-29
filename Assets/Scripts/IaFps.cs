using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IaFps : MonoBehaviour
{

    private NavMeshAgent agente;
    private Animator animacao;
    public List<GameObject> Destinos;
    public int objeto = 0;
    public float tempo = 0;

    public GameObject Alvo;

    //Maquina de Estados
    public enum Estados { Parado, Ronda, Perseguir};
    public Estados MeuEstado;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        animacao = GetComponent<Animator>();
        MeuEstado = Estados.Parado;
    }

    void Update()
    {
        //Controlador de Estados
        if(MeuEstado == Estados.Parado)
        {
            Parado();
        }
        if (MeuEstado == Estados.Ronda)
        {
            Ronda();
        }
        if (MeuEstado == Estados.Perseguir)
        {
            Perseguir();
        }


    }

    void Parado()
    {
        animacao.SetBool("Ronda", false);
        agente.speed = 0;
        tempo += Time.deltaTime;
        if (tempo > 0.3) {
            tempo = 0;
            //Altero Estado
            MeuEstado = Estados.Ronda;
        }
    }

    void Ronda()
    {
        //Coloca a animação de Ronda
        animacao.SetBool("Ronda", true);
        agente.speed = 30;
        //Move o Personagem até o destino
        agente.SetDestination(Destinos[objeto].
            transform.position);
        //Calcula Distancia até o destino
        float DistanciaPonto = Vector3.Distance(
            transform.position,
            Destinos[objeto].transform.position);
        //Se a distancia menor que 10
        if(DistanciaPonto < 8)
        {
            //Sortei um novo destino
            objeto = Random.Range(0, Destinos.Count);
            MeuEstado = Estados.Parado;
        }
    }

    void Perseguir()
    {
        //animacao.SetBool("Ronda", true);
        agente.speed = 40;
        //Move o Personagem até o destino
        agente.SetDestination(Alvo.
            transform.position);
    }


    //Metodo

    public void AtivaPerseguicao(GameObject o_alvo)
    {
        Alvo = o_alvo;
        MeuEstado = Estados.Perseguir;
    }

}
