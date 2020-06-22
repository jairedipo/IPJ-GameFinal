using UnityEngine;

public class EnemyGolem : MonoBehaviour
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
    ControlEnemy inimigo;

    void Start()
    {
        anim = GetComponent<Animator>();
        inimigo = GetComponent<ControlEnemy>();

        status = "HP: " + HP + "\nATK: " + ATK + "\nDEF: " + DEF + "\nVEL: " + VEL;
        habilidade = "Imutável: Não é afetado por poções ou habilidades que alterem os pontos de ATK, DEF ou VEL.";

        inimigo.HP = HP;
        inimigo.HPMax = HP;
        inimigo.ATK = ATK;
        inimigo.DEF = DEF;
        inimigo.VEL = VEL;
        inimigo.raioTorre = raioAtaqueTorre;
        inimigo.raioAtaque = raioAtaqueInimigo;
    }

    // Habilidade Imutável: Não é afetado por alteração de status.
    private void Update()
    {
        inimigo.ATKBonus = 0;
        inimigo.danoRecebido = 0.0f;
        inimigo.VELBonus = 0;
    }

    private void OnDestroy()
    {
        ScoreManager.cristais += 140;
    }
}
