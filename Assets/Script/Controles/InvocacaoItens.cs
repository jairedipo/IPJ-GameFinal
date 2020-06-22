using UnityEngine;

public class InvocacaoItens : MonoBehaviour
{
    public GameObject[] itens;

    float intervalo;
    float tempoAtual;

    Quaternion rot = new Quaternion(0, 0, 0, 0);

    private void Start()
    {
        intervalo = Random.Range(5.0f, 10.0f);
    }

    void Update()
    {
        if (Time.time > intervalo && TempoDePartida.start)
        {
            float rand = Random.Range(5.0f, 10.0f);
            intervalo = Time.time + rand;
            int randItem = Random.Range(0, itens.Length);

            if(itens[randItem].gameObject.GetComponent<ItemCaixaSurpresa>() != null)
                Instantiate(itens[randItem], getPositionCaixa(), rot);
            else
                Instantiate(itens[randItem], getPosition(), rot);
        }
    }


    private Vector3 getPosition()
    {
        float posx = Random.Range(-1.0f, 1.0f);
        float posz = Random.Range(-13.0f, -27.0f);

        return new Vector3(posx, 1.2f, posz);
    }

    private Vector3 getPositionCaixa()
    {
        float posx = Random.Range(-1.0f, 1.0f);
        float posz = Random.Range(-13.0f, -27.0f);

        return new Vector3(posx, 0.1f, posz);
    }
}
