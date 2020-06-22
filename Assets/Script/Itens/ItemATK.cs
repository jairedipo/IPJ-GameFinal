using UnityEngine;

public class ItemATK : MonoBehaviour
{
    int atk;
    ControlPlayer player;
    ControlEnemy inimigo;

    private void Start()
    {
        atk = getATK();
    }

    int getATK()
    {
        int rand = Random.Range(1, 100);

        if (rand <= 60)
            return 8;
        if (rand <= 90)
            return 10;

        return 12;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.transform.GetComponent<ControlPlayer>();
            aplicarItem(player);

            ParticleSystem []part =  other.gameObject.GetComponentsInChildren<ParticleSystem>();
            part[1].Play();

            Destroy(gameObject, 15.0f);
        }
        if (other.gameObject.CompareTag("Inimigo"))
        {
            inimigo = other.transform.GetComponent<ControlEnemy>();
            aplicarItem(inimigo);

            ParticleSystem[] part = other.gameObject.GetComponentsInChildren<ParticleSystem>();
            part[1].Play();

            Destroy(gameObject, 15.0f);
        }
    }


    #region Apilicar Efeito

    void aplicarItem(ControlPlayer personagem)
    {
        personagem.ATKBonus += atk;
        gameObject.SetActive(false);
    }

    void aplicarItem(ControlEnemy personagem)
    {
        personagem.ATKBonus += atk;
        gameObject.SetActive(false);
    }

    #endregion


    #region Remover Efeito

    private void OnDestroy()
    {
        if(player != null)
            desfazerItem(player);
        if(inimigo != null)
            desfazerItem(inimigo);
    }

    void desfazerItem(ControlPlayer personagem)
    {
        personagem.ATKBonus -= atk;
        gameObject.SetActive(false);
    }

    void desfazerItem(ControlEnemy personagem)
    {
        personagem.ATKBonus -= atk;
        gameObject.SetActive(false);
    }

    #endregion Remover Efeito
}
