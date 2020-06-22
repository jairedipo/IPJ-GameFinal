using UnityEngine;

public class EnemyLich : MonoBehaviour
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
    ControlEnemy inimigo;

    void Start()
    {
        savedTime = Time.time;
        anim = GetComponent<Animator>();
        inimigo = GetComponent<ControlEnemy>();

        status = "HP: " + HP + "\nATK: " + ATK + "\nDEF: " + DEF + "\nVEL: " + VEL;
        habilidade = "Feitiço: Cura em " + cura + " pontos de HP por segundo aliados que estajam a um raio de " + raioHabilidade + " unidades.";

        inimigo.HP = HP;
        inimigo.HPMax = HP;
        inimigo.ATK = ATK;
        inimigo.DEF = DEF;
        inimigo.VEL = VEL;
        inimigo.raioTorre = raioAtaqueTorre;
        inimigo.raioAtaque = raioAtaqueInimigo;
    }

    // Habilidade Feitiço: Regenera HP de aliados próximos
    // Atual: 20 pontos por segundo para cada aliado
    void Update()
    {
        if (Time.time - savedTime > 1 && !inimigo.morreu)
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

        GameObject[] aliados = GameObject.FindGameObjectsWithTag("Inimigo");

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
                ControlEnemy aliado = aliados[i].GetComponent<ControlEnemy>();

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
        ScoreManager.cristais += 110;
    }
}