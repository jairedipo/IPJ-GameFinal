using UnityEngine;
using UnityEngine.UI;

public class Dog : MonoBehaviour
{
    int HP = 1600;
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
    ControlPlayer player;
    ParticleSystem[] part;

    void Start()
    {
        savedTime = Time.time;
        anim = GetComponent<Animator>();
        player = GetComponent<ControlPlayer>();
        part = player.GetComponentsInChildren<ParticleSystem>();

        status = "HP: " + HP + "\nATK: " + ATK + "\nDEF: " + DEF + "\nVEL: " + VEL;
        habilidade = "Regenerar: Regenera " + regeneracao + " pontos de HP por segundo, enquanto se move em direção a torre ou a um inimigo.";

        player.HP = HP;
        player.HPMax = HP;
        player.ATK = ATK;
        player.DEF = DEF;
        player.VEL = VEL;
        player.raioTorre = raioAtaqueTorre;
        player.raioAtaque = raioAtaqueInimigo;
    }

    // Habilidade Regenerar: Regenera HP enquanto se move
    // Atual: 50 pontos por segundo
    private void Update()
    {
        if (Time.time - savedTime > 1)
        {
            savedTime = Time.time;

            if (player.movendo == true && player.morreu == false)
            {
                curar();
            }
        }
    }

    void curar()
    {
        if (player.HP + regeneracao > player.HPMax)
            player.HP = player.HPMax;
        else
        {
            player.HP += regeneracao;
            part[0].Play();
        }
    }

    private void OnDestroy()
    {
        ScoreManagerInimigo.cristaisInimigo += 80;
    }
}
