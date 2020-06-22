using UnityEngine;
using UnityEngine.UI;

public class EnemyDog : MonoBehaviour
{
    int HP = 1800;
    int ATK = 40;
    int DEF = 40;
    int VEL = 100;
    float raioAtaqueTorre = 4.0f;
    float raioAtaqueInimigo = 4.0f;
    float savedTime;

    public static int custoInvocacao = 160;
    public static string status;
    public static string habilidade;

    int regeneracao = 50;

    public Animator anim;
    ControlEnemy inimigo;
    ParticleSystem[] part;

    void Start()
    {
        savedTime = Time.time;
        anim = GetComponent<Animator>();
        inimigo = GetComponent<ControlEnemy>();
        part = inimigo.GetComponentsInChildren<ParticleSystem>();

        status = "HP: " + HP + "\nATK: " + ATK + "\nDEF: " + DEF + "\nVEL: " + VEL;
        habilidade = "Regenerar: Regenera " + regeneracao + " pontos de HP por segundo, enquanto se move em direção a torre ou a um inimigo.";

        inimigo.HP = HP;
        inimigo.HPMax = HP;
        inimigo.ATK = ATK;
        inimigo.DEF = DEF;
        inimigo.VEL = VEL;
        inimigo.raioTorre = raioAtaqueTorre;
        inimigo.raioAtaque = raioAtaqueInimigo;
    }

    // Habilidade Regenerar: Regenera HP enquanto se move
    // Atual: 50 pontos por segundo
    private void Update()
    {
        if (Time.time - savedTime > 1)
        {
            savedTime = Time.time;

            if (inimigo.movendo == true && inimigo.morreu == false)
            {
                curar();
            }
        }
    }

    void curar()
    {
        if (inimigo.HP + regeneracao > inimigo.HPMax)
            inimigo.HP = inimigo.HPMax;
        else
        {
            inimigo.HP += regeneracao;
            part[0].Play();
        }
    }

    private void OnDestroy()
    {
        ScoreManager.cristais += 80;
    }
}
