using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SelecionaObjeto : MonoBehaviour
{
    public GameObject[] objetos;
    public GameObject[] caixaInfo;
    int pagina = 0;

    public Text Status;
    public Text Habilidade;

    public Fader fade;
    public GameObject informacoes;

    GameObject objetoAnterior;
    GameObject objetoAtual;

    float moveHorizontal = 1.0f;

    void mudarObjeto()
    {
        if (!informacoes.gameObject.activeInHierarchy)
        {
            Status.gameObject.SetActive(true);
            Habilidade.gameObject.SetActive(true);

            if (objetoAnterior != null)
                objetoAnterior.SetActive(false);
            if (objetoAtual != null)
            {
                objetoAtual.SetActive(true);
                objetoAtual.transform.rotation = new Quaternion(0.0f, 1.0f, 0.0f, 0.0f);
            }
            objetoAnterior = objetoAtual;
        }
    }


    public void setGoop()
    {
        objetoAtual = objetos[0];
        mudarObjeto();
        Status.text = Goop.status;
        Habilidade.text = Goop.habilidade;
    }

    public void setShurtle()
    {
        objetoAtual = objetos[1];
        mudarObjeto();
        Status.text = Shurtle.status;
        Habilidade.text = Shurtle.habilidade;
    }

    public void setDog()
    {
        objetoAtual = objetos[2];
        mudarObjeto();
        Status.text = Dog.status;
        Habilidade.text = Dog.habilidade;
    }

    public void setGrunt()
    {
        objetoAtual = objetos[3];
        mudarObjeto();
        Status.text = Grunt.status;
        Habilidade.text = Grunt.habilidade;
    }

    public void setLich()
    {
        objetoAtual = objetos[4];
        mudarObjeto();
        Status.text = Lich.status;
        Habilidade.text = Lich.habilidade;
    }

    public void setFootman()
    {
        objetoAtual = objetos[5];
        mudarObjeto();
        Status.text = Footman.status;
        Habilidade.text = Footman.habilidade;
    }

    public void setGolem()
    {
        objetoAtual = objetos[6];
        mudarObjeto();
        Status.text = Golem.status;
        Habilidade.text = Golem.habilidade;
    }

    public void setHP()
    {
        objetoAtual = objetos[7];
        mudarObjeto();
        Status.text = "Recupera o HP do personagem: \n  - 60%: recupera 300 pontos de HP.\n  - 30%: recupera 500 pontos de HP.\n  - 10%: recupera 800 pontos de HP.";
        Habilidade.text = "";
    }

    public void setATK()
    {
        objetoAtual = objetos[8];
        mudarObjeto();
        Status.text = "Aumenta os pontos de ATK base do personagem por 15s: \n  - 60%: aumenta +8 pontos de ATK (+32 de dano por ataque).\n  - 30%: aumenta +10 pontos de ATK (+40 de dano por ataque).\n  - 10%: aumenta +12 pontos de ATK (+48 de dano por ataque).";
        Habilidade.text = "";
    }

    public void setDEF()
    {
        objetoAtual = objetos[9];
        mudarObjeto();
        Status.text = "Reduz o dano recebido pelo personagem por 15s: \n  - 60%: reduz todo o dano recebido em 30%.\n  - 30%: reduz todo o dano recebido em 40%.\n  - 10%: reduz todo o dano recebido em 50%.";
        Habilidade.text = "";
    }

    public void setVEL()
    {
        objetoAtual = objetos[10];
        mudarObjeto();
        Status.text = "Aumenta os pontos de VEL base do personagem por 15s: \n  - 60%: aumenta +10 pontos de VEL.\n  - 30%: aumenta +12 pontos de VEL.\n  - 10%: aumenta +15 pontos de VEL.";
        Habilidade.text = "";
    }

    public void setCristal()
    {
        objetoAtual = objetos[11];
        mudarObjeto();
        Status.text = "Fornece uma quantidade de cristais: \n  - 60%: concede +80 cristais.\n  - 30%: concede +100 cristais.\n  - 10%: concede +150 cristais.";
        Habilidade.text = "";
    }

    public void setCaixa()
    {
        objetoAtual = objetos[12];
        mudarObjeto();
        Status.text = "";
        Habilidade.text = "";
        caixaInfo[pagina % caixaInfo.Length].SetActive(false);
        pagina = 0;
        caixaInfo[pagina % caixaInfo.Length].SetActive(true);
    }

    public void next()
    {
        caixaInfo[pagina % caixaInfo.Length].SetActive(false);
        pagina++;
        caixaInfo[pagina % caixaInfo.Length].SetActive(true);
    }

    public void exit()
    {
        fade.FadeToGame();
        SceneManager.LoadScene("SelecaoDeEstagio");
    }

    public void info()
    {
        if(objetoAtual != null)
            objetoAtual.SetActive(false);
        Status.gameObject.SetActive(false);
        Habilidade.gameObject.SetActive(false);
        informacoes.SetActive(true);
    }

    public void fechar()
    {
        informacoes.SetActive(false);
    }

    private void Update()
    {
        if(objetoAtual != null)
        {
            moveHorizontal = -Input.GetAxis("Horizontal");
            objetoAtual.transform.Rotate(new Vector3(0, 1, 0), moveHorizontal);
        }
    }
}
