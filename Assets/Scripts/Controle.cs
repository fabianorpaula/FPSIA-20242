using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controle : MonoBehaviour
{

   

    public List<GameObject> Posicoes;
    public List<GameObject> Alunos;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 2;
        Sortear();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Sortear()
    {

        for (int i = 0; i < Alunos.Count; i++)
        {
            int local = Random.Range(0, Posicoes.Count);
            Alunos[i].transform.position = Posicoes[local].transform.position;
            Debug.Log(Posicoes[local].transform.position);
            Posicoes.RemoveAt(local);
        }

    }
}
