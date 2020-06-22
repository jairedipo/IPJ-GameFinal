using UnityEngine;

public class Lich : MonoBehaviour
{
    int HP = 2000;
    int ATK = 80;
    int DEF = 60;
    int VEL = 60;
    float raioAtaqueTorre = 4.0f;
    float raioAtaqueInimigo = 4.0f;
    float savedTime;

    public static int custoInvocacao = 220;
    public static string status;
    public static string habilidade;

    int cura = 20;
    float raioHabilidade = 8.0f;

    public Animator anim;
    ControlPlayer player;
    
    void Start()
    {
        savedTime = Time.time;
        anim = GetComponent<Animator>();
        player = GetComponent<ControlPlayer>();

        status = "HP: " + HP + "\nATK: " + ATK + "\nDEF: " + DEF + "\nVEL: " + VEL;
        habilidade = "Feitiço: Cura em " + cura + " pontos de HP por segundo aliados que estajam a um raio de " + raioHabilidade + " unidades.";

        player.HP = HP;
        player.HPMax = HP;
        player.ATK = ATK;
        player.DEF = DEF;
        player.VEL = VEL;
        player.raioTorre = raioAtaqueTorre;
        player.raioAtaque = raioAtaqueInimigo;
    }

    // Habilidade Feitiço: Regenera HP de aliados próximos
    // Atual: 20 pontos por segundo para cada aliado
    void Update()
    {
        if (Time.time - savedTime > 1 && !player.morreu)
        {
            GameObject[] aliadosProximos = getAliadosProximos();
            savedTime = Time.time;

            if (aliadosProximos != null)
            {
                curar(aliadosProximos);
            }
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

    void curar(GameObject[] aliados)
    {
        for (int i = 0; i < aliados.Length; i++)
        {
            if (aliados[i] != null)
            {
                ControlPlayer aliado = aliados[i].GetComponent<ControlPlayer>();

                if (aliado.HP + cura > aliado.HPMax)
                    aliado.HP = aliado.HPMax;
                else
                {
                    aliado.HP += cura;
                    ParticleSystem[] part = aliados[i].gameObject.GetComponentsInChildren<ParticleSystem>();
                    part[0].Play();
                }
            }
        }
    }

    private void OnDestroy()
    {
        ScoreManagerInimigo.cristaisInimigo += 110;
    }
}