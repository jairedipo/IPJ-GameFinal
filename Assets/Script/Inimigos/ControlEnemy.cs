using UnityEngine;

public class ControlEnemy : MonoBehaviour
{
    // Status básico
    public int HP;
    public int HPMax;
    public int ATK;
    public int DEF;
    public int VEL;
    public float velocidadeAtk;
    public float velocidadeMov;

    // Bonus
    public int ATKBonus;
    public float danoRecebido;
    public int VELBonus;

    // Outros status
    public float chanceCritico;
    public float espinhos;
    public float raioAtaque;
    public float raioTorre;

    // Variáveis de apoio
    public float savedTime;
    public float lastAtackTime;
    public bool morreu;
    public bool movendo;
    public bool envenenado;
    public bool paralisado;

    // Componentes
    public Animator anim;
    public Rigidbody cr;
    public GameObject torre;
    public GameObject torreInimiga;

    void Start()
    {
        ATKBonus = 0;
        danoRecebido = 0.0f;
        VELBonus = 0;

        savedTime = Time.time;
        lastAtackTime = Time.time;
        morreu = false;
        movendo = false;
        envenenado = false;
        paralisado = false;

        anim = GetComponent<Animator>();
        cr = GetComponent<Rigidbody>();
        torre = GameObject.FindGameObjectWithTag("TorreInimiga");
        torreInimiga = GameObject.FindGameObjectWithTag("Torre");

        chanceCritico = 0.015f;
    }

    void Update()
    {
        velocidadeAtk = 50.0f / (VEL + VELBonus);
        velocidadeMov = 0.00175f * (VEL + VELBonus);

        if (!morreu && Time.time - savedTime > 0.05f)
        {
            savedTime = Time.time;
            float distanciaTorre = Vector3.Distance(torreInimiga.transform.position, transform.position);

            if (envenenado) efeitoveneno();

            if (!TempoDePartida.start || paralisado)
            {
                anim.SetBool("Atacar", false);
                anim.SetBool("Mover", false);
                anim.Play("Idle");
            }

            // Atacando a torre
            else if (distanciaTorre < raioTorre)
            {
                anim.SetBool("Atacar", true);
                Torre torre = torreInimiga.GetComponent<Torre>();
                Atacar(torre);
                movendo = false;
            }
            else
            {
                // Atacar inimigo próximo
                GameObject atacarInimigo = inimigoProximo();

                float distancia = raioAtaque;

                if (atacarInimigo != null)
                {
                    distancia = Vector3.Distance(atacarInimigo.transform.position, transform.position);
                }

                if (distancia < raioAtaque)
                {
                    anim.SetBool("Atacar", true);
                    ControlPlayer inimigo = atacarInimigo.GetComponent<ControlPlayer>();
                    transform.forward = (inimigo.transform.position - transform.position).normalized;
                    Atacar(inimigo);
                    movendo = false;
                }

                // Mover até o inimigo próximo

                if (atacarInimigo != null && distancia > raioAtaque)
                {
                    anim.SetBool("Atacar", false);
                    anim.SetBool("Mover", true);
                    transform.position = transform.position + velocidadeMov * (atacarInimigo.transform.position - transform.position).normalized;
                    transform.forward = (atacarInimigo.transform.position - transform.position).normalized;
                    movendo = true;
                }


                // Mover para a torre caso não tenha inimigo próximo
                if (atacarInimigo == null)
                {
                    anim.SetBool("Atacar", false);
                    anim.SetBool("Mover", true);
                    transform.position = transform.position + velocidadeMov * (torreInimiga.transform.position - transform.position).normalized;
                    transform.forward = (torreInimiga.transform.position - transform.position).normalized;
                    movendo = true;
                }
            }
        }
        else if(morreu)
        {
            movendo = false;
            HP = 0; // Garantir que o inimigo não recuperou HP depois de morto
            anim.SetBool("Morrer", true);
            tag = "Untagged";
            Destroy(gameObject, 5.0f);
        }
    }

    GameObject inimigoProximo()
    {
        int alvo = -1;
        float distancia;
        float raio = 6.0f;
        float menordistancia = raio;

        GameObject[] inimigos = GameObject.FindGameObjectsWithTag("Player");

        if (inimigos.Length == 0)
        {
            return null;
        }

        for (int i = 0; i < inimigos.Length; i++)
        {
            distancia = Vector3.Distance(inimigos[i].transform.position, transform.position);
            if (distancia < raio && distancia < menordistancia)
            {
                menordistancia = distancia;
                alvo = i;
            }
        }

        if (alvo == -1)
        {
            return null;
        }

        return inimigos[alvo];
    }

    void Atacar(ControlPlayer inimigo)
    {
        if (Time.time - lastAtackTime > velocidadeAtk)
        {
            lastAtackTime = Time.time;
            if (critico())
            {
                anim.SetTrigger("Critico");
                inimigo.receberDano(this, 6 * (ATK + ATKBonus));
            }
            else
                inimigo.receberDano(this, 4 * (ATK + ATKBonus));
        }
    }

    void Atacar(Torre torre)
    {
        if (Time.time - lastAtackTime > velocidadeAtk)
        {
            lastAtackTime = Time.time;
            if (critico())
            {
                anim.SetTrigger("Critico");
                torre.receberDano(6 * (ATK + ATKBonus));
            }
            else
                torre.receberDano(4 * (ATK + ATKBonus));
        }
    }

    public void receberDano(ControlPlayer atacante, int dano)
    {
        int danoTotal = (int)((dano - DEF) * (1.0f + danoRecebido));

        if (danoTotal > 0)
            HP = HP - danoTotal;

        if (espinhos > 0)
        {
            int danoRefletido = (int)(dano * espinhos);
            refletirAtaque(atacante, danoRefletido);
        }

        if (HP <= 0)
        {
            morreu = true;
        }
    }

    void refletirAtaque(ControlPlayer inimigo, int danoRefletido)
    {
        inimigo.receberDanoRefletido(danoRefletido);
    }

    public void receberDanoRefletido(int danoRefletido)
    {
        int danoTotal = (int)((danoRefletido - DEF) * (1.0f + danoRecebido));

        if (danoTotal > 0)
            HP = HP - danoTotal;

        if (HP <= 0)
        {
            morreu = true;
        }
    }

    public bool critico()
    {
        float rand = Random.Range(0.00f, 1.00f);

        if (rand < chanceCritico)
            return true;

        return false;
    }

    void efeitoveneno()
    {
        float veneno = HPMax / (12.5f * 20.0f); // 12,5 segundos para morrer, o efeito ocorre 20 vezes por segundo
        if (HP >= veneno)
            HP -= (int)veneno;
        else
        {
            HP = 0;
            morreu = true;
        }
    }
}