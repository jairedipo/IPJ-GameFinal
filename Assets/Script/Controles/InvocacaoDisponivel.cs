using UnityEngine;

public class InvocacaoDisponivel : MonoBehaviour
{
    public GameObject panel;
    public GameObject fade;
    ExibeCusto custoInvocacao;
    int custo;


    void Start()
    {
        custoInvocacao = panel.GetComponentInChildren<ExibeCusto>();
        custo = custoInvocacao.valor;
    }

    void Update()
    {
        if (ScoreManager.cristais >= custo)
            fade.SetActive(false);
        else
            fade.SetActive(true);
    }
}
