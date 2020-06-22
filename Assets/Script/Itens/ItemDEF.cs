using UnityEngine;

public class ItemDEF : MonoBehaviour
{
    float def;
    ControlPlayer player;
    ControlEnemy inimigo;

    private void Start()
    {
        def = getDEF();
    }

    float getDEF()
    {
        int rand = Random.Range(1, 100);

        if (rand <= 60)
            return 0.3f;
        if (rand <= 90)
            return 0.4f;

        return 0.5f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.transform.GetComponent<ControlPlayer>();
            aplicarItem(player);

            ParticleSystem[] part = other.gameObject.GetComponentsInChildren<ParticleSystem>();
            part[2].Play();

            Destroy(gameObject, 15.0f);
        }
        if (other.gameObject.CompareTag("Inimigo"))
        {
            inimigo = other.transform.GetComponent<ControlEnemy>();
            aplicarItem(inimigo);

            ParticleSystem[] part = other.gameObject.GetComponentsInChildren<ParticleSystem>();
            part[2].Play();

            Destroy(gameObject, 15.0f);
        }
    }


    #region Apilicar Efeito

    void aplicarItem(ControlPlayer personagem)
    {
        personagem.danoRecebido -= def;
        gameObject.SetActive(false);
    }

    void aplicarItem(ControlEnemy personagem)
    {
        personagem.danoRecebido -= def;
        gameObject.SetActive(false);
    }

    #endregion


    #region Remover Efeito

    private void OnDestroy()
    {
        if (player != null)
            desfazerItem(player);
        if (inimigo != null)
            desfazerItem(inimigo);
    }

    void desfazerItem(ControlPlayer personagem)
    {
        personagem.danoRecebido += def;
        gameObject.SetActive(false);
    }

    void desfazerItem(ControlEnemy personagem)
    {
        personagem.danoRecebido += def;
        gameObject.SetActive(false);
    }

    #endregion Remover Efeito
}
