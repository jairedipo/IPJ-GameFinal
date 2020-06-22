using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadStage : MonoBehaviour
{
    public Fader fade;
    public static GameObject menu;
    public GameObject informacoes;

    public void LoadStage1()
    {
        fade.FadeToGame();

        if (GameManager.progressao == 1)
            GameManager.progredir = true;
        else
            GameManager.progredir = false;

        SceneManager.LoadScene("Estagio1");
    }

    public void LoadStage2()
    {
        fade.FadeToGame();

        if (GameManager.progressao == 2)
            GameManager.progredir = true;
        else
            GameManager.progredir = false;

        SceneManager.LoadScene("Estagio2");
    }

    public void LoadStage3()
    {
        fade.FadeToGame();

        if (GameManager.progressao == 3)
            GameManager.progredir = true;
        else
            GameManager.progredir = false;

        SceneManager.LoadScene("Estagio3");
    }

    public void LoadStage4()
    {
        fade.FadeToGame();

        if (GameManager.progressao == 4)
            GameManager.progredir = true;
        else
            GameManager.progredir = false;

        SceneManager.LoadScene("Estagio4");
    }

    public void LoadStage5()
    {
        fade.FadeToGame();

        if (GameManager.progressao == 5)
            GameManager.progredir = true;
        else
            GameManager.progredir = false;

        SceneManager.LoadScene("Estagio5");
    }

    public void LoadStage6()
    {
        fade.FadeToGame();

        if (GameManager.progressao == 6)
            GameManager.progredir = true;
        else
            GameManager.progredir = false;

        SceneManager.LoadScene("Estagio6");
    }

    public void LoadStage7()
    {
        fade.FadeToGame();

        if (GameManager.progressao == 7)
            GameManager.progredir = true;
        else
            GameManager.progredir = false;

        SceneManager.LoadScene("Estagio7");
    }

    public void LoadStage8()
    {
        fade.FadeToGame();

        if (GameManager.progressao == 8)
            GameManager.progredir = true;
        else
            GameManager.progredir = false;

        SceneManager.LoadScene("Estagio8");
    }

    public void FecharMenu()
    {
        menu.SetActive(false);
    }

    public void info()
    {
        informacoes.SetActive(true);
    }

    public void fechar()
    {
        informacoes.SetActive(false);
    }
}
