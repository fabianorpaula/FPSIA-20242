using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class IaFps : MonoBehaviour
{

    private NavMeshAgent agente;
    private Animator animacao;
    public List<GameObject> Destinos;
    public int objeto = 0;
    public float tempo = 0;
    public int vida = 10;

    public GameObject Alvo;
    public Arma MinhaArma;
    public Visao MinhaVisao;

    //DADOS
    public float nVel;
    public int nVida;
    public bool dano;
    public float nDisp;
    public float nVisao;

    //Maquina de Estados
    public enum Estados { Parado, Ronda, Perseguir, Atacar};
    public Estados MeuEstado;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        animacao = GetComponent<Animator>();
        MeuEstado = Estados.Parado;



        nVida = nVida / 2;
        nVisao = nVisao * 3;
        nVel = nVel * 2;
        nDisp = nDisp * 3;


        vida = 10 + nVida;
        MinhaVisao.alcance = 40 + nVisao;
        MinhaArma.AtivarVel(dano);
        MinhaArma.alncearma = 20 + nDisp;

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
        if (MeuEstado == Estados.Atacar)
        {
            Atacar();
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
        animacao.SetBool("Segue", false);
        animacao.SetBool("Tiro", false);
        agente.speed = 30 + nVel;
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
        if (Alvo == null)
        {
            MeuEstado = Estados.Ronda;
        }
        else
        {
            animacao.SetBool("Segue", true);
            agente.speed = 40+ nVel;
            //Move o Personagem até o destino
            agente.SetDestination(Alvo.
                transform.position);
            float distanciaAlvo = Vector3.Distance(
                transform.position,
                Alvo.transform.position);
            if (distanciaAlvo < 15)
            {
                MeuEstado = Estados.Atacar;
            }
            if (distanciaAlvo > 30)
            {
                MeuEstado = Estados.Ronda;
            }
        }
    }


    void Atacar()
    {
        if(Alvo == null)
        {
            MeuEstado = Estados.Ronda;
        }else{
            animacao.SetBool("Tiro", true);
            transform.LookAt(Alvo.
                transform.position);
            agente.speed = 0;
            float distanciaAlvo = Vector3.Distance(
                transform.position,
                Alvo.transform.position);
            if (distanciaAlvo > 20)
            {
                MeuEstado = Estados.Perseguir;
            }
        }

        
    }


    public void Atirei()
    {
        //Debug.Log("DEI UM TIRO");
        MinhaArma.Tiro();
    }

    public void Dano()
    {
        vida--;
        if(vida <= 0) {
            Destroy(this.gameObject);
        }
    }

    //Metodo

    public void AtivaPerseguicao(GameObject o_alvo)
    {
        Alvo = o_alvo;
        MeuEstado = Estados.Perseguir;
    }

}
