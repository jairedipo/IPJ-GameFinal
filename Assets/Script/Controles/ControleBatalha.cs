using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControleBatalha : MonoBehaviour
{
    public GameObject vitoria;
    public GameObject derrota;
    public GameObject pauseMenu;
    public Fader fade;

    bool vitoriaPlayer = false;

    public void venceu()
    {
        if (derrota.activeSelf == false)
            vitoria.gameObject.SetActive(true);
        TempoDePartida.start = false;

        vitoriaPlayer = true;
    }

    public void perdeu()
    {
        if(vitoria.activeSelf == false)
            derrota.gameObject.SetActive(true);
        TempoDePartida.start = false;
    }

    public void reiniciarPartida()
    {
        Time.timeScale = 1;
        fade.FadeToGame();
        Scene cenaAtual = SceneManager.GetActiveScene();
        SceneManager.LoadScene(cenaAtual.name);
    }

    public void sairDaPartida()
    {
        Time.timeScale = 1;
        if (GameManager.progredir && vitoriaPlayer == true)
        {
            GameManager.progressao++;
            vitoriaPlayer = false;
        }

        fade.FadeToGame();

        if(GameManager.progressao == 9)
        {
            SceneManager.LoadScene("GameOver");
        }
        SceneManager.LoadScene("SelecaoDeEstagio");
    }

    public void pause()
    {
        if (TempoDePartida.start)
        {
            if (Time.timeScale > 0)
            {
                Time.timeScale = 0;
                pauseMenu.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                pauseMenu.SetActive(false);
            }
        }
    }
}
