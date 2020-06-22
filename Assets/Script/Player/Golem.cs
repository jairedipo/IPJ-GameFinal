using UnityEngine;

public class Golem : MonoBehaviour
{
    int HP = 1800;
    int ATK = 90;
    int DEF = 100;
    int VEL = 50;
    float raioAtaqueTorre = 4.0f;
    float raioAtaqueInimigo = 4.0f;

    public static int custoInvocacao = 280;
    public static string status;
    public static string habilidade;

    public Animator anim;
    ControlPlayer player;

    void Start()
    {
        anim = GetComponent<Animator>();
        player = GetComponent<ControlPlayer>();

        status = "HP: " + HP + "\nATK: " + ATK + "\nDEF: " + DEF + "\nVEL: " + VEL;
        habilidade = "Imutável: Não é afetado por poções ou habilidades que alterem os pontos de ATK, DEF ou VEL.";

        player.HP = HP;
        player.HPMax = HP;
        player.ATK = ATK;
        player.DEF = DEF;
        player.VEL = VEL;
        player.raioTorre = raioAtaqueTorre;
        player.raioAtaque = raioAtaqueInimigo;
    }

    // Habilidade Imutável: Não é afetado por alteração de status.
    private void Update()
    {
        player.ATKBonus = 0;
        player.danoRecebido = 0.0f;
        player.VELBonus = 0;
    }

    private void OnDestroy()
    {
        ScoreManagerInimigo.cristaisInimigo += 140;
    }
}
