using UnityEngine;

public class Footman : MonoBehaviour
{
    int HP = 1000;
    int ATK = 100;
    int DEF = 80;
    int VEL = 70;
    float raioAtaqueTorre = 4.0f;
    float raioAtaqueInimigo = 4.0f;
    float raioHabilidade = 5.0f;
    float savedTime;

    public static int custoInvocacao = 240;
    public static string status;
    public static string habilidade;

    float reducaoDeDano = 0.08f;

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
        habilidade = "Proteção: Reduz em " + reducaoDeDano * 100 + "% o dano recebido por aliados em um raio de " + raioHabilidade + " unidades.";

        player.HP = HP;
        player.HPMax = HP;
        player.ATK = ATK;
        player.DEF = DEF;
        player.VEL = VEL;
        player.raioTorre = raioAtaqueTorre;
        player.raioAtaque = raioAtaqueInimigo;
    }

    // Habilidade Proteção: Reduz o dano de aliados próximos
    // Buff: 5% -> 8% de redução
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
                    aliado.danoRecebido -= reducaoDeDano;
                    ParticleSystem[] part = aliadosProximos[i].gameObject.GetComponentsInChildren<ParticleSystem>();
                    part[2].Play();
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
                    aliado.danoRecebido += reducaoDeDano;
                    ParticleSystem[] part = aliadosProximos[i].gameObject.GetComponentsInChildren<ParticleSystem>();
                    part[2].Stop();
                }
            }
        }
    }

    private void OnDestroy()
    {
        ScoreManagerInimigo.cristaisInimigo += 120;
    }
}