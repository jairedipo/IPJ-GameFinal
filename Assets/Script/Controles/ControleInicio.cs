using UnityEngine;
using UnityEngine.UI;
/// <summary>
///     Controle do tempo - Jair Edipo 03/11/2019
/// </summary>
public class ControleInicio : MonoBehaviour
{
    private Text textoRelogio; // Representa o texto que sera exibido
    private float contregreTempoDuracao; // Mede o tempo total
    private float contregreTempoInicio; // Mede a passagem do tempo

    void Start()
    {
        textoRelogio = GetComponent<Text>(); // Relaciona com o componente que exibe o texto
        ContRegreTempoReset(4); // Define a quantidade de tempo
    }

    void Update()
    {
        string mensagemTempo = "Batalhar!"; // Mensagem default
        int tempoRestante = (int)ContRegreSegRestantes(); // Verifica quanto tempo falta

        if (tempoRestante > 0) // Caso ainda tenha tempo
        {
            mensagemTempo = tempoRestante.ToString(); // Monta a mensagem com o tempo que ainda falta
        }
        else
            Destroy(gameObject, 1.5f); // Caso contrario, informa ao controle do game que o tempo acabou
        textoRelogio.text = mensagemTempo; // Atribui o tempo que falta para ser exibido na tela
    }

    // Metodo de atribuicao
    private void ContRegreTempoReset(float tempoinicial)
    {
        contregreTempoDuracao = tempoinicial; // Recebe o tempo definido como inicial
        contregreTempoInicio = Time.time; // Recebe o tempo atual
    }

    // Metodo que calcula o tempo
    private float ContRegreSegRestantes()
    {
        float tempoDecorrido = Time.time - contregreTempoInicio; // Calcula quanto tempo ja passou
        float tempoRestatnte = contregreTempoDuracao - tempoDecorrido; // Calcula quanto tempo ainda falta
        return tempoRestatnte;
    }

    private void OnDestroy()
    {
        TempoDePartida.start = true;
    }
}
