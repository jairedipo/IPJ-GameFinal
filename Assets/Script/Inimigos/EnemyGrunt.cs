using UnityEngine;

public class EnemyGrunt : MonoBehaviour
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
    ControlEnemy inimigo;

    void Start()
    {
        anim = GetComponent<Animator>();
        inimigo = GetComponent<ControlEnemy>();

        status = "HP: " + HP + "\nATK: " + ATK + "\nDEF: " + DEF + "\nVEL: " + VEL;
        habilidade = "Fúria: Aumenta em " + bonusCritico * 100 + "% a chance de golpes críticos (150% de dano), quando \nHP < 50% (" + HP / 2 + ").";

        inimigo.HP = HP;
        inimigo.HPMax = HP;
        inimigo.ATK = ATK;
        inimigo.DEF = DEF;
        inimigo.VEL = VEL;
        inimigo.raioTorre = raioAtaqueTorre;
        inimigo.raioAtaque = raioAtaqueInimigo;
    }

    // Habilidade Furia: Aumenta a chance de crítico, quando HP < 50%
    // Atual: Chance de crítico aumentada para 20%
    void Update()
    {
        if (inimigo.HP < HP / 2)
            inimigo.chanceCritico = bonusCritico;
        else
            inimigo.chanceCritico = 0.015f;
    }

    private void OnDestroy()
    {
        ScoreManager.cristais += 90;
    }
}
