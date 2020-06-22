using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManagerInimigo : MonoBehaviour
{
    public Sprite[] Digits;
    public GameObject DigitPrefab;
    float savedTime;

    public static int cristaisInimigo;
    int oldCristaisInimigo;

    void Start()
    {
        cristaisInimigo = 90;
        BuildDigits(cristaisInimigo);
        oldCristaisInimigo = cristaisInimigo;
        savedTime = Time.time;
    }

    void Update()
    {
        if (Time.time - savedTime > (1 - GameManager.dificuldade) && TempoDePartida.start)
        {
            cristaisInimigo += 10;
            savedTime = Time.time;
        }

        if (oldCristaisInimigo != cristaisInimigo)
        {
            int childCount = transform.childCount;
            for (int i = 0; i < childCount; i++)
                Destroy(transform.GetChild(i).gameObject);

            BuildDigits(cristaisInimigo);
            oldCristaisInimigo = cristaisInimigo;
        }
    }

    void BuildDigits(int number)
    {
        string numberString = number.ToString();
        numberString = new string(numberString.Reverse().ToArray());

        float offsetX = 0;
        foreach (char digit in numberString)
        {
            int idx = digit - '0';
            GameObject curDigit = Instantiate<GameObject>(DigitPrefab, transform);
            curDigit.GetComponent<Image>().sprite = Digits[idx];
            curDigit.transform.localPosition = new Vector3(-offsetX, 0, 0);
            float digitWidth = Digits[idx].rect.width;
            offsetX += digitWidth + 15;
        }
    }
}
