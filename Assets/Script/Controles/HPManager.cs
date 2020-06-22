using UnityEngine;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    public GameObject torreObj;
    public GameObject VidaPrefab;
    public GameObject Controle;

    public int HPAtual;
    int HPMax;
    bool inimigo;
    int oldHP;
    float posX;
    Torre torre;

    Image HPBar;
    Color colorBar;
    ControleBatalha controleBatalha;

    void Start()
    {
        torre = torreObj.GetComponent<Torre>();
        controleBatalha = Controle.GetComponent<ControleBatalha>();
        HPMax = HPAtual = 20000;

        if (torreObj.tag == "TorreInimiga")
        {
            inimigo = true;
            posX = 590.6f;
            BuildHPInimigo(HPAtual);
        }
        else
        {
            inimigo = false;
            posX = 180.6f;
            BuildHP(HPAtual);
        }
        oldHP = HPAtual;
    }

    void Update()
    {
        HPAtual = torre.HP;
        if (oldHP != HPAtual && HPAtual >= 0)
        {
            if (inimigo)
            {
                BuildHPInimigo(HPAtual);
                oldHP = HPAtual;
            }
            else
            {
                BuildHP(HPAtual);
                oldHP = HPAtual;
            }
        }
        else if (HPAtual == 0)
        {
            if(inimigo)
                controleBatalha.venceu();
            else
                controleBatalha.perdeu();
        }
    }

    void BuildHP(int HP)
    {
        HPBar = VidaPrefab.GetComponent<Image>();
        colorBar = getColor(HP);
        HPBar.color = colorBar;
        VidaPrefab.transform.localScale = new Vector3(1.0f/ HPMax * HP, 1);
        VidaPrefab.transform.localPosition = new Vector3(-posX + (180.6f / HPMax * HP), 0, 0);
    }

    void BuildHPInimigo(int HP)
    {
        HPBar = VidaPrefab.GetComponent<Image>();
        colorBar = getColor(HP);
        HPBar.color = colorBar;
        VidaPrefab.transform.localScale = new Vector3(-1.0f / HPMax * HP, 1);
        VidaPrefab.transform.localPosition = new Vector3(posX + (-180.6f / HPMax * HP), 0, 0);
    }

    Color getColor(int HP)
    {
        float porcentagemHP = (2.0f/(float)HPMax) * HP;

        if (porcentagemHP > 1.0f)
            return new Color(2.0f - porcentagemHP, 1.0f, 0);
        else
            return new Color(1.0f, porcentagemHP, 0);
    }
}
