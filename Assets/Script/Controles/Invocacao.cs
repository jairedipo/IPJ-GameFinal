using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Invocacao : MonoBehaviour
{
    public GameObject cGoop;
    public GameObject cShurtle;
    public GameObject cDog;
    public GameObject cGrunt;
    public GameObject cLich;
    public GameObject cFootman;
    public GameObject cGolem;

    GameObject personagem;

    string tecla1 = "";

    Camera cam;
    Quaternion rot = new Quaternion(0, 90.0f, 0, 0);

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (TempoDePartida.start)
        {
            if (Input.GetMouseButtonDown(0) && (tecla1 != "" && tecla1 != "."))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (onLimits(hit.point))
                    {
                        personagem = getChar(tecla1);
                        if (personagem != null)
                        {
                            Instantiate(personagem, new Vector3(hit.point.x, 0.0f, hit.point.z), rot);
                        }
                    }
                }
            }
            if (Input.anyKeyDown)
            {
                tecla1 = verificaEntrada(Input.inputString);
                if (tecla1 == "")
                    print("Comando inválido!");
                if (tecla1 == ".")
                    print("Não há cristais suficientes!");
            }
        }
    }

    bool onLimits(Vector3 position)
    {
        if (position.x > -16.5f && position.x < -4.5f && // Limites em X
            position.z > -27.4f && position.z < -12.4f && // Limites em Z
            !((position.z > -22 && position.z < -18) && position.x < -12.8f)) // Posição da Torre
        {
            return true;
        }
        return false;
    }


    GameObject getChar(string tecla)
    {
        if (tecla == "1" && ScoreManager.cristais > Goop.custoInvocacao)
        {
            ScoreManager.cristais -= Goop.custoInvocacao;
            return cGoop;
        }

        if (tecla == "2" && ScoreManager.cristais > Shurtle.custoInvocacao)
        {
            ScoreManager.cristais -= Shurtle.custoInvocacao;
            return cShurtle;
        }

        if (tecla == "3" && ScoreManager.cristais > Dog.custoInvocacao)
        {
            ScoreManager.cristais -= Dog.custoInvocacao;
            return cDog;
        }

        if (tecla == "4" && ScoreManager.cristais > Grunt.custoInvocacao)
        {
            ScoreManager.cristais -= Grunt.custoInvocacao;
            return cGrunt;
        }

        if (tecla == "5" && ScoreManager.cristais > Lich.custoInvocacao)
        {
            ScoreManager.cristais -= Lich.custoInvocacao;
            return cLich;
        }

        if (tecla == "6" && ScoreManager.cristais > Footman.custoInvocacao)
        {
            ScoreManager.cristais -= Footman.custoInvocacao;
            return cFootman;
        }

        if (tecla == "7" && ScoreManager.cristais > Golem.custoInvocacao)
        {
            ScoreManager.cristais -= Golem.custoInvocacao;
            return cGolem;
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
}