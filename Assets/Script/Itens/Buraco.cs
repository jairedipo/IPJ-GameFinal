using UnityEngine;
using DG.Tweening;

public class Buraco : MonoBehaviour
{
    float savedTime;
    float closeTime;
    float duracao;

    void Start()
    {
        duracao = 15.0f;
        closeTime = Time.time + duracao;
        savedTime = Time.time;

        transform.DOScaleX(6, 0.5f);
        transform.DOScaleZ(6, 0.5f);
        Destroy(gameObject, duracao);
    }

    void Update()
    {
        if (closeTime - Time.time < 0.8f)
        {
            transform.DOScaleX(0.1f, 0.5f);
            transform.DOScaleZ(0.1f, 0.5f);
        }
        else if (Time.time - savedTime > 1.0f)
        {
            inimigoProximo();
        }
    }

    void inimigoProximo()
    {
        float distancia;
        float raio = 2.5f;

        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] inimigos = GameObject.FindGameObjectsWithTag("Inimigo");

        if (players.Length == 0 && inimigos.Length == 0)
        {
            return;
        }

        for (int i = 0; i < inimigos.Length; i++)
        {
            distancia = Vector3.Distance(inimigos[i].transform.position, transform.position);
            if (distancia < raio)
            {
                inimigos[i].transform.GetComponent<ControlEnemy>().paralisado = true;
                Rigidbody inimigoRB = inimigos[i].GetComponent<Rigidbody>();
                inimigoRB.constraints = RigidbodyConstraints.None;
                inimigos[i].transform.DOMoveX(transform.position.x, 1);
                inimigos[i].transform.DOMoveZ(transform.position.z, 1);
                inimigos[i].tag = "Untagged";
                Destroy(inimigos[i], 5);
            }
        }

        for (int i = 0; i < players.Length; i++)
        {
            distancia = Vector3.Distance(players[i].transform.position, transform.position);
            if (distancia < raio)
            {
                players[i].transform.GetComponent<ControlPlayer>().paralisado = true;
                Rigidbody playerRB = players[i].GetComponent<Rigidbody>();
                playerRB.constraints = RigidbodyConstraints.None;
                players[i].transform.DOMoveX(transform.position.x, 1);
                players[i].transform.DOMoveZ(transform.position.z, 1);
                players[i].tag = "Untagged";
                Destroy(players[i], 5);
            }
        }
    }
}
