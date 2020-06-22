using UnityEngine;

public class ItemCristal : MonoBehaviour
{
    int valor;

    private void Start()
    {
        valor = getValor();
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, -180, 0) * Time.deltaTime);
    }

    int getValor()
    {
        int rand = Random.Range(1, 100);

        if (rand <= 60)
            return 80;
        if (rand <= 90)
            return 100;

        return 150;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ControlPlayer player = other.transform.GetComponent<ControlPlayer>();
            aplicarItem(player);

            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Inimigo"))
        {
            ControlEnemy inimigo = other.transform.GetComponent<ControlEnemy>();
            aplicarItem(inimigo);

            Destroy(gameObject);
        }
    }


    void aplicarItem(ControlPlayer personagem)
    {
        ScoreManager.cristais += getValor();
    }

    void aplicarItem(ControlEnemy personagem)
    {
        ScoreManagerInimigo.cristaisInimigo += getValor();
    }
}
