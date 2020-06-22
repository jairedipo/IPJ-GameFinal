using UnityEngine;

public class Grunt : MonoBehaviour
{
    int HP = 800;
    int ATK = 100;
    int DEF = 70;
    int VEL = 50;
    float raioAtaqueTorre = 4.0f;
    float raioAtaqueInimigo = 4.0f;

    public static int custoInvocacao = 180;
    public static string status;
    public static string habilidade;

    float bonusCritico = 0.2f;

    public Animator anim;
    ControlPlayer player;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GetComponent<ControlPlayer>();

        status = "HP: " + HP + "\nATK: " + ATK + "\nDEF: " + DEF + "\nVEL: " + VEL;
        habilidade = "Fúria: Aumenta em " + bonusCritico * 100 + "% a chance de golpes críticos (150% de dano), quando \nHP < 50% (" + HP / 2 + ").";

        player.HP = HP;
        player.HPMax = HP;
        player.ATK = ATK;
        player.DEF = DEF;
        player.VEL = VEL;
        player.raioTorre = raioAtaqueTorre;
        player.raioAtaque = raioAtaqueInimigo;
    }

    // Habilidade Furia: Aumenta a chance de crítico, quando HP < 50%
    // Atual: Chance de crítico aumentada para 20%
    void Update()
    {
        if(player.HP < HP / 2)
            player.chanceCritico = bonusCritico;
        else
            player.chanceCritico = 0.015f;
    }

    private void OnDestroy()
    {
        ScoreManagerInimigo.cristaisInimigo += 90;
    }
}

