using UnityEngine;

public class EnemyGoop : MonoBehaviour
{
    int HP = 1000;
    int ATK = 50;
    int DEF = 40;
    int VEL = 60;
    float raioAtaqueTorre = 4.0f;
    float raioAtaqueInimigo = 4.0f;
    float savedTime;

    public static int custoInvocacao = 100;
    public static string status;
    public static string habilidade;

    int bonusVEL = 2;
    float raioHabilidade = 6.0f;

    public Animator anim;
    ControlEnemy inimigo;
    GameObject[] aliadosProximos;

    void Start()
    {
        savedTime = Time.time;
        anim = GetComponent<Animator>();
        inimigo = GetComponent<ControlEnemy>();
        aliadosProximos = getAliadosProximos();

        status = "HP: " + HP + "\nATK: " + ATK + "\nDEF: " + DEF + "\nVEL: " + VEL;
        habilidade = "Encorajar: Aumenta em " + bonusVEL + " pontos a velocidade de aliados em um raio de " + raioHabilidade + " unidades.";

        inimigo.HP = HP;
        inimigo.HPMax = HP;
        inimigo.ATK = ATK;
        inimigo.DEF = DEF;
        inimigo.VEL = VEL;
        inimigo.raioTorre = raioAtaqueTorre;
        inimigo.raioAtaque = raioAtaqueInimigo;
    }

    // Habilidade Encorajar: Aumenta a velocidade de aliados próximos
    // Atual: +2 pontos para cada aliado
    void Update()
    {
        if (Time.time - savedTime > 1 && !inimigo.morreu)
        {
            savedTime = Time.time;

            desfazerHabilidade(aliadosProximos);

            aliadosProximos = getAliadosProximos();

            aplicarHabilidade(aliadosProximos);

        }
        else if (inimigo.morreu)
        {
            desfazerHabilidade(aliadosProximos);
            aliadosProximos = null;
        }
    }

    public GameObject[] getAliadosProximos()
    {
        float distancia;
        float raio = 6.0f;

        GameObject[] aliados = GameObject.FindGameObjectsWithTag("Inimigo");

        if (aliados.Length == 0)
        {
            return null;
        }

        for (int i = 0; i < aliados.Length; i++)
        {
            distancia = Vector3.Distance(aliados[i].transform.position, transform.position);
            if (distancia > raio || aliados[i] == this.gameObject)
            {
                aliados[i] = null;
            }
        }

        return aliados;
    }

    void aplicarHabilidade(GameObject[] aliados)
    {
        if (aliados != null)
        {
            for (int i = 0; i < aliados.Length; i++)
            {
                if (aliados[i] != null)
                {
                    ControlEnemy aliado = aliados[i].GetComponent<ControlEnemy>();
                    aliado.VELBonus += 2;
                    ParticleSystem[] part = aliadosProximos[i].gameObject.GetComponentsInChildren<ParticleSystem>();
                    part[3].Play();
                }
            }
        }
    }

    void desfazerHabilidade(GameObject[] aliados)
    {
        if (aliados != null)
        {
            for (int i = 0; i < aliados.Length; i++)
            {
                if (aliados[i] != null)
                {
                    ControlEnemy aliado = aliados[i].GetComponent<ControlEnemy>();
                    aliado.VELBonus -= 2;
                    ParticleSystem[] part = aliadosProximos[i].gameObject.GetComponentsInChildren<ParticleSystem>();
                    part[3].Stop();
                }
            }
        }
    }

    private void OnDestroy()
    {
        ScoreManager.cristais += 50;
    }
}
