using UnityEngine;

public class ItemHP : MonoBehaviour
{
    int cura;

    private void Start()
    {
        cura = getCura();
    }

    int getCura()
    {
        int rand = Random.Range(1, 100);

        if (rand <= 60)
            return 300;
        if (rand <= 90)
            return 500;

        return 800;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ControlPlayer player = other.transform.GetComponent<ControlPlayer>();
            aplicarItem(player);

            ParticleSystem[] part = other.gameObject.GetComponentsInChildren<ParticleSystem>();
            part[0].Play();

            Destroy(gameObject, 1.0f);
        }
        if (other.gameObject.CompareTag("Inimigo"))
        {
            ControlEnemy inimigo = other.transform.GetComponent<ControlEnemy>();
            aplicarItem(inimigo);

            ParticleSystem[] part = other.gameObject.GetComponentsInChildren<ParticleSystem>();
            part[0].Play();

            Destroy(gameObject, 1.0f);
        }
    }

    #region Aplicar Efeito

    void aplicarItem(ControlPlayer personagem)
    {
        if (personagem.HP + cura > personagem.HPMax)
            personagem.HP = personagem.HPMax;
        else
            personagem.HP += cura;

        gameObject.SetActive(false);
    }

    void aplicarItem(ControlEnemy personagem)
    {
        if (personagem.HP + cura > personagem.HPMax)
            personagem.HP = personagem.HPMax;
        else
            personagem.HP += cura;

        gameObject.SetActive(false);
    }

    #endregion
}
