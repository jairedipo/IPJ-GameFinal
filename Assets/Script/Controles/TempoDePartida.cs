using UnityEngine;
using UnityEngine.UI;
/// <summary>
///     Controle do tempo - Jair Edipo 03/11/2019
/// </summary>
public class TempoDePartida : MonoBehaviour
{
    string mensagemTempo;

    private Text textoRelogio; // Representa o texto que sera exibido
    private float contregreTempoDuracao; // Mede o tempo total
    private float contregreTempoInicio; // Mede a passagem do tempo

    public static bool start;

    public GameObject HPManagerTorrePlayer;
    public GameObject HPManagerTorreInimiga;
    public GameObject CameraControleBatalha;

    void Start()
    {
        textoRelogio = GetComponent<Text>(); // Relaciona com o componente que exibe o texto
        ContRegreTempoReset(205); // Define a quantidade de tempo
        start = false;
        mensagemTempo = "200";
    }

    void Update()
    {
        if (start)
        {
            // Mensagem default
            int tempoRestante = (int)ContRegreSegRestantes(); // Verifica quanto tempo falta

            if (tempoRestante > 0) // Caso ainda tenha tempo
                mensagemTempo = PreencheZeros(tempoRestante); // Monta a mensagem com o tempo que ainda falta
            else
            {
                mensagemTempo = "000"; // Caso contrario, informa ao controle do game que o tempo acabou
                decideVencedor();
            }
        }

        textoRelogio.text = mensagemTempo;
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

    private string PreencheZeros(int n)
    {
        return n.ToString().PadLeft(3, '0'); // Formata o tempo para sempre ter 3 casas
    }

    void decideVencedor()
    {
        HPManager torrePlayer = HPManagerTorrePlayer.GetComponent<HPManager>();
        HPManager torreInimiga = HPManagerTorreInimiga.GetComponent<HPManager>();

        if (torrePlayer.HPAtual > torreInimiga.HPAtual)
            CameraControleBatalha.GetComponent<ControleBatalha>().venceu();
        else
            CameraControleBatalha.GetComponent<ControleBatalha>().perdeu();
    }
}
