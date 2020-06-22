using UnityEngine;

public class Shurtle : MonoBehaviour
{
    int HP = 1400;
    int ATK = 30;
    int DEF = 90;
    int VEL = 30;
    float raioAtaqueTorre = 4.0f;
    float raioAtaqueInimigo = 4.0f;

    public static int custoInvocacao = 120;
    public static string status;
    public static string habilidade;

    float bonusEspinhos = 0.5f;

    public Animator anim;
    ControlPlayer player;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GetComponent<ControlPlayer>();

        status = "HP: " + HP + "\nATK: " + ATK + "\nDEF: " + DEF + "\nVEL: " + VEL;
        habilidade = "Espinhos: Reflete em " + bonusEspinhos * 100 + "% todo o dano recebido por ataques de inimigos.";

        player.HP = HP;
        player.HPMax = HP;
        player.ATK = ATK;
        player.DEF = DEF;
        player.VEL = VEL;
        player.raioTorre = raioAtaqueTorre;
        player.raioAtaque = raioAtaqueInimigo;

        // Habilidade Espinhos: Reflete o dano recebido
        // Atual: Reflete 50% do dano
        player.espinhos = bonusEspinhos;
    }

    private void OnDestroy()
    {
        ScoreManagerInimigo.cristaisInimigo += 60;
    }
}

