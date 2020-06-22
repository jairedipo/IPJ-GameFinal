using UnityEngine;

public class Stage4IA : MonoBehaviour
{
    bool invocar;
    string personagemEscolhido;
    int custoPersonagem;
    Vector3 position;
    InvocacaoInimigos invocacao;

    private void Start()
    {
        GameManager.dificuldade = 0.15f;
        invocar = true;
        personagemEscolhido = "";
        invocacao = gameObject.GetComponent<InvocacaoInimigos>();
    }

    void Update()
    {
        if (invocar)
        {
            position = randPos();
            personagemEscolhido = randChar();
            custoPersonagem = custo(personagemEscolhido) + 30;
            invocar = false;
        }

        if(!invocar && ScoreManagerInimigo.cristaisInimigo > custoPersonagem)
        {
            invocacao.instanciar(personagemEscolhido, position.x, position.z);
            invocar = true;
        }
    }

    int custo(string personagem)
    {
        print(personagem);
        switch (personagem)
        {
            case "1": return Goop.custoInvocacao;
            case "2": return Shurtle.custoInvocacao;
            case "3": return Dog.custoInvocacao;
            case "4": return Grunt.custoInvocacao;
            case "5": return Lich.custoInvocacao;
            case "6": return Footman.custoInvocacao;
            case "7": return Golem.custoInvocacao;
        }
        return 0;
    }

    string randChar()
    {
        int rand = Random.Range(0, 100);

        if (rand < 10)
            return "1";
        if (rand < 20)
            return "2";
        if (rand < 30)
            return "3";
        if (rand < 40)
            return "4";
        if (rand < 65)
            return "5";
        if (rand < 75)
            return "6";
        return "7";
    }

    Vector3 randPos()
    {
        float posX = Random.Range(4, 16);
        float posZ = Random.Range(-27, -12);
        Vector3 posicaoEscolhida = new Vector3(posX, 0.0f, posZ);

        if (invocacao.onLimits(posicaoEscolhida))
            return posicaoEscolhida;
        return randPos();
    }
}
