using UnityEngine;

public class EnemyShurtle : MonoBehaviour
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
    ControlEnemy inimigo;

    void Start()
    {
        anim = GetComponent<Animator>();
        inimigo = GetComponent<ControlEnemy>();

        status = "HP: " + HP + "\nATK: " + ATK + "\nDEF: " + DEF + "\nVEL: " + VEL;
        habilidade = "Espinhos: Reflete em " + bonusEspinhos * 100 + "% todo o dano recebido por ataques de inimigos.";

        inimigo.HP = HP;
        inimigo.HPMax = HP;
        inimigo.ATK = ATK;
        inimigo.DEF = DEF;
        inimigo.VEL = VEL;
        inimigo.raioTorre = raioAtaqueTorre;
        inimigo.raioAtaque = raioAtaqueInimigo;

        // Habilidade Espinhos: Reflete o dano recebido
        // Atual: Reflete 50% do dano
        inimigo.espinhos = bonusEspinhos;
    }

    private void OnDestroy()
    {
        ScoreManager.cristais += 60;
    }
}
