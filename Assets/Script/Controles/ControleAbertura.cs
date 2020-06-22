using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class ControleAbertura : MonoBehaviour
{
    VideoPlayer abertura;
    public GameObject Plano;
    public Fader fader;

    bool OcultarPlano;
    float savedTime;

    void Start()
    {
        abertura = GetComponent<VideoPlayer>();
        savedTime = Time.time;
        OcultarPlano = false;
    }

    private void Update()
    {
        if(abertura.isPlaying && OcultarPlano == false && Time.time - savedTime > 1.5f)
        {
            Plano.SetActive(false);
            OcultarPlano = true;
        }

        if ((!abertura.isPlaying || Input.GetKeyDown(KeyCode.Space)) && Time.time - savedTime > 5)
        {
            fader.FadeToGame();
            SceneManager.LoadScene("TelaDeInicio2");
        }
    }
}
