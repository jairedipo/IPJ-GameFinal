using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCaixaSurpresa : MonoBehaviour
{
    int randEfeito;
    ControlPlayer player;
    ControlEnemy inimigo;

    public GameObject buraco;
    public GameObject explosao;
    public GameObject explosaoDeCura;

    Material mat;

    private void OnTriggerEnter(Collider other)
    {
        randEfeito = Random.Range(0, 8);

        switch (randEfeito)
        {
            case 0: invocarBuracoNegro(); return;
            case 1: caixaExplosiva(); return;
            case 2: caixaExplosivaCura(); return;
            case 3: superBonusATK(other); return;
            case 4: superBonusDEF(other); return;
            case 5: superBonusVEL(other); return;
            case 6: envenenar(other); return;
            case 7: paralisar(other); return;
            default: return;
        }
    }

    void invocarBuracoNegro()
    {
        Instantiate(buraco, transform.position, transform.rotation);
        Destroy(gameObject, 20.0f);
        gameObject.SetActive(false);
    }

    void caixaExplosiva()
    {
        GameObject efeitoExplosivo = Instantiate<GameObject>(explosao);
        efeitoExplosivo.transform.position = transform.position;
        efeitoExplosivo.transform.rotation = transform.rotation;
        Destroy(efeitoExplosivo, 5);

        float distancia;
        float raioExplosao = 4.0f;

        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] inimigos = GameObject.FindGameObjectsWithTag("Inimigo");

        if (players.Length == 0 && inimigos.Length == 0)
        {
            return;
        }

        for (int i = 0; i < players.Length; i++)
        {
            distancia = Vector3.Distance(players[i].transform.position, transform.position);
            if (distancia < raioExplosao)
            {
                player = players[i].transform.GetComponent<ControlPlayer>();
                player.receberDanoRefletido(500 + player.DEF);
            }
        }

        for (int i = 0; i < inimigos.Length; i++)
        {
            distancia = Vector3.Distance(inimigos[i].transform.position, transform.position);
            if (distancia < raioExplosao)
            {
                inimigo = inimigos[i].transform.GetComponent<ControlEnemy>();
                inimigo.receberDanoRefletido(500 + inimigo.DEF);
            }
        }
        Destroy(gameObject);
    }

    void caixaExplosivaCura()
    {
        GameObject efeitoExplosivo = Instantiate<GameObject>(explosaoDeCura);
        efeitoExplosivo.transform.position = transform.position;
        efeitoExplosivo.transform.rotation = transform.rotation;
        Destroy(efeitoExplosivo, 5);

        int cura = 800;
        float distancia;
        float raioExplosao = 3.0f;

        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] inimigos = GameObject.FindGameObjectsWithTag("Inimigo");

        if (players.Length == 0 && inimigos.Length == 0)
        {
            return;
        }

        for (int i = 0; i < players.Length; i++)
        {
            distancia = Vector3.Distance(players[i].transform.position, transform.position);
            if (distancia < raioExplosao)
            {
                ControlPlayer personagem = players[i].transform.GetComponent<ControlPlayer>();

                if (personagem.HP + cura > personagem.HPMax)
                    personagem.HP = personagem.HPMax;
                else
                    personagem.HP += cura;
            }
        }

        for (int i = 0; i < inimigos.Length; i++)
        {
            distancia = Vector3.Distance(inimigos[i].transform.position, transform.position);
            if (distancia < raioExplosao)
            {
                ControlEnemy personagem = inimigos[i].transform.GetComponent<ControlEnemy>();

                if (personagem.HP + cura > personagem.HPMax)
                    personagem.HP = personagem.HPMax;
                else
                    personagem.HP += cura;
            }
        }
        Destroy(gameObject);
    }

    #region superBonusATK

    void superBonusATK(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.transform.GetComponent<ControlPlayer>();
            player.ATKBonus += 15;
        }

        if (other.gameObject.CompareTag("Inimigo"))
        {
            inimigo = other.transform.GetComponent<ControlEnemy>();
            inimigo.ATKBonus += 15;
        }

        ParticleSystem[] part = other.gameObject.GetComponentsInChildren<ParticleSystem>();
        part[1].Play();
        Destroy(gameObject, 15.0f);
        gameObject.SetActive(false);
    }

    void desfazerItemATK(ControlPlayer personagem)
    {
        personagem.ATKBonus -= 15;
    }

    void desfazerItemATK(ControlEnemy personagem)
    {
        personagem.ATKBonus -= 15;
    }

    #endregion superBonusATK

    #region superBonusDEF

    void superBonusDEF(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.transform.GetComponent<ControlPlayer>();
            player.danoRecebido -= 0.6f;
        }

        if (other.gameObject.CompareTag("Inimigo"))
        {
            inimigo = other.transform.GetComponent<ControlEnemy>();
            inimigo.danoRecebido -= 0.6f;
        }

        ParticleSystem[] part = other.gameObject.GetComponentsInChildren<ParticleSystem>();
        part[2].Play();
        Destroy(gameObject, 15.0f);
        gameObject.SetActive(false);
    }

    void desfazerItemDEF(ControlPlayer personagem)
    {
        personagem.danoRecebido += 0.6f;
    }

    void desfazerItemDEF(ControlEnemy personagem)
    {
        personagem.danoRecebido += 0.6f;
    }

    #endregion superBonusDEF

    #region superBonusVEL

    void superBonusVEL(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.transform.GetComponent<ControlPlayer>();
            player.VELBonus += 20;
        }

        if (other.gameObject.CompareTag("Inimigo"))
        {
            inimigo = other.transform.GetComponent<ControlEnemy>();
            inimigo.VELBonus += 20;
        }

        ParticleSystem[] part = other.gameObject.GetComponentsInChildren<ParticleSystem>();
        part[3].Play();

        Destroy(gameObject, 15.0f);
        gameObject.SetActive(false);
    }

    void desfazerItemVEL(ControlPlayer personagem)
    {
        personagem.VELBonus -= 20;
    }

    void desfazerItemVEL(ControlEnemy personagem)
    {
        personagem.VELBonus -= 20;
    }

    #endregion superBonusVEL

    void envenenar(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.GetComponent<ControlPlayer>().envenenado = true;
        }

        if (other.gameObject.CompareTag("Inimigo"))
        {
            other.transform.GetComponent<ControlEnemy>().envenenado = true;
        }

        ParticleSystem[] part = other.gameObject.GetComponentsInChildren<ParticleSystem>();
        part[4].Play();
        Destroy(gameObject);
    }

    void paralisar(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.transform.GetComponent<ControlPlayer>();
            player.paralisado = true;

        }

        if (other.gameObject.CompareTag("Inimigo"))
        {
            inimigo = other.transform.GetComponent<ControlEnemy>();
            inimigo.paralisado = true;
        }

        ParticleSystem[] part = other.gameObject.GetComponentsInChildren<ParticleSystem>();
        part[5].Play();
        Destroy(gameObject, 5);
        gameObject.SetActive(false);
    }

    private void OnDestroy() // Remover Efeitos
    {
        switch (randEfeito)
        {
            case 3:
                {
                    if (player != null)
                        desfazerItemATK(player);
                    if (inimigo != null)
                        desfazerItemATK(inimigo);
                    return;
                }
            case 4:
                {
                    if (player != null)
                        desfazerItemDEF(player);
                    if (inimigo != null)
                        desfazerItemDEF(inimigo);
                    return;
                }
            case 5:
                {
                    if (player != null)
                        desfazerItemVEL(player);
                    if (inimigo != null)
                        desfazerItemVEL(inimigo);
                    return;
                }
            case 7:
                {
                    if (player != null)
                        player.paralisado = false;
                    if (inimigo != null)
                        inimigo.paralisado = false;
                    return;
                }
            default: return;
        }
    }
}
