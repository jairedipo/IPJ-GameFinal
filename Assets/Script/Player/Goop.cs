using UnityEngine;

public class Goop : MonoBehaviour
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
    ControlPlayer player;
    GameObject[] aliadosProximos;

    void Start()
    {
        savedTime = Time.time;
        anim = GetComponent<Animator>();
        player = GetComponent<ControlPlayer>();
        aliadosProximos = getAliadosProximos();

        status = "HP: " + HP + "\nATK: " + ATK + "\nDEF: " + DEF + "\nVEL: " + VEL;
        habilidade = "Encorajar: Aumenta em " + bonusVEL + " pontos a velocidade de aliados em um raio de " + raioHabilidade + " unidades.";

        player.HP = HP;
        player.HPMax = HP;
        player.ATK = ATK;
        player.DEF = DEF;
        player.VEL = VEL;
        player.raioTorre = raioAtaqueTorre;
        player.raioAtaque = raioAtaqueInimigo;
    }

    // Habilidade Encorajar: Aumenta a velocidade de aliados próximos
    // Atual: +2 pontos para cada aliado
    void Update()
    {
        if (Time.time - savedTime > 1 && !player.morreu)
        {
            savedTime = Time.time;

            desfazerHabilidade(aliadosProximos);

            aliadosProximos = getAliadosProximos();

            aplicarHabilidade(aliadosProximos);
        }
        else if (player.morreu)
        {
            desfazerHabilidade(aliadosProximos);
            aliadosProximos = null;
        }
    }

    public GameObject[] getAliadosProximos()
    {
        float distancia;

        GameObject[] aliados = GameObject.FindGameObjectsWithTag("Player");

        if (aliados.Length == 0)
        {
            return null;
        }

        for (int i = 0; i < aliados.Length; i++)
        {
            distancia = Vector3.Distance(aliados[i].transform.position, transform.position);
            if (distancia > raioHabilidade || aliados[i] == this.gameObject)
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
                    ControlPlayer aliado = aliados[i].GetComponent<ControlPlayer>();
                    aliado.VELBonus += bonusVEL;
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
                    ControlPlayer aliado = aliados[i].GetComponent<ControlPlayer>();
                    aliado.VELBonus -= bonusVEL;
                    ParticleSystem[] part = aliadosProximos[i].gameObject.GetComponentsInChildren<ParticleSystem>();
                    part[3].Stop();
                }
            }
        }
    }

    private void OnDestroy()
    {
        ScoreManagerInimigo.cristaisInimigo += 50;
    }
}


