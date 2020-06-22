using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvocacaoInimigos : MonoBehaviour
{
    public GameObject CloneGoop;
    public GameObject CloneShurtle;
    public GameObject CloneDog;
    public GameObject CloneGrunt;
    public GameObject CloneLich;
    public GameObject CloneFootman;
    public GameObject CloneGolem;

    GameObject personagem;

    string tecla1 = "";

    Camera cam;
    Quaternion rot = new Quaternion(0, -90.0f, 0, 0);

    void Start()
    {
        cam = Camera.main;
    }

    //void Update()
    //{
    //    if (TempoDePartida.start)
    //    {
    //        if (Input.GetMouseButtonDown(1) && (tecla1 != "" && tecla1 != "."))
    //        {
    //            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
    //            RaycastHit hit;
    //            if (Physics.Raycast(ray, out hit))
    //            {
    //                if (onLimits(hit.point))
    //                {
    //                    personagem = getChar(tecla1);
    //                    if (personagem != null)
    //                    {
    //                        Instantiate(personagem, new Vector3(hit.point.x, 0.0f, hit.point.z), rot);
    //                    }
    //                }
    //            }
    //        }
    //        if (Input.anyKeyDown)
    //        {
    //            tecla1 = verificaEntrada(Input.inputString);
    //            if (tecla1 == "")
    //                print("Comando inválido!");
    //            if (tecla1 == ".")
    //                print("Não há cristais suficientes!");
    //        }
    //    }
    //}

    public bool onLimits(Vector3 position)
    {
        if (position.x < 16.5f && position.x > 4.5f && // Limites em X
            position.z > -27.4f && position.z < -12.4f && // Limites em Z
            !((position.z > -22 && position.z < -18) && position.x > 12.8f)) // Posição da Torre
        {
            return true;
        }
        return false;
    }


    public GameObject getChar(string tecla)
    {
        if (tecla == "1" && ScoreManagerInimigo.cristaisInimigo > Goop.custoInvocacao)
        {
            ScoreManagerInimigo.cristaisInimigo -= Goop.custoInvocacao;
            return CloneGoop;
        }

        if (tecla == "2" && ScoreManagerInimigo.cristaisInimigo > Shurtle.custoInvocacao)
        {
            ScoreManagerInimigo.cristaisInimigo -= Shurtle.custoInvocacao;
            return CloneShurtle;
        }

        if (tecla == "3" && ScoreManagerInimigo.cristaisInimigo > Dog.custoInvocacao)
        {
            ScoreManagerInimigo.cristaisInimigo -= Dog.custoInvocacao;
            return CloneDog;
        }

        if (tecla == "4" && ScoreManagerInimigo.cristaisInimigo > Grunt.custoInvocacao)
        {
            ScoreManagerInimigo.cristaisInimigo -= Grunt.custoInvocacao;
            return CloneGrunt;
        }

        if (tecla == "5" && ScoreManagerInimigo.cristaisInimigo > Lich.custoInvocacao)
        {
            ScoreManagerInimigo.cristaisInimigo -= Lich.custoInvocacao;
            return CloneLich;
        }

        if (tecla == "6" && ScoreManagerInimigo.cristaisInimigo > Footman.custoInvocacao)
        {
            ScoreManagerInimigo.cristaisInimigo -= Footman.custoInvocacao;
            return CloneFootman;
        }

        if (tecla == "7" && ScoreManagerInimigo.cristaisInimigo > Golem.custoInvocacao)
        {
            ScoreManagerInimigo.cristaisInimigo -= Golem.custoInvocacao;
            return CloneGolem;
        }

        return null;
    }

    string verificaEntrada(string input)
    {
        if (input == "1" || input == "2" || input == "3" || input == "4" || input == "5" || input == "6" || input == "7")
        {
            return input;
        }
        return "";
    }


    public void instanciar(string personagemEscolhido, float posicaoX, float posicaoZ)
    {

        Instantiate(getChar(personagemEscolhido), new Vector3(posicaoX, 0.0f, posicaoZ), rot);
    }
}